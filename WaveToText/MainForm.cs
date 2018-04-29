using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WaveLib;
using WaveToText.Helper;
using WaveToText.Models;
using System.Linq;

namespace WaveToText {
    public partial class MainForm : MetroForm {
        IWaveControl wave;
        //private static string CONSTR = ConfigurationManager.ConnectionStrings["conStr"].ToString();
        private static string CONSTR = ConfigurationManager.ConnectionStrings["mySqlConStr"].ToString();
        private DataRow _currentProvince;//当前省份；
        private DataRow _currentCity;//当前市
        private DataRow _currentAttr;//当前景点
        private List<CityModel> _citys;//城市列表
        private List<ProvinceModel> _provinces;//省份列表
        private List<AttractionModel> _attractions;//景点列表
        private bool _isSelect = false;

        public MainForm() {
            InitializeComponent();
            this.StyleManager = this.metroStyleManager1;
            wave = new Wave();
            wave.ErrorEvent += new ErrorEventHandle(wave_ErrorEvent);
            wave.SavedFile = AppDomain.CurrentDomain.BaseDirectory + "aaa.wav";
            wave.RecordQuality = Quality.Height;
            InitMap();
        }

        #region 公共
        private void MainForm_Load(object sender, EventArgs e) {
            GetDatas();
            InitTreeView();
        }

