using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace TrackingMonitorGUI
{
    public enum MoveState
    {
        Idle,
        SneakWalk,
        StationaryWalk,
        StationaryRun,
        FreeWalk
    }


    public partial class MainForm : Form
    {
        private int port = 1601;
        private string multicastGroup = "239.0.0.222";
        private readonly string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

        private UdpClient udpClient;
        private Dictionary<(int serverId, int rigidBodyId), RigidBodyState> rigidBodyStates = new Dictionary<(int, int), RigidBodyState>();
        private System.Windows.Forms.Timer refreshTimer;

        struct RigidBodyState
        {
            public Vector3 position;
            public Quaternion rotation;
            public double lastTimestamp;
        }

        struct Vector3
        {
            public float x, y, z;
            public override string ToString() => $"({x:F2}, {y:F2}, {z:F2})";
        }

        struct Quaternion
        {
            public float x, y, z, w;
            public override string ToString() => $"({x:F2}, {y:F2}, {z:F2}, {w:F2})";
        }

        private void LoadConfig()
        {
            if (!File.Exists(configPath))
            {
                MessageBox.Show("appsettings.json 파일을 찾을 수 없습니다.");
                return;
            }

            var json = File.ReadAllText(configPath);
            var config = JObject.Parse(json)["Tracking"];

            multicastGroup = config["MulticastGroup"]?.ToString();
            port = (int?)config["SendPort"] ?? port;
        }

        public MainForm()
        {
            InitializeComponent();
            InitUI();
            StartReceiving();
        }

        private void InitUI()
        {
            this.Text = "Tracking Monitor GUI";
            this.Width = 800;
            this.Height = 600;

            var listView = new ListView
            {
                View = View.Details,
                Dock = DockStyle.Fill,
                FullRowSelect = true
            };
            listView.Columns.Add("ServerID", 80);
            listView.Columns.Add("RigidBodyID", 100);
            listView.Columns.Add("Position", 200);
            listView.Columns.Add("Rotation", 200);
            listView.Columns.Add("Timestamp", 100);

            this.Controls.Add(listView);
            this.listView1 = listView;

            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 500; // 0.5초마다 갱신
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private ListView listView1;

        private async void StartReceiving()
        {
            LoadConfig();

            udpClient = new UdpClient();
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpClient.ExclusiveAddressUse = false;
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, port));
            udpClient.JoinMulticastGroup(IPAddress.Parse(multicastGroup));

            while (true)
            {
                try
                {
                    var result = await udpClient.ReceiveAsync();
                    ParsePacket(result.Buffer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"UDP Receive Error: {ex.Message}");
                }
            }
        }

        private void ParsePacket(byte[] data)
        {
            string json = Encoding.UTF8.GetString(data);
            var obj = JObject.Parse(json);

            var frameSet = obj["frameSet"];
            if (frameSet == null) return;

            foreach (var frame in frameSet)
            {
                int serverId = (int)frame["serverId"];
                double timestamp = (double)frame["timestamp"];
                if (serverId == -1)
                {
                    //MoveState current_status = (MoveState)(int)frame["state"];
                    int current_status = (int)frame["state"];
                    float current_speed = (float)frame["speed"];
                    rigidBodyStates[(serverId, 0)] = new RigidBodyState
                    {
                        position = new Vector3 { x = current_status, y = current_speed, z = 0 },
                        rotation = new Quaternion { x = 0, y = 0, z = 0, w = 0 },
                        lastTimestamp = timestamp
                    };
                }
                else
                {
                    var rigidBodies = frame["rigidBodies"];
                    if (rigidBodies == null) continue;

                    foreach (var rb in rigidBodies)
                    {
                        int id = (int)rb["id"];
                        float x = (float)rb["x"];
                        float y = (float)rb["y"];
                        float z = (float)rb["z"];
                        float qx = (float)rb["qx"];
                        float qy = (float)rb["qy"];
                        float qz = (float)rb["qz"];
                        float qw = (float)rb["qw"];

                        rigidBodyStates[(serverId, id)] = new RigidBodyState
                        {
                            position = new Vector3 { x = x, y = y, z = z },
                            rotation = new Quaternion { x = qx, y = qy, z = qz, w = qw },
                            lastTimestamp = timestamp
                        };
                    }
                }
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (var kvp in rigidBodyStates)
            {
                var (serverId, rigidBodyId) = kvp.Key;
                var state = kvp.Value;

                var item = new ListViewItem(new[]
                {
                    serverId.ToString(),
                    rigidBodyId.ToString(),
                    state.position.ToString(),
                    state.rotation.ToString(),
                    state.lastTimestamp.ToString("F2")
                });

                listView1.Items.Add(item);
            }

            listView1.EndUpdate();
        }
    }
}
