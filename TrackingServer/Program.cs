using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MotionTracking;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Diagnostics;

class TrackingConsole
{
    private static string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
    private static TrackingModule client1;
    private static TrackingModule client2;
    private static CancellationTokenSource cts;
    private static Task workerTask;
    private static UdpClient udpSender;

    private static string multicastGroup = "239.0.0.222";
    private static int port = 1601;

    private static string remoteIP1 = "192.168.0.32";
    private static string localIP1 = "192.168.0.32";
    private static string remoteIP2 = "192.168.0.33";
    private static string localIP2 = "192.168.0.33";
    private static int trackingID1 = 4;
    private static int trackingID2 = 5;
    private static string logFileName = "";

    private static int updateHz = 60;
    private static int reconnectDelayMs = 1000;

    private static void LoadConfig()
    {
        if (!File.Exists(configPath)) return;

        var json = File.ReadAllText(configPath);
        var config = JObject.Parse(json)["Tracking"];

        localIP1 = config["LocalIP1"]?.ToString() ?? localIP1;
        remoteIP1 = config["RemoteIP1"]?.ToString() ?? remoteIP1;
        localIP2 = config["LocalIP2"]?.ToString() ?? localIP2;
        remoteIP2 = config["RemoteIP2"]?.ToString() ?? remoteIP2;
        port = (int?)config["SendPort"] ?? port;
        multicastGroup = config["MulticastGroup"]?.ToString() ?? multicastGroup;
        trackingID1 = (int?)config["TrackingID1"] ?? trackingID1;
        trackingID2 = (int?)config["TrackingID2"] ?? trackingID2;
        logFileName = config["LogFileName"]?.ToString() ?? logFileName;
        updateHz = (int?)config["UpdateHz"] ?? updateHz;
        reconnectDelayMs = (int?)config["ReconnectDelayMs"] ?? reconnectDelayMs;
    }

    static async Task Main(string[] args)
    {
        LoadConfig();

        Console.WriteLine("TrackingConsole starting...");
        cts = new CancellationTokenSource();
        udpSender = new UdpClient();
        udpSender.JoinMulticastGroup(IPAddress.Parse(multicastGroup));

        client1 = new TrackingModule();
        client2 = new TrackingModule();

        workerTask = Task.Run(() => WorkerLoop(cts.Token));

        Console.WriteLine("Press ENTER to exit...");
        Console.ReadLine();

        await ShutdownAsync();
    }

    private static async Task WorkerLoop(CancellationToken token)
    {
        int sleepMs = 1000 / updateHz;
        var endpoint = new IPEndPoint(IPAddress.Parse(multicastGroup), port);
        //var sw = new Stopwatch();
        //int targetIntervalMs = 2; // 예: 2ms 간격

        while (!token.IsCancellationRequested)
        {
            //sw.Restart();
            // 서버 1 연결 확인 및 재연결
            if (!client1.IsConnected)
            {
                try
                {
                    await client1.StartAsync(1, remoteIP1, localIP1, trackingID1, trackingID2, logFileName);
                    Console.WriteLine("Client 1 connected.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error] Client 1 connection failed: {ex.Message}");
                }
            }

            // 서버 2 연결 확인 및 재연결
            if (!client2.IsConnected && remoteIP2 != "")
            {
                try
                {
                    await client2.StartAsync(1, remoteIP2, localIP2, 0, 0, "", 1520, 1521);
                    Console.WriteLine("Client 2 connected.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error] Client 2 connection failed: {ex.Message}");
                }
            }


            if (client1.IsConnected && client1.IsUpdated)
            {
                client1.IsUpdated = false;
                var frameSet = new List<object>();
                var (frameNumber, timestamp, state, speed) = client1.GetLatestData();
                var result = new
                {
                    serverId = -1,
                    frameNumber = frameNumber,
                    timestamp = timestamp,
                    state = state,
                    speed = speed,
                };

                frameSet.Add(result);
                var frame1 = JsonConvert.DeserializeObject<object>(client1.GetRigidBodiesJson(1));
                frameSet.Add(frame1);

                var payload = JsonConvert.SerializeObject(new { frameSet = frameSet });
                try
                {
                    var bytes = Encoding.UTF8.GetBytes(payload);
                    udpSender.Send(bytes, bytes.Length, endpoint);
                }
                catch (SocketException ex)
                {
                    Console.WriteLine($"[Error] UDP send failed: {ex.Message}");
                    udpSender.Close();
                    udpSender = new UdpClient();
                    udpSender.JoinMulticastGroup(IPAddress.Parse(multicastGroup));
                }
                //Console.WriteLine($"client1: {DateTime.Now.ToString("HH:mm:ss.fff")}");
            }

            if (client2.IsConnected && client2.IsUpdated)
            {
                client2.IsUpdated = false;
                var frameSet = new List<object>();
                var frame2 = JsonConvert.DeserializeObject<object>(client2.GetRigidBodiesJson(2));
                frameSet.Add(frame2);
                var payload = JsonConvert.SerializeObject(new { frameSet = frameSet });
                try
                {
                    var bytes = Encoding.UTF8.GetBytes(payload);
                    udpSender.Send(bytes, bytes.Length, endpoint);
                }
                catch (SocketException ex)
                {
                    Console.WriteLine($"[Error] UDP send failed: {ex.Message}");
                    udpSender.Close();
                    udpSender = new UdpClient();
                    udpSender.JoinMulticastGroup(IPAddress.Parse(multicastGroup));
                }
                //Console.WriteLine($"client2: {DateTime.Now.ToString("HH:mm:ss.fff")}");
            }

            //var payload = JsonConvert.SerializeObject(new { frameSet = frameSet });
            //try
            //{
            //    var bytes = Encoding.UTF8.GetBytes(payload);
            //    udpSender.Send(bytes, bytes.Length, endpoint);
            //}
            //catch (SocketException ex)
            //{
            //    Console.WriteLine($"[Error] UDP send failed: {ex.Message}");
            //    udpSender.Close();
            //    udpSender = new UdpClient();
            //    udpSender.JoinMulticastGroup(IPAddress.Parse(multicastGroup));
            //}
            //Thread.Sleep(1);
            //await Task.Delay(1, token);
            //while (sw.ElapsedMilliseconds < targetIntervalMs)
            //{
            //    await Task.Yield(); // CPU 양보
            //}
        }

        await client1.StopAsync();
        await client2.StopAsync();
    }

    private static async Task ShutdownAsync()
    {
        cts?.Cancel();
        udpSender?.DropMulticastGroup(IPAddress.Parse(multicastGroup));
        udpSender?.Close();
        await workerTask;
        Console.WriteLine("TrackingConsole stopped.");
    }
}
