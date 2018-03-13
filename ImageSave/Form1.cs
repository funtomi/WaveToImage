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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSave {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private static string CONSTR = ConfigurationManager.ConnectionStrings["conStr"].ToString();
        private List<string> files = new List<string>();//图片地址集合

        private void btnOpen_Click(object sender, EventArgs e) {
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
                        this.textBox1.Text += fileName;
                        files.Add(fileName);
                    } 
                }
            } 
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (files==null||files.Count==0) {
                return;
            }
            this.label1.Text = "正在保存中，请稍后...";
            string errFile = "";
            try {
                foreach (string filePath in files) {
                    errFile = filePath;
                    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, (int)fs.Length);
                    SaveToDB(bytes,filePath);
                }
                this.label1.Text = "保存成功！";
            } catch (Exception ex) {
                this.label1.Text = string.Format("{0}图片保存失败！错误信息：{1}",errFile,ex.Message);
            }
        }

        //保存到数据
        private void SaveToDB(byte[] bytes,string filePath) {
            if (bytes==null||bytes.Length==0) {
                return;
            }
            var fileName = Path.GetFileName(filePath);
            using (SqlConnection con = new SqlConnection (CONSTR)) {
                con.Open();
                string sql = "insert into Image(ImageName,ImageContent) values(@imageName,@imageContent)";
                SqlParameter[] parameter = { new SqlParameter("@imageName", fileName),
                                           new SqlParameter("@imageContent",bytes)};
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddRange(parameter);
                cmd.ExecuteNonQuery();
                con.Close(); 
            } 
        }
    }
}
