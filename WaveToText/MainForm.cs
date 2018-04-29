using GMap.NET;
using GMap.NET.MapProviders;
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
        private List<string> _files = new List<string>();//图片地址集合
        private DataRow _currentProvince;//当前省份；
        private DataRow _currentCity;//当前市
        private DataRow _currentAttr;//当前景点
        public MainForm() {
            InitializeComponent();
            this.StyleManager = this.metroStyleManager1;
            wave = new Wave();
            wave.ErrorEvent += new ErrorEventHandle(wave_ErrorEvent);
            wave.SavedFile = AppDomain.CurrentDomain.BaseDirectory + "aaa.wav";
            wave.RecordQuality = Quality.Height;
            InitMap();
            this.tabCtrl.TabPages.Remove(this.tbPgAddAttr);
        }

        #region 公共
        private void MainForm_Load(object sender, EventArgs e) {
            InitTreeView();
        }

        /// <summary>
        /// 选择景点列表中的节点之后，设置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            var node = this.treeView1.SelectedNode;
            DataRow row = node.Tag as DataRow;
            if (row["AttractionId"] != null) {
                var attra = Convert.ToInt32(row["AttractionId"]);
                SetAttraction(attra, row);
                return;
            }
            if (row["cityId"] != null) {
                var city = Convert.ToInt32(row["cityId"]);
                SetCity(city, row);
                var parentNode = node.Parent.Tag as DataRow;
                if (parentNode ==null) {
                    return;
                }
                SetProvince( parentNode);
                return;
            }
        }

        #endregion

        #region 景点列表
        /// <summary>
        /// 初始化景点列表
        /// </summary>
        private void InitTreeView() {
            var attrDt = GetAttractions();
            var cityDt = GetCity();
            var proDt = GetProvince();
            foreach (DataRow pro in proDt.Rows) {
                if (pro == null) {
                    continue;
                }
                var node = new TreeNode(pro["name"].ToString());
                node.Tag = pro;
                foreach (DataRow cityRow in cityDt.Rows) {
                    if (cityRow == null) {
                        continue;
                    }
                    var cityNode = new TreeNode(cityRow["name"].ToString());
                    cityNode.Tag = cityRow;
                    foreach (DataRow item in attrDt.Rows) {
                        if (item == null) {
                            continue;
                        }
                        var attrNode = new TreeNode(item["AttractionName"].ToString());
                        attrNode.Tag = item;
                        cityNode.Nodes.Add(attrNode);
                    }
                    node.Nodes.Add(cityNode);
                }
                this.treeView1.Nodes.Add(node);
            }
        }


        /// <summary>
        /// 获取省份信息
        /// </summary>
        /// <returns></returns>
        private DataTable GetProvince() {
            return GetWholeData("Province");
        }

        /// <summary>
        /// 获取城市信息
        /// </summary>
        /// <returns></returns>
        private DataTable GetCity() {
            return GetWholeData("City");
        }

        /// <summary>
        /// 获取景点信息
        /// </summary>
        /// <returns></returns>
        private DataTable GetAttractions() {
            return GetWholeData("Attraction");
        }

        /// <summary>
        /// 从数据库获取某张表格
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private DataTable GetWholeData(string tableName) {
            using (MySqlConnection conn = new MySqlConnection(CONSTR)) {
                conn.Open();
                var sql = string.Format("select * from {0}", tableName);
                var cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        #endregion

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

        //保存到数据
        private void SaveFileToDB(byte[] bytes, string filePath,int id) {
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
                string sql = "insert into Image(ImageName,ImageContent,AttractionId) values(@imageName,@imageContent,@AttractionId)";
                MySqlParameter[] parameter = { new MySqlParameter("@imageName", fileName),
                                           new MySqlParameter("@imageContent",bytes),
                                             new MySqlParameter("@AttractionId",id)};
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddRange(parameter);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        #region Gmap
         
        /// <summary>
        /// 初始化地图
        /// </summary>
        private void InitMap() {
            this.bMap1.EnableScrollWheelZoom();
             
        }

        /// <summary>
        /// 设置景点信息
        /// </summary>
        /// <param name="attra"></param>
        /// <param name="row"></param>
        private void SetAttraction(int attra, DataRow row) {
            SetCurrentAttraction(attra, row);
            //this.gMapControl1.Position = new PointLatLng(Convert.ToDouble(row["PositionX"]), Convert.ToDouble(row["PositionY"]));
            //this.gMapControl1.Update();
        }

        #endregion

        #region 添加景点
        /// <summary>
        /// 检查输入
        /// </summary>
        /// <returns></returns>
        private bool CheckInput() {
            if (_files == null || _files.Count == 0) {
                MessageBox.Show("请选择景点图片！");
                return false;
            }
            if (string.IsNullOrEmpty(this.lblProvince.Text) || string.IsNullOrEmpty(this.lblCity.Text)) {
                MessageBox.Show("请选择景点地址！");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtBoxAttractionName.Text) || string.IsNullOrEmpty(this.txtBoxAttractionDescription.Text)) {
                MessageBox.Show("请输入景点信息！");
                return false;
            }
            if (string.IsNullOrEmpty(this.lblX.Text) || string.IsNullOrEmpty(this.lblY.Text)) {
                MessageBox.Show("请选择景点坐标！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 保存景点信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e) {
            if (!CheckInput()) {
                return;
            }

            this.lblText1.Text = "正在保存中，请稍后...";
            string errFile = "";
            try {
                int attractionId = AddAttraction();
                if (attractionId == 0) {
                    this.lblText1.Text = "保存失败！";
                    return;
                }
                foreach (string filePath in _files) {
                    errFile = filePath;
                    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, (int)fs.Length);
                    SaveFileToDB(bytes, filePath, attractionId);
                }
                this.lblText1.Text = "保存成功！";
            } catch (Exception ex) {
                this.lblText1.Text = string.Format("{0}图片保存失败！错误信息：{1}", errFile, ex.Message);
            }
        }
         
        /// <summary>
        /// 选择景点图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e) {
            this.textBox1.Text = "";
            _files.Clear();
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
                        _files.Add(fileName);
                    }
                }
            }
        }

        /// <summary>
        /// 双击鼠标时获取地图坐标，添加景点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gMapControl1_DoubleClick(object sender, EventArgs e) {
            //var position = this.gMapControl1.Position;
            //this.lblX.Text = position.Lat.ToString();
            //this.lblY.Text = position.Lng.ToString();
            this.tabCtrl.TabPages.Add(this.tbPgAddAttr);
            this.tbPgAddAttr.Select();
        }

        /// <summary>
        /// 改变页签的话，隐藏添加景点页签，只有在地图上双击鼠标时才能添加景点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabCtrl_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.tabCtrl.SelectedTab == this.tbPgAddAttr) {
                return;
            }
            this.tbPgAddAttr.Hide();
        }

        /// <summary>
        /// 设置当前省份
        /// </summary>
        /// <param name="province"></param>
        /// <param name="row"></param>
        private void SetProvince( DataRow row) {
            if (row == null) {
                _currentProvince = null;
                this.lblProvince.Text = "";
                return;
            }
            var province = Convert.ToInt32(row["provinceId"]);

            _currentProvince = row;
            this.lblProvince.Text = row["name"].ToString();
        }

        /// <summary>
        /// 设置当前市
        /// </summary>
        /// <param name="city"></param>
        /// <param name="row"></param>
        private void SetCity(int city, DataRow row) {
            if (row == null) {
                _currentCity = null;
                this.lblCity.Text = "";
                return;
            }
            _currentCity = row;
            this.lblCity.Text = row["name"].ToString();
        }

        /// <summary>
        /// 设置当前景点
        /// </summary>
        /// <param name="attra"></param>
        /// <param name="row"></param>
        private void SetCurrentAttraction(int attra, DataRow row) {
            if (row == null) {
                _currentAttr = null;
                return;
            }
            _currentAttr = row;
        }


        /// <summary>
        /// 新增一条景点信息并返回id
        /// </summary>
        /// <returns></returns>
        private int AddAttraction() {
            var attrName = this.txtBoxAttractionName.Text;
            var attrDes = this.txtBoxAttractionDescription.Text;
            var x = Convert.ToDouble(this.lblX.Text);
            var y = Convert.ToDouble(this.lblY.Text);
            var cityId = Convert.ToInt32(_currentCity["cityId"]);
            var suc = AddAttraction(attrName, attrDes, x, y);
            if (!suc) {
                return 0;
            }
            var id = GetAttrId();
            return id;
        }

        /// <summary>
        /// 获取刚新增的景点的Id
        /// </summary>
        /// <returns></returns>
        private int GetAttrId() {
            try {
                using (MySqlConnection conn = new MySqlConnection(CONSTR)) {
                    conn.Open();
                    var sql = "SELECT LAST_INSERT_ID()";
                    var cmd = new MySqlCommand(sql, conn);
                    var id = cmd.ExecuteScalar();
                    conn.Close();
                    if (id == null) {
                        return 0;
                    }
                    var newId = Convert.ToInt32(id);
                    return newId;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// 新增一条景点信息
        /// </summary>
        /// <param name="attrName"></param>
        /// <param name="attrDes"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool AddAttraction(string attrName, string attrDes, double x, double y) {
            if (string.IsNullOrEmpty(attrName) || string.IsNullOrEmpty(attrDes) || _currentCity == null || _currentCity["cityId"] == null) {
                return false;
            }
            try {
                using (MySqlConnection conn = new MySqlConnection(CONSTR)) {
                    conn.Open();
                    var sql = "insert into attraction (AttractionName,AttractionDescription,PositionX,PositionY,CityId)"
                              + "VALUES(@AttractionName,@AttractionDescription,@PositionX,@PositionY,@CityId)";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@AttractionName", attrName);
                    cmd.Parameters.AddWithValue("@AttractionDescription", attrDes);
                    cmd.Parameters.AddWithValue("@PositionX", x);
                    cmd.Parameters.AddWithValue("@PositionY", y);
                    cmd.Parameters.AddWithValue("@CityId", Convert.ToInt32(_currentCity["cityId"]));
                    var i = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (i <= 0) {
                        return false;
                    }
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        #endregion

    }
}
