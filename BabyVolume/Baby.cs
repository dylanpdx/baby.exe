using BabyVolume.Properties;
using CSCore.CoreAudioAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BabyVolume
{
    public partial class Baby : Form
    {
        static Image[] babyFaces = new Image[] { Resources._00, Resources._01 , Resources._02 , Resources._03 ,
            Resources._04, Resources._05, Resources._06, Resources._07, Resources._08, Resources._09,Resources._10,
        Resources._11,Resources._12,Resources._13,Resources._14,Resources._15,Resources._16,Resources._17};

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        static AudioSessionManager2 sessmgr;
        static AudioSessionEnumerator sessenum;

        float thresh = 100;


        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Baby()
        {
            InitializeComponent();
        }

        public static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private static float getHighestVol()
        {
            if (sessmgr == null)
                return 0;
            if (sessenum == null)
                sessenum = sessmgr.GetSessionEnumerator();
            float highest = 0;
            foreach (var session in sessenum)
            {
                using (var audioMeterInformation = session.QueryInterface<AudioMeterInformation>())
                {
                    float peak = audioMeterInformation.GetPeakValue();
                    if (peak > highest)
                        highest = peak;
                }
            }

            return highest;
        }

        private static AudioSessionManager2 GetDefaultAudioSessionManager2(DataFlow dataFlow)
        {
            using (var enumerator = new MMDeviceEnumerator())
            {
                using (var device = enumerator.GetDefaultAudioEndpoint(dataFlow, Role.Multimedia))
                {
                    var sessionManager = AudioSessionManager2.FromMMDevice(device);
                    return sessionManager;
                }
            }
        }

        private void pollTimer_Tick(object sender, EventArgs e)
        {
            float highest = getHighestVol();
            highest *= (thresh/100);
            int babyIndex = (int)(highest * (babyFaces.Length - 1));
            if (babyIndex > babyFaces.Length - 1)
                babyIndex = babyFaces.Length - 1;
            pictureBox1.Image = babyFaces[babyIndex];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                sessmgr = GetDefaultAudioSessionManager2(DataFlow.Render);
            }).Start();
        }

        private void Baby_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                TextTimeoutTimer.Stop();
                TextTimeoutTimer.Start();
                VolText.Visible = true;
                thresh += 10f;
                thresh = Clamp(thresh,50, 200);
                VolText.Text = "Sensitivity: " + ((int)thresh)+"%";
            }
            if (e.KeyCode == Keys.Down)
            {
                TextTimeoutTimer.Stop();
                TextTimeoutTimer.Start();
                VolText.Visible = true;
                thresh -= 10f;
                thresh = Clamp(thresh, 50, 200);
                VolText.Text = "Sensitivity: " + ((int)thresh) + "%";
            }else if (e.KeyCode == Keys.Space)
            {
                TextTimeoutTimer.Stop();
                TextTimeoutTimer.Start();
                VolText.Text = "by dylanpdx#5558";
            }
        }

        private void TextTimeoutTimer_Tick(object sender, EventArgs e)
        {
            VolText.Visible = false;
        }
    }
}
