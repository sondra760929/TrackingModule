using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace TrackingSettingsUI
{
    public partial class Form1 : Form
    {
        private readonly string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

        public Form1()
        {
            InitializeComponent();
            LoadConfig();
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

            txtLocalIP1.Text = config["LocalIP1"]?.ToString();
            txtRemoteIP1.Text = config["RemoteIP1"]?.ToString();
            txtLocalIP2.Text = config["LocalIP2"]?.ToString();
            txtRemoteIP2.Text = config["RemoteIP2"]?.ToString();
            txtPort.Text = config["SendPort"]?.ToString();
            txtTrackingID.Text = config["TrackingID1"]?.ToString();
            txtTrackingID2.Text = config["TrackingID2"]?.ToString();
            txtUpdateHz.Text = config["UpdateHz"]?.ToString();
            txtSpeedX.Text = config["SpeedX"]?.ToString();
            txtLogFile.Text = config["LogFileName"]?.ToString();
            txtmulticastGroup.Text = config["MulticastGroup"]?.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var json = File.ReadAllText(configPath);
            var config = JObject.Parse(json);
            var tracking = config["Tracking"];

            tracking["LocalIP1"] = txtLocalIP1.Text;
            tracking["RemoteIP1"] = txtRemoteIP1.Text;
            tracking["LocalIP2"] = txtLocalIP2.Text;
            tracking["RemoteIP2"] = txtRemoteIP2.Text;
            tracking["SendPort"] = int.Parse(txtPort.Text);
            tracking["TrackingID1"] = int.Parse(txtTrackingID.Text);
            tracking["TrackingID2"] = int.Parse(txtTrackingID2.Text);
            tracking["UpdateHz"] = int.Parse(txtUpdateHz.Text);
            tracking["SpeedX"] = int.Parse(txtSpeedX.Text);
            tracking["LogFileName"] = txtLogFile.Text;
            tracking["MulticastGroup"] = txtmulticastGroup.Text;

            File.WriteAllText(configPath, config.ToString());
            MessageBox.Show("설정이 저장되었습니다.");
        }

        private void btnRestartSvc_Click(object sender, EventArgs e)
        {
        }

        private void txtRemoteIP1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLocalIP1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
