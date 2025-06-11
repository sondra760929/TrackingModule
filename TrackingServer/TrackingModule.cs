using NatNetML;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MotionTracking
{
    public class TrackingModule
    {
        private MotionAnalyzer analyzer = new MotionAnalyzer();
        private NatNetClientML m_NatNet;
        private ServerDescription desc = new ServerDescription();

        private int leftRigidId = 0;
        private int rightRigidId = 0;

        private ConcurrentQueue<MarkerData> frameQueue = new ConcurrentQueue<MarkerData>();
        private CancellationTokenSource cts;

        private bool connected = false;
        public bool IsConnected => connected;

        public bool IsUpdated = false;

        public int LastFrameNumber { get; private set; } = -1;
        public double LastTimestamp { get; private set; } = 0.0;

        private Dictionary<int, RigidBodyData> latestRigidBodies = new Dictionary<int, RigidBodyData>();
        private object rigidBodyLock = new object();

        private class RigidBodyData
        {
            public float x, y, z;
            public float qx, qy, qz, qw;
        }

        public async Task StartAsync(int cast_mode, string serverIp, string localIp, int left_rigid_id = 0, int right_rigid_id = 0, string log_file_name = "", ushort serverCommandPort = 1510, ushort serverDataPort = 1511)
        {
            analyzer.SetLogFile(log_file_name);
            leftRigidId = left_rigid_id;
            rightRigidId = right_rigid_id;

            m_NatNet = new NatNetClientML();
            m_NatNet.OnFrameReady += OnFrameReady;

            await ConnectAsync(cast_mode, serverIp, localIp, serverCommandPort, serverDataPort);

            cts = new CancellationTokenSource();
            _ = Task.Run(() => ProcessFramesAsync(cts.Token));
        }

        public async Task StopAsync()
        {
            cts?.Cancel();
            await Task.Delay(100);
            Disconnect();
        }

        public MoveState GetMotionState() => analyzer.GetState();
        public float GetWalkingSpeed() => analyzer.GetSpeed();

        public (int frameNumber, double timestamp, MoveState state, float speed) GetLatestData()
        {
            return (LastFrameNumber, LastTimestamp, GetMotionState(), GetWalkingSpeed());
        }

        private async Task ConnectAsync(int type, string serverIp, string localIp, ushort serverCommandPort = 1510, ushort serverDataPort = 1511)
        {
            var connectParams = new NatNetClientML.ConnectParams
            {
                ServerAddress = serverIp,
                LocalAddress = localIp,
                ConnectionType = (type == 1) ? ConnectionType.Multicast : ConnectionType.Unicast,
                ServerCommandPort = serverCommandPort,
                ServerDataPort = serverDataPort
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

        private void Disconnect()
        {
            try
            {
                m_NatNet?.Disconnect();
            }
            catch { }
            connected = false;
        }

        private void OnFrameReady(FrameOfMocapData data, NatNetClientML client)
        {
            if (data == null) return;

            var marker = new MarkerData
            {
                iFrame = data.iFrame,
                Timestamp = data.fTimestamp
            };

            lock (rigidBodyLock)
            {
                latestRigidBodies.Clear();
                for (int i = 0; i < data.nRigidBodies; i++)
                {
                    var rb = data.RigidBodies[i];
                    if (rb != null && rb.Tracked)
                    {
                        latestRigidBodies[rb.ID] = new RigidBodyData
                        {
                            x = rb.x,
                            y = rb.y,
                            z = rb.z,
                            qx = rb.qx,
                            qy = rb.qy,
                            qz = rb.qz,
                            qw = rb.qw
                        };

                        if (rb.ID == leftRigidId)
                            marker.LeftFoot = new Vector3Struct(rb.x, rb.y, rb.z);
                        else if (rb.ID == rightRigidId)
                            marker.RightFoot = new Vector3Struct(rb.x, rb.y, rb.z);
                    }
                }
                LastFrameNumber = data.iFrame;
                LastTimestamp = data.fTimestamp;
            }
            IsUpdated = true;

            if (leftRigidId != 0 && rightRigidId != 0)
            {
                marker.Center = (marker.LeftFoot + marker.RightFoot) / 2f;
                frameQueue.Enqueue(marker);
            }
        }
        private async Task ProcessFramesAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                while (frameQueue.TryDequeue(out var marker))
                {
                    analyzer.AddData(marker);
                }
                await Task.Delay(5, token);
            }
        }

        public string GetRigidBodiesJson(int serverId)
        {
            var result = new
            {
                serverId = serverId,
                frameNumber = LastFrameNumber,
                timestamp = LastTimestamp,
                rigidBodies = new List<object>()
            };

            lock (rigidBodyLock)
            {
                foreach (var pair in latestRigidBodies)
                {
                    result.rigidBodies.Add(new
                    {
                        id = pair.Key,
                        x = pair.Value.x,
                        y = pair.Value.y,
                        z = pair.Value.z,
                        qx = pair.Value.qx,
                        qy = pair.Value.qy,
                        qz = pair.Value.qz,
                        qw = pair.Value.qw
                    });
                }
            }

            return JsonConvert.SerializeObject(result);
        }

    }
}
