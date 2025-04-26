namespace TrackingSettingsUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtLocalIP = new System.Windows.Forms.TextBox();
            this.txtRemoteIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtTrackingID = new System.Windows.Forms.TextBox();
            this.txtTrackingID2 = new System.Windows.Forms.TextBox();
            this.txtUpdateHz = new System.Windows.Forms.TextBox();
            this.txtSpeedX = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRestartSvc = new System.Windows.Forms.Button();
            this.lblLocalIP = new System.Windows.Forms.Label();
            this.lblRemoteIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblTrackingID = new System.Windows.Forms.Label();
            this.lblClientCount = new System.Windows.Forms.Label();
            this.lblMarkerCount = new System.Windows.Forms.Label();
            this.lblUpdateHz = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtLogFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLocalIP
            // 
            this.txtLocalIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLocalIP.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLocalIP.Location = new System.Drawing.Point(427, 8);
            this.txtLocalIP.Name = "txtLocalIP";
            this.txtLocalIP.Size = new System.Drawing.Size(413, 40);
            this.txtLocalIP.TabIndex = 7;
            // 
            // txtRemoteIP
            // 
            this.txtRemoteIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemoteIP.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRemoteIP.Location = new System.Drawing.Point(427, 54);
            this.txtRemoteIP.Name = "txtRemoteIP";
            this.txtRemoteIP.Size = new System.Drawing.Size(413, 40);
            this.txtRemoteIP.TabIndex = 8;
            // 
            // txtPort
            // 
            this.txtPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPort.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPort.Location = new System.Drawing.Point(427, 100);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(413, 40);
            this.txtPort.TabIndex = 9;
            // 
            // txtTrackingID
            // 
            this.txtTrackingID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTrackingID.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTrackingID.Location = new System.Drawing.Point(427, 146);
            this.txtTrackingID.Name = "txtTrackingID";
            this.txtTrackingID.Size = new System.Drawing.Size(413, 40);
            this.txtTrackingID.TabIndex = 10;
            // 
            // txtTrackingID2
            // 
            this.txtTrackingID2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTrackingID2.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTrackingID2.Location = new System.Drawing.Point(427, 192);
            this.txtTrackingID2.Name = "txtTrackingID2";
            this.txtTrackingID2.Size = new System.Drawing.Size(413, 40);
            this.txtTrackingID2.TabIndex = 11;
            // 
            // txtUpdateHz
            // 
            this.txtUpdateHz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUpdateHz.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtUpdateHz.Location = new System.Drawing.Point(427, 238);
            this.txtUpdateHz.Name = "txtUpdateHz";
            this.txtUpdateHz.Size = new System.Drawing.Size(413, 40);
            this.txtUpdateHz.TabIndex = 12;
            // 
            // txtSpeedX
            // 
            this.txtSpeedX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSpeedX.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSpeedX.Location = new System.Drawing.Point(427, 284);
            this.txtSpeedX.Name = "txtSpeedX";
            this.txtSpeedX.Size = new System.Drawing.Size(413, 40);
            this.txtSpeedX.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(8, 376);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(413, 160);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRestartSvc
            // 
            this.btnRestartSvc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRestartSvc.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRestartSvc.Location = new System.Drawing.Point(427, 376);
            this.btnRestartSvc.Name = "btnRestartSvc";
            this.btnRestartSvc.Size = new System.Drawing.Size(413, 160);
            this.btnRestartSvc.TabIndex = 15;
            this.btnRestartSvc.Text = "Restart Service";
            this.btnRestartSvc.Click += new System.EventHandler(this.btnRestartSvc_Click);
            // 
            // lblLocalIP
            // 
            this.lblLocalIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocalIP.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLocalIP.Location = new System.Drawing.Point(8, 5);
            this.lblLocalIP.Name = "lblLocalIP";
            this.lblLocalIP.Size = new System.Drawing.Size(413, 46);
            this.lblLocalIP.TabIndex = 0;
            this.lblLocalIP.Text = "Local IP";
            this.lblLocalIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRemoteIP
            // 
            this.lblRemoteIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRemoteIP.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRemoteIP.Location = new System.Drawing.Point(8, 51);
            this.lblRemoteIP.Name = "lblRemoteIP";
            this.lblRemoteIP.Size = new System.Drawing.Size(413, 46);
            this.lblRemoteIP.TabIndex = 1;
            this.lblRemoteIP.Text = "Remote IP";
            this.lblRemoteIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPort
            // 
            this.lblPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPort.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPort.Location = new System.Drawing.Point(8, 97);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(413, 46);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Send Port";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrackingID
            // 
            this.lblTrackingID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrackingID.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTrackingID.Location = new System.Drawing.Point(8, 189);
            this.lblTrackingID.Name = "lblTrackingID";
            this.lblTrackingID.Size = new System.Drawing.Size(413, 46);
            this.lblTrackingID.TabIndex = 3;
            this.lblTrackingID.Text = "Right Tracking ID";
            this.lblTrackingID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClientCount
            // 
            this.lblClientCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClientCount.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblClientCount.Location = new System.Drawing.Point(8, 281);
            this.lblClientCount.Name = "lblClientCount";
            this.lblClientCount.Size = new System.Drawing.Size(413, 46);
            this.lblClientCount.TabIndex = 4;
            this.lblClientCount.Text = "Speed X";
            this.lblClientCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMarkerCount
            // 
            this.lblMarkerCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarkerCount.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMarkerCount.Location = new System.Drawing.Point(8, 327);
            this.lblMarkerCount.Name = "lblMarkerCount";
            this.lblMarkerCount.Size = new System.Drawing.Size(413, 46);
            this.lblMarkerCount.TabIndex = 5;
            this.lblMarkerCount.Text = "Log File Name";
            this.lblMarkerCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUpdateHz
            // 
            this.lblUpdateHz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpdateHz.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUpdateHz.Location = new System.Drawing.Point(8, 235);
            this.lblUpdateHz.Name = "lblUpdateHz";
            this.lblUpdateHz.Size = new System.Drawing.Size(413, 46);
            this.lblUpdateHz.TabIndex = 6;
            this.lblUpdateHz.Text = "Update Hz";
            this.lblUpdateHz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtLogFile, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnRestartSvc, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtSpeedX, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtUpdateHz, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtTrackingID2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtTrackingID, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtPort, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtRemoteIP, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLocalIP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMarkerCount, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblClientCount, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblTrackingID, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblLocalIP, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUpdateHz, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblPort, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblRemoteIP, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(848, 544);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // txtLogFile
            // 
            this.txtLogFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogFile.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLogFile.Location = new System.Drawing.Point(427, 330);
            this.txtLogFile.Name = "txtLogFile";
            this.txtLogFile.Size = new System.Drawing.Size(413, 40);
            this.txtLogFile.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("±¼¸²", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(8, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 46);
            this.label1.TabIndex = 17;
            this.label1.Text = "Left Tracking ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(848, 544);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Tracking Server Settings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblLocalIP;
        private System.Windows.Forms.Label lblRemoteIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblTrackingID;
        private System.Windows.Forms.Label lblClientCount;
        private System.Windows.Forms.Label lblMarkerCount;
        private System.Windows.Forms.Label lblUpdateHz;

        private System.Windows.Forms.TextBox txtLocalIP;
        private System.Windows.Forms.TextBox txtRemoteIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtTrackingID;
        private System.Windows.Forms.TextBox txtTrackingID2;
        private System.Windows.Forms.TextBox txtUpdateHz;
        private System.Windows.Forms.TextBox txtSpeedX;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRestartSvc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLogFile;
    }
}
