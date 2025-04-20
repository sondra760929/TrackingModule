namespace TestTrackingModule
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbServerIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLocalIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLeftRBID = new System.Windows.Forms.TextBox();
            this.tbRightRBID = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMoveOffset = new System.Windows.Forms.TextBox();
            this.tbWalkOffset = new System.Windows.Forms.TextBox();
            this.btnMoveOffsetUpdate = new System.Windows.Forms.Button();
            this.btnWalkOffsetUpdate = new System.Windows.Forms.Button();
            this.lblFrameNo = new System.Windows.Forms.Label();
            this.lblTimeStamp = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbOutput = new System.Windows.Forms.ListBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbServerIP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbLocalIP, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbLeftRBID, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbRightRBID, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnStart, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnStop, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbMoveOffset, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbWalkOffset, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnMoveOffsetUpdate, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnWalkOffsetUpdate, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblFrameNo, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblTimeStamp, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblSpeed, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.lbOutput, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.radioButton1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.radioButton2, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.radioButton3, 2, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1449, 993);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(475, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbServerIP
            // 
            this.tbServerIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbServerIP.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbServerIP.Location = new System.Drawing.Point(487, 6);
            this.tbServerIP.Name = "tbServerIP";
            this.tbServerIP.Size = new System.Drawing.Size(475, 40);
            this.tbServerIP.TabIndex = 1;
            this.tbServerIP.Text = "127.0.0.1";
            this.tbServerIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(475, 46);
            this.label2.TabIndex = 3;
            this.label2.Text = "Local IP";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbLocalIP
            // 
            this.tbLocalIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLocalIP.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLocalIP.Location = new System.Drawing.Point(487, 52);
            this.tbLocalIP.Name = "tbLocalIP";
            this.tbLocalIP.Size = new System.Drawing.Size(475, 40);
            this.tbLocalIP.TabIndex = 4;
            this.tbLocalIP.Text = "127.0.0.1";
            this.tbLocalIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(475, 46);
            this.label3.TabIndex = 5;
            this.label3.Text = "Left RigidBody ID";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(6, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(475, 46);
            this.label4.TabIndex = 6;
            this.label4.Text = "Right RigidBody ID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbLeftRBID
            // 
            this.tbLeftRBID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLeftRBID.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLeftRBID.Location = new System.Drawing.Point(487, 98);
            this.tbLeftRBID.Name = "tbLeftRBID";
            this.tbLeftRBID.Size = new System.Drawing.Size(475, 40);
            this.tbLeftRBID.TabIndex = 7;
            this.tbLeftRBID.Text = "3";
            this.tbLeftRBID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbRightRBID
            // 
            this.tbRightRBID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRightRBID.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbRightRBID.Location = new System.Drawing.Point(487, 144);
            this.tbRightRBID.Name = "tbRightRBID";
            this.tbRightRBID.Size = new System.Drawing.Size(475, 40);
            this.tbRightRBID.TabIndex = 8;
            this.tbRightRBID.Text = "4";
            this.tbRightRBID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnStart
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnStart, 2);
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStart.Location = new System.Drawing.Point(487, 320);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(956, 94);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStop.Location = new System.Drawing.Point(6, 320);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(475, 94);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(6, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(475, 46);
            this.label5.TabIndex = 11;
            this.label5.Text = "Move Offset";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(6, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(475, 46);
            this.label6.TabIndex = 12;
            this.label6.Text = "Walk Offset";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbMoveOffset
            // 
            this.tbMoveOffset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMoveOffset.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbMoveOffset.Location = new System.Drawing.Point(487, 190);
            this.tbMoveOffset.Name = "tbMoveOffset";
            this.tbMoveOffset.Size = new System.Drawing.Size(475, 40);
            this.tbMoveOffset.TabIndex = 13;
            this.tbMoveOffset.Text = "0.2";
            this.tbMoveOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbWalkOffset
            // 
            this.tbWalkOffset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbWalkOffset.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbWalkOffset.Location = new System.Drawing.Point(487, 236);
            this.tbWalkOffset.Name = "tbWalkOffset";
            this.tbWalkOffset.Size = new System.Drawing.Size(475, 40);
            this.tbWalkOffset.TabIndex = 14;
            this.tbWalkOffset.Text = "0.03";
            this.tbWalkOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnMoveOffsetUpdate
            // 
            this.btnMoveOffsetUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveOffsetUpdate.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMoveOffsetUpdate.Location = new System.Drawing.Point(968, 190);
            this.btnMoveOffsetUpdate.Name = "btnMoveOffsetUpdate";
            this.btnMoveOffsetUpdate.Size = new System.Drawing.Size(475, 40);
            this.btnMoveOffsetUpdate.TabIndex = 15;
            this.btnMoveOffsetUpdate.Text = "Update";
            this.btnMoveOffsetUpdate.UseVisualStyleBackColor = true;
            this.btnMoveOffsetUpdate.Click += new System.EventHandler(this.btnMoveOffsetUpdate_Click);
            // 
            // btnWalkOffsetUpdate
            // 
            this.btnWalkOffsetUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnWalkOffsetUpdate.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnWalkOffsetUpdate.Location = new System.Drawing.Point(968, 236);
            this.btnWalkOffsetUpdate.Name = "btnWalkOffsetUpdate";
            this.btnWalkOffsetUpdate.Size = new System.Drawing.Size(475, 40);
            this.btnWalkOffsetUpdate.TabIndex = 16;
            this.btnWalkOffsetUpdate.Text = "Update";
            this.btnWalkOffsetUpdate.UseVisualStyleBackColor = true;
            this.btnWalkOffsetUpdate.Click += new System.EventHandler(this.btnWalkOffsetUpdate_Click);
            // 
            // lblFrameNo
            // 
            this.lblFrameNo.AutoSize = true;
            this.lblFrameNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFrameNo.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblFrameNo.Location = new System.Drawing.Point(6, 417);
            this.lblFrameNo.Name = "lblFrameNo";
            this.lblFrameNo.Size = new System.Drawing.Size(475, 28);
            this.lblFrameNo.TabIndex = 17;
            this.lblFrameNo.Text = "Frame No : ";
            this.lblFrameNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimeStamp
            // 
            this.lblTimeStamp.AutoSize = true;
            this.lblTimeStamp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimeStamp.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTimeStamp.Location = new System.Drawing.Point(487, 417);
            this.lblTimeStamp.Name = "lblTimeStamp";
            this.lblTimeStamp.Size = new System.Drawing.Size(475, 28);
            this.lblTimeStamp.TabIndex = 18;
            this.lblTimeStamp.Text = "Time Stamp : ";
            this.lblTimeStamp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSpeed.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSpeed.Location = new System.Drawing.Point(968, 417);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(475, 28);
            this.lblSpeed.TabIndex = 19;
            this.lblSpeed.Text = "Speed : ";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbOutput
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbOutput, 3);
            this.lbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbOutput.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbOutput.FormattingEnabled = true;
            this.lbOutput.ItemHeight = 24;
            this.lbOutput.Location = new System.Drawing.Point(6, 448);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(1437, 539);
            this.lbOutput.TabIndex = 20;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton1.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioButton1.Location = new System.Drawing.Point(6, 282);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(475, 32);
            this.radioButton1.TabIndex = 21;
            this.radioButton1.Text = "Unicast";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton2.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioButton2.Location = new System.Drawing.Point(487, 282);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(475, 32);
            this.radioButton2.TabIndex = 22;
            this.radioButton2.Text = "Multicast";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton3.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioButton3.Location = new System.Drawing.Point(968, 282);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(475, 32);
            this.radioButton3.TabIndex = 23;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Broadcast";
            this.radioButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1449, 993);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbServerIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLocalIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLeftRBID;
        private System.Windows.Forms.TextBox tbRightRBID;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbMoveOffset;
        private System.Windows.Forms.TextBox tbWalkOffset;
        private System.Windows.Forms.Button btnMoveOffsetUpdate;
        private System.Windows.Forms.Button btnWalkOffsetUpdate;
        private System.Windows.Forms.Label lblFrameNo;
        private System.Windows.Forms.Label lblTimeStamp;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox lbOutput;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}

