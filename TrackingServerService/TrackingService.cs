// TrackingService.cs (비동기 고급버전)
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MotionTracking;
using Newtonsoft.Json.Linq;

public class TrackingService : ServiceBase
{
    private CancellationTokenSource cts;
    private Task workerTask;
    private Task httpTask;
    private UdpClient udpSender;

    private string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
    private string localIP = "192.168.0.32";
    private string remoteIP = "192.168.0.32";
    private int port = 1601;
    private string multicastGroup = "239.0.0.222";
    private int trackingID1 = 4;
    private int trackingID2 = 5;
    private string logFileName = "tracking_log.txt";
    private int updateHz = 60;
    private int reconnectDelayMs = 1000;

    public TrackingService()
    {
        this.ServiceName = "TrackingServerService";
    }

    private void LoadConfig()
    {
        if (!File.Exists(configPath)) return;

        var json = File.ReadAllText(configPath);
        var config = JObject.Parse(json)["Tracking"];

        localIP = config["LocalIP"]?.ToString() ?? localIP;
        remoteIP = config["RemoteIP"]?.ToString() ?? remoteIP;
        port = (int?)config["SendPort"] ?? port;
        multicastGroup = config["MulticastGroup"]?.ToString() ?? multicastGroup;
        trackingID1 = (int?)config["TrackingID1"] ?? trackingID1;
        trackingID2 = (int?)config["TrackingID2"] ?? trackingID2;
        logFileName = config["LogFileName"]?.ToString() ?? logFileName;
        updateHz = (int?)config["UpdateHz"] ?? updateHz;
        reconnectDelayMs = (int?)config["ReconnectDelayMs"] ?? reconnectDelayMs;
    }

    protected override void OnStart(string[] args)
    {
        LoadConfig();
        cts = new CancellationTokenSource();

        udpSender = new UdpClient();
        udpSender.JoinMulticastGroup(IPAddress.Parse(multicastGroup));

        workerTask = Task.Run(() => WorkerLoop(cts.Token));
        httpTask = Task.Run(() => HttpServerLoop(cts.Token));
    }

    protected override void OnStop()
    {
        cts?.Cancel();
        udpSender?.DropMulticastGroup(IPAddress.Parse(multicastGroup));
        udpSender?.Close();
        Task.WaitAll(new[] { workerTask, httpTask }, 5000);
    }

    private async Task WorkerLoop(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            try
            {
                await TrackingModule.StartAsync(1, remoteIP, localIP, trackingID1, trackingID2, logFileName);
                Log("INFO", "TrackingModule started.");
            }
            catch (Exception ex)
            {
                Log("ERROR", $"Failed to start TrackingModule: {ex.Message}");
                await Task.Delay(reconnectDelayMs, token);
                continue;
            }

            int sleepMs = 1000 / updateHz;
            var endpoint = new IPEndPoint(IPAddress.Parse(multicastGroup), port);

            while (TrackingModule.IsConnected && !token.IsCancellationRequested)
            {
                var (frameNumber, timestamp, state, speed) = TrackingModule.GetLatestData();
                string data = $"{frameNumber},{timestamp:F2},{state},{speed:F2}";
                byte[] bytes = Encoding.UTF8.GetBytes(data);

                try
                {
                    await udpSender.SendAsync(bytes, bytes.Length, endpoint);
                }
                catch (Exception ex)
                {
                    Log("ERROR", $"UDP send failed: {ex.Message}");
                }

                await Task.Delay(sleepMs, token);
            }

            await TrackingModule.StopAsync();
            await Task.Delay(reconnectDelayMs, token);
        }
    }

    private async Task HttpServerLoop(CancellationToken token)
    {
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:15001/");
        listener.Start();
        Log("INFO", "HTTP server started.");

        while (!token.IsCancellationRequested)
        {
            var context = await listener.GetContextAsync();
            var request = context.Request;
            var response = context.Response;

            string result = "";

            if (request.Url.AbsolutePath == "/status")
            {
                result = TrackingModule.IsConnected ? "CONNECTED\n" : "DISCONNECTED\n";
            }
            else if (request.Url.AbsolutePath == "/command")
            {
                var cmd = request.QueryString["cmd"];
                if (cmd == "reconnect")
                {
                    await TrackingModule.StopAsync();
                    result = "RECONNECT_TRIGGERED\n";
                    Log("INFO", "Manual reconnect triggered.");
                }
                else
                {
                    result = "UNKNOWN_COMMAND\n";
                }
            }
            else
            {
                result = "INVALID_ENDPOINT\n";
            }

            byte[] buffer = Encoding.UTF8.GetBytes(result);
            response.ContentLength64 = buffer.Length;
            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        }

        listener.Stop();
    }

    private void Log(string level, string message)
    {
        string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "service.log");
        File.AppendAllText(logPath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}\r\n");
    }
}
