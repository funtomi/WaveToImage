using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using WaveToText.Models;

namespace WaveToText {
    public partial class AddAttrForm : MetroForm {
        public AddAttrForm() {
            InitializeComponent();
            this.StyleManager = this.metroStyleManager1;
        }
        #region 初始化

        public AddAttrForm(List<ProvinceModel> pros, List<CityModel> citys)
            : this() {
            if (pros == null || pros.Count == 0 || citys == null || citys.Count == 0) {
                MessageBox.Show("省份和城市列表为空！");
                this.Close();
                return;
            }
            _citys = citys;
            _provinces = pros;
        }
        private static string CONSTR = ConfigurationManager.ConnectionStrings["mySqlConStr"].ToString();

        private List<string> _files = new List<string>();//图片地址集合
        private List<CityModel> _citys;//城市列表
        private List<ProvinceModel> _provinces;//省份列表

        private void AddAttrForm_Load(object sender, EventArgs e) {
            InitProvinceAndCitys(_provinces, _citys);
        }

        /// <summary>
        /// 初始化城市和省份列表
        /// </summary>
        /// <param name="pros"></param>
        /// <param name="citys"></param>
        private void InitProvinceAndCitys(List<ProvinceModel> pros, List<CityModel> citys) {
            if (pros == null || pros.Count == 0) {
                this.cmboxProvince.DataSource = null;
                return;
            }
            this.cmboxProvince.DataSource = pros;
            this.cmboxProvince.DisplayMember = "Name";
            this.cmboxProvince.SelectedIndex = 0;
            if (citys == null || citys.Count == 0) {
                this.cmboxCity.DataSource = null;
                return;
            }
            var currentPro = pros[0];
            ChangeCityList(citys, currentPro);
        }

        /// <summary>
        /// 更新城市列表
        /// </summary>
        /// <param name="citys"></param>
        /// <param name="currentPro"></param>
        private void ChangeCityList(List<CityModel> citys, ProvinceModel currentPro) {
            List<CityModel> currentCitys = citys.FindAll(p => p.ProvinceId == currentPro.ProvinceId);
            if (currentCitys == null || currentCitys.Count == 0) {
                this.cmboxCity.DataSource = null;
                return;
            }
            this.cmboxCity.DataSource = currentCitys;
            this.cmboxCity.DisplayMember = "Name";
            this.cmboxCity.SelectedIndex = 0;
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
            if (this.cmboxProvince.SelectedIndex < 0 || this.cmboxCity.SelectedIndex < 0) {
                MessageBox.Show("请选择景点地址！");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtBoxAttractionName.Text) || string.IsNullOrEmpty(this.txtBoxAttractionDescription.Text)) {
                MessageBox.Show("请输入景点信息！");
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
            } finally {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        //保存到数据
        private void SaveFileToDB(byte[] bytes, string filePath, int id) {
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
                fileDialog.InitialDirectory = Path.GetFullPath(Directory.GetCurrentDirectory());
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
        /// 新增一条景点信息并返回id
        /// </summary>
        /// <returns></returns>
        private int AddAttraction() {
            var attrName = this.txtBoxAttractionName.Text;
            var attrDes = this.txtBoxAttractionDescription.Text;
            var item = this.cmboxCity.SelectedItem as CityModel;
            if (item == null) {
                return 0;
            }
            var cityId = item.CityId;
            var suc = AddAttraction(attrName, attrDes, cityId);
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
        private bool AddAttraction(string attrName, string attrDes, int cityId) {
            if (string.IsNullOrEmpty(attrName) || string.IsNullOrEmpty(attrDes)) {
                return false;
            }
            try {
                using (MySqlConnection conn = new MySqlConnection(CONSTR)) {
                    conn.Open();
                    var sql = "insert into attraction (AttractionName,AttractionDescription,CityId)"
                              + "VALUES(@AttractionName,@AttractionDescription,@CityId)";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@AttractionName", attrName);
                    cmd.Parameters.AddWithValue("@AttractionDescription", attrDes);
                    cmd.Parameters.AddWithValue("@CityId", cityId);
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

        /// <summary>
        /// 选择的省份改变时，城市列表跟着更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmboxProvince_SelectedIndexChanged(object sender, EventArgs e) {
            var pro = this.cmboxProvince.SelectedItem as ProvinceModel;
            ChangeCityList(_citys, pro);
        }

    }
}