        /// <summary>
        /// 选择景点列表中的节点之后，设置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            if (!_isSelect) {
                _isSelect = true;
                return;
            }
            var node = this.treeView1.SelectedNode;
            var tag = node.Tag;
            ProvinceModel pro = tag as ProvinceModel;
            if (pro != null) {
                this.webBrowser1.Document.InvokeScript("SetCity", new object[] { pro.Name });
                return;
            }
            CityModel city = tag as CityModel;
            if (city != null) {
                this.webBrowser1.Document.InvokeScript("SetCity", new object[] { city.Name });
                return;
            }
            AttractionModel attra = tag as AttractionModel;
            if (attra != null) {
                SetAttraction(attra);
                return;
            }
        }

        #endregion

        #region 景点列表
        /// <summary>
        /// 初始化景点列表
        /// </summary>
        private void InitTreeView() {
            if (_provinces == null || _provinces.Count == 0) {
                this.treeView1.Nodes.Clear();
                return;
            }
            foreach (var pro in _provinces) {
                if (pro == null) {
                    continue;
                }
                TreeNode proNode = new TreeNode(pro.Name);
                proNode.Name = pro.Name;
                proNode.Tag = pro;
                List<CityModel> citys = _citys.FindAll(p => p.ProvinceId == pro.ProvinceId);
                foreach (var city in citys) {
                    if (citys == null) {
                        continue;
                    }
                    TreeNode cityNode = new TreeNode(city.Name);
                    cityNode.Name = city.Name;
                    cityNode.Tag = city;
                    List<AttractionModel> attras = _attractions.FindAll(p => p.CityId == city.CityId);
                    foreach (var attra in attras) {
                        if (attras == null) {
                            continue;
                        }
                        TreeNode attraNode = new TreeNode(attra.AttractionName);
                        attraNode.Name = attra.AttractionName;
                        attraNode.Tag = attra;
                        cityNode.Nodes.Add(attraNode);
                    }
                    proNode.Nodes.Add(cityNode);
                }
                this.treeView1.Nodes.Add(proNode);
            }
        }

        /// <summary>
        /// 获取城市。省份和景点列表
        /// </summary>
        private void GetDatas() {
            _attractions = GetAttractions();
            _citys = GetCity();
            _provinces = GetProvince();
        }

        /// <summary>
        /// 获取省份信息
        /// </summary>
        /// <returns></returns>
        private List<ProvinceModel> GetProvince() {
            var dt = GetWholeData("Province");
            if (dt == null || dt.Rows.Count == 0) {
                return null;
            }
            return DataTableHelper.ToList<ProvinceModel>(dt);
        }

        /// <summary>
        /// 获取城市信息
        /// </summary>
        /// <returns></returns>
        private List<CityModel> GetCity() {
            var dt = GetWholeData("City");
            if (dt == null || dt.Rows.Count == 0) {
                return null;
            }
            return DataTableHelper.ToList<CityModel>(dt);
        }

        /// <summary>
        /// 获取景点信息
        /// </summary>
        /// <returns></returns>
        private List<AttractionModel> GetAttractions() {
            var dt = GetWholeData("Attraction");
            if (dt == null || dt.Rows.Count == 0) {
                return null;
            }
            return DataTableHelper.ToList<AttractionModel>(dt);
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
                    ShowResult(text);
                } catch (Exception) {

                    lblMsg.Text = "无法识别";
                }


                btnWav.Text = "录音";
            }
        }
        public List<string> GetTextLists(string text) {
            if (string.IsNullOrEmpty(text)) {
                return null;
            }
            if (text.Contains("，")) {
                return text.Split('，').ToList<string>();
            }
            if (text.Contains(",")) {
                return text.Split(',').ToList<string>();
            }
            return new List<string>() { text };
        }

        private void ShowResult(string text) {
            ImageManager imageManager = new ImageManager();
            var list = GetTextLists(text);
            AttractionModel attra = GetSimilarAttraction(list);
            SetAttraction(attra);
            if (attra ==null) {
                return;
            }
            var nodes = this.treeView1.Nodes.Find(attra.AttractionName, true);
            if (nodes == null || nodes.Length == 0) {
                return;
            }
            var node = nodes[0];
            _isSelect = false;
            this.treeView1.SelectedNode = node; 
        }

        /// <summary>
        /// 模糊查找景点信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private AttractionModel GetSimilarAttraction(List<string> list) {
            if (list == null || list.Count == 0) {
                return null;
            }
            try {
                using (MySqlConnection conn = new MySqlConnection(CONSTR)) {
                    conn.Open();
                    foreach (var text in list) {

                        var sql = "select * from Attraction WHERE "
                                 + "AttractionName LIKE @Text"
                                 + " or AttractionDescription LIKE @Text";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Text","%"+text+"%");
                        MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        ada.Fill(dt);
                        if (dt == null || dt.Rows.Count == 0) {
                            continue;
                        }
                        var result = DataTableHelper.ToList<AttractionModel>(dt);
                        if (result == null || result.Count == 0) {
                            continue;
                        }
                        conn.Close();
                        return result[0];
                    }
                    conn.Close();
                    return null;
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //展示图片
        private void ShowImages(Dictionary<string, Image> images) {
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

        #region map

        /// <summary>
        /// 初始化地图
        /// </summary>
        private void InitMap() {
            this.webBrowser1.Url = new Uri(Path.Combine(Application.StartupPath, "HttpMap/BMap.html"));
        }

        /// <summary>
        /// 设置景点信息
        /// </summary>
        /// <param name="attra"></param>
        /// <param name="row"></param>
        private void SetAttraction(AttractionModel attra) {
            if (attra == null) {
                this.txtboxAttractionInfo.Text = "";
                this.listView1.Items.Clear();
                return;
            }
            this.webBrowser1.Document.InvokeScript("LocalSearch", new object[] { attra.AttractionName });
            this.txtboxAttractionInfo.Text = string.Format("{0}/r{1}", attra.AttractionName, attra.AttractionDescription);
            SetImages(attra);
        }

        /// <summary>
        /// 设置图片
        /// </summary>
        /// <param name="attra"></param>
        private void SetImages(AttractionModel attra) {
            if (attra == null) {
                this.listView1.Items.Clear();
                return;
            }
            ImageManager imageManager = new ImageManager();
            var images = imageManager.GetImagesById(attra.AttractionId);
            ShowImages(images);
        }

        #endregion

        #region 添加景点
        private void btnAdd_Click(object sender, EventArgs e) {
            using (AddAttrForm form = new AddAttrForm(_provinces, _citys)) {
                form.ShowDialog();
                if (form.DialogResult == System.Windows.Forms.DialogResult.OK) {
                    InitTreeView();
                }
            }
        }
        #endregion

    }
}
