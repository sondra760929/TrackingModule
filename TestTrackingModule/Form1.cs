using MotionTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTrackingModule
{
    public partial class Form1 : Form
    {
        int current_cast_mode = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMoveOffsetUpdate_Click(object sender, EventArgs e)
        {
            //TrackingModule.SetMovementThreshold(float.Parse(tbMoveOffset.Text));
        }

        private void btnWalkOffsetUpdate_Click(object sender, EventArgs e)
        {
            //TrackingModule.SetStepHeightThreshold(float.Parse(tbWalkOffset.Text));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            TrackingModule.Start(current_cast_mode, tbServerIP.Text, tbLocalIP.Text, int.Parse(tbLeftRBID.Text), int.Parse(tbRightRBID.Text));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            TrackingModule.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFrameNo.Text = $"Frame No: {TrackingModule.GetFrameNumber()}";
            lblTimeStamp.Text = $"Time Stamp: {TrackingModule.GetTimeStamp()}";
            lblSpeed.Text = $"Speed: {TrackingModule.GetWalkingSpeed()}";
            lblState.Text = $"Status: {TrackingModule.GetMotionState()}";
            lblCount.Text = $"Count: {TrackingModule.GetStepCount()}";
            lblValue.Text = $"{TrackingModule.GetStepInterval()} / {TrackingModule.GetMaxFootHeight()} / {TrackingModule.GetMaxStride()}";

            List<string> output = TrackingModule.GetOutputList();
            for(int i = 0; i < output.Count; i++)
            {
                lbOutput.Items.Insert(0, output[i]);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                current_cast_mode = 0;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                current_cast_mode = 1;
                radioButton1.Checked = false;
                radioButton3.Checked = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                current_cast_mode = 2;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
        }
    }
}
