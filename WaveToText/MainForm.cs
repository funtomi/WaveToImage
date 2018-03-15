using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WaveLib;

namespace WaveToText {
    public partial class MainForm : MetroForm {
        IWaveControl wave;
        //private static string CONSTR = ConfigurationManager.ConnectionStrings["conStr"].ToString();
        private static string CONSTR = ConfigurationManager.ConnectionStrings["mySqlConStr"].ToString();
        private List<string> files = new List<string>();//图片地址集合
        public MainForm() {
            InitializeComponent();
            this.StyleManager = this.metroStyleManager1;
            wave = new Wave();
            wave.ErrorEvent += new ErrorEventHandle(wave_ErrorEvent);
            wave.SavedFile = AppDomain.CurrentDomain.BaseDirectory + "aaa.wav";
            wave.RecordQuality = Quality.Height;
        }

        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="e"></param>
        /// <param name="error"></param>
        private void wave_ErrorEvent(Exception e, string error) {
            MessageBox.Show(e.Message);
        }

        private void btnWav_Click(object sender, EventArgs e) {
            if (btnWav.Text == "录音") {
                btnWav.Text = "停止";
                wave.Start();
            } else {
                btnWav.Text = "转换中...";
                wave.Stop();
                try {
                    string c1 = "server_url=dev.voicecloud.cn,appid=5040a078,timeout=10000";
                    string c2 = "sub=iat,ssm=1,auf=audio/L16;rate=16000,aue=speex,ent=sms16k,rst=plain";
                    iFlyASR asr = new iFlyASR(c1, c2);
                    var text = asr.Audio2Txt(AppDomain.CurrentDomain.BaseDirectory + "aaa.wav");
                    text = text.TrimEnd('。');
                    lblMsg.Text = text;
                    ShowImages(text);
                } catch (Exception) {

                    lblMsg.Text = "无法识别";
                }


                btnWav.Text = "录音";
            }
        }

        //展示图片
        private void ShowImages(string text) {
            ImageManager imageManager = new ImageManager(text);
            var images = imageManager.GetImages();
            imageList1.Images.Clear();
            listView1.Items.Clear();
            if (images == null || images.Count == 0) {
                return;
            }
            int i = 0;
            foreach (var item in images) {
                imageList1.Images.Add(item.Value);
                listView1.Items.Add(item.Key, i);
                listView1.Items[i].ImageIndex = i;
                listView1.Items[i].Name = item.Key;
                i++;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e) {
            this.textBox1.Text = "";
            files.Clear();
            using (OpenFileDialog fileDialog = new OpenFileDialog()) {
                fileDialog.DefaultExt = " ";
                fileDialog.FileName = "openFileDialog1";
                fileDialog.Filter = "图片|*.png;*.jpeg;*.jpg";
                fileDialog.InitialDirectory = "c:\\";
                fileDialog.Multiselect = true;
                fileDialog.RestoreDirectory = true;
                if (fileDialog.ShowDialog() == DialogResult.OK) {
                    foreach (string fileName in fileDialog.FileNames) {
                        var fileName2 = Path.GetFileNameWithoutExtension(fileName); 
                        this.textBox1.Text += fileName2;
                        files.Add(fileName);
                    }
                }
            } 
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (files == null || files.Count == 0) {
                return;
            }
            this.lblText1.Text = "正在保存中，请稍后...";
            string errFile = "";
            try {
                foreach (string filePath in files) {
                    errFile = filePath;
                    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, (int)fs.Length);
                    SaveToDB(bytes, filePath);
                }
                this.lblText1.Text = "保存成功！";
            } catch (Exception ex) {
                this.lblText1.Text = string.Format("{0}图片保存失败！错误信息：{1}", errFile, ex.Message);
            }
        }

        //保存到数据
        private void SaveToDB(byte[] bytes, string filePath) {
            if (bytes == null || bytes.Length == 0) {
                return;
            }
            var fileName = Path.GetFileName(filePath);
            #region SqlServer
            //using (SqlConnection con = new SqlConnection(CONSTR)) {
            //    con.Open();
            //    string sql = "insert into Image(ImageName,ImageContent) values(@imageName,@imageContent)";
            //    SqlParameter[] parameter = { new SqlParameter("@imageName", fileName),
            //                               new SqlParameter("@imageContent",bytes)};
            //    SqlCommand cmd = new SqlCommand(sql, con);
            //    cmd.Parameters.AddRange(parameter);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}
            #endregion
            using (MySqlConnection con = new MySqlConnection(CONSTR)) {
                con.Open();
                string sql = "insert into Image(ImageName,ImageContent) values(@imageName,@imageContent)";
                MySqlParameter[] parameter = { new MySqlParameter("@imageName", fileName),
                                           new MySqlParameter("@imageContent",bytes)};
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddRange(parameter);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
