using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace WaveToText {
    class ImageManager {
        //private static string CONSTR = ConfigurationManager.ConnectionStrings["conStr"].ToString();
        private static string CONSTR = ConfigurationManager.ConnectionStrings["mySqlConStr"].ToString();
       
        public ImageManager() { 
        }

        public List<string> GetTextLists(string text) {
            if (string.IsNullOrEmpty(text)) {
                return null;
            }
            if (!text.Contains('，')) {
                return new List<string>() { text };
            }
            return text.Split('，').ToList<string>();
        }

        /// <summary>
        /// 通过景点ID查找图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Dictionary<string, Image> GetImagesById(int id) {
            if (id <= 0) {
                return null;
            }
            DataTable dt = new DataTable();

            try {
                using (MySqlConnection con = new MySqlConnection(CONSTR)) {
                    con.Open();
                    string sql = "select ImageName,ImageContent from Image where AttractionId= @AttractionId";
                    MySqlParameter[] parameter = { new MySqlParameter("@AttractionId", id) };
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddRange(parameter);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    con.Close();
                }
            } catch (Exception ex) {
                throw new ArgumentException(ex.Message);
            }
            Dictionary<string, Image> images = new Dictionary<string, Image>();
            if (dt == null || dt.Rows.Count == 0) {
                return null;
            }
            for (int i = 0; i < dt.Rows.Count; i++) {
                var imagebyte = dt.Rows[i]["ImageContent"] as byte[];
                var imageName = Path.GetFileNameWithoutExtension(dt.Rows[i]["ImageName"].ToString());
                MemoryStream ms = new System.IO.MemoryStream(imagebyte);
                images.Add(imageName, System.Drawing.Image.FromStream(ms));
            }

            return images;
        }
         
    }
}
