using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MotionTracking;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace TrackingServer
{

    internal class Program
    {
        private static readonly string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
        private static string localIP = "192.168.0.32";
        private static string remoteIP = "192.168.0.32";
        private static int port = 1601;
        private static int trackingID1 = 4;
        private static int trackingID2 = 5;
        private static float speedX = 1;
        private static string logFileName = "";
        private static int updateHz = 60;

        private static void LoadConfig()
        {
            if (!File.Exists(configPath))
            {
                return;
            }

            var json = File.ReadAllText(configPath);
            var config = JObject.Parse(json)["Tracking"];

            localIP = config["LocalIP"]?.ToString() ?? localIP;
            remoteIP = config["RemoteIP"]?.ToString() ?? remoteIP;
            port = (int?)config["SendPort"] ?? port;
            trackingID1 = (int?)config["TrackingID1"] ?? trackingID1;
            trackingID2 = (int?)config["TrackingID2"] ?? trackingID2;
            speedX = (int?)config["SpeedX"] ?? speedX;
            logFileName = config["LogFileName"]?.ToString() ?? logFileName;
            updateHz = (int?)config["UpdateHz"] ?? updateHz;
        }

        static void Main(string[] args)
        {
            LoadConfig();

            var udpSender = new UdpClient();
            var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            TrackingModule.Start(1, remoteIP, localIP, trackingID1, trackingID2, logFileName);

            int targetHz = 60;
            int sleepMs = 1000 / targetHz;

            Console.WriteLine($"Tracking server started at {targetHz}Hz. Press Enter to quit.");
            Task.Run(() =>
            {
                while (true)
                {
                    var status = TrackingModule.GetMotionState();
                    var speed = TrackingModule.GetWalkingSpeed();

                    string data = $"{status},{speed}";
                    byte[] bytes = Encoding.UTF8.GetBytes(data);
                    udpSender.Send(bytes, bytes.Length, endpoint);

                    Thread.Sleep(sleepMs); // 고정된 주기 유지
                }
            });

            TrackingModule.Stop();
            udpSender.Close();
            Console.ReadLine();
        }
    }
}
