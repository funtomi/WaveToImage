using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using WaveLib;
using iFly;

namespace WaveToText
{
    public partial class Form1 : Form
    {
        IWaveControl wave;

        public Form1()
        {
            InitializeComponent();
            wave = new Wave();
            wave.ErrorEvent += new ErrorEventHandle(wave_ErrorEvent);
            wave.SavedFile = AppDomain.CurrentDomain.BaseDirectory + "aaa.wav";
            wave.RecordQuality = Quality.Height;
        }
        private void wave_ErrorEvent(Exception e, string error)
        {
            MessageBox.Show(e.Message);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (btnWav.Text == "录音")
            {
                btnWav.Text = "停止";
                wave.Start();

            }
            else
            {
                btnWav.Text = "转换中...";
                wave.Stop();
                try
                {
                    string c1 = "server_url=dev.voicecloud.cn,appid=5040a078,timeout=10000";
                    string c2 = "sub=iat,ssm=1,auf=audio/L16;rate=16000,aue=speex,ent=sms16k,rst=plain";
                    iFlyASR asr = new iFlyASR(c1, c2);
                    lblMsg.Text = asr.Audio2Txt(AppDomain.CurrentDomain.BaseDirectory + "aaa.wav");
                }
                catch (Exception)
                {

                    lblMsg.Text = "无法识别";
                }


                btnWav.Text = "录音";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
