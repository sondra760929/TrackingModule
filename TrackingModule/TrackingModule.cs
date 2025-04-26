using NatNetML;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace MotionTracking
{
    public static class TrackingModule
    {
        private static MotionAnalyzer analyzer = new MotionAnalyzer();
        private static NatNetClientML m_NatNet;
        private static ServerDescription desc = new ServerDescription();

        private static int leftRigidId = 0;
        private static int rightRigidId = 0;

        private static ConcurrentQueue<MarkerData> frameQueue = new ConcurrentQueue<MarkerData>();
        private static CancellationTokenSource cts;

        private static bool connected = false;
        public static bool IsConnected => connected;

        public static int LastFrameNumber { get; private set; } = -1;
        public static double LastTimestamp { get; private set; } = 0.0;

        public static async Task StartAsync(int cast_mode, string serverIp, string localIp, int left_rigid_id, int right_rigid_id, string log_file_name)
        {
            analyzer.SetLogFile(log_file_name);
            leftRigidId = left_rigid_id;
            rightRigidId = right_rigid_id;

            m_NatNet = new NatNetClientML();
            m_NatNet.OnFrameReady += OnFrameReady;

            await ConnectAsync(cast_mode, serverIp, localIp);

            cts = new CancellationTokenSource();
            _ = Task.Run(() => ProcessFramesAsync(cts.Token));
        }

        public static async Task StopAsync()
        {
            cts?.Cancel();
            await Task.Delay(100);
            Disconnect();
        }

        public static MoveState GetMotionState() => analyzer.GetState();
        public static float GetWalkingSpeed() => analyzer.GetSpeed();

        public static (int frameNumber, double timestamp, MoveState state, float speed) GetLatestData()
        {
            return (LastFrameNumber, LastTimestamp, GetMotionState(), GetWalkingSpeed());
        }

        private static async Task ConnectAsync(int type, string serverIp, string localIp)
        {
            var connectParams = new NatNetClientML.ConnectParams
            {
                ServerAddress = serverIp,
                LocalAddress = localIp,
                ConnectionType = (type == 1) ? ConnectionType.Multicast : ConnectionType.Unicast
            };

            int result = m_NatNet.Connect(connectParams);
            if (result != 0)
            {
                connected = false;
                throw new Exception("NatNet client connection failed.");
            }

            if (m_NatNet.GetServerDescription(desc) != 0)
            {
                connected = false;
                throw new Exception("Failed to get server description.");
            }

            connected = true;
            await Task.CompletedTask;
        }

        private static void Disconnect()
        {
            try
            {
                m_NatNet?.Disconnect();
            }
            catch { }
            connected = false;
        }

        private static void OnFrameReady(FrameOfMocapData data, NatNetClientML client)
        {
            if (data == null) return;

            var marker = new MarkerData
            {
                iFrame = data.iFrame,
                Timestamp = data.fTimestamp
            };

            for (int i = 0; i < data.nRigidBodies; i++)
            {
                var rb = data.RigidBodies[i];
                if (rb != null && rb.Tracked)
                {
                    if (rb.ID == leftRigidId)
                        marker.LeftFoot = new Vector3Struct(rb.x, rb.y, rb.z);
                    else if (rb.ID == rightRigidId)
                        marker.RightFoot = new Vector3Struct(rb.x, rb.y, rb.z);
                }
            }

            marker.Center = (marker.LeftFoot + marker.RightFoot) / 2f;
            frameQueue.Enqueue(marker);
        }

        private static async Task ProcessFramesAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                while (frameQueue.TryDequeue(out var marker))
                {
                    LastFrameNumber = marker.iFrame;
                    LastTimestamp = marker.Timestamp;
                    analyzer.AddData(marker);
                }
                await Task.Delay(5, token);
            }
        }
    }
}
