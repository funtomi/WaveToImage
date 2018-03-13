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
        private static string CONSTR = ConfigurationManager.ConnectionStrings["conStr"].ToString();
        private string _imageText = "";
        public ImageManager(string text) {
            _imageText = text;
        }

        public List<string> GetTextLists() {
            if (string.IsNullOrEmpty(_imageText)) {
                return null;
            }
            if (!_imageText.Contains('，')) {
                return new List<string>() { _imageText};
            } 
            return _imageText.Split('，').ToList<string>();
        }

        public Dictionary<string,Image> GetImages() {
            if (string.IsNullOrEmpty(_imageText)) {
                return null;
            }
            var texts = GetTextLists();
            if (texts==null||texts.Count==0) {
                return null;
            }
            Dictionary<string, Image> images = new Dictionary<string, Image>();
            foreach (var item in texts) {
                var dt = ReadImages(item);
                if (dt == null || dt.Rows.Count == 0) {
                    continue;
                }
                for (int i = 0; i < dt.Rows.Count; i++) {
                    var imagebyte = dt.Rows[i]["ImageContent"] as byte[];
                    var imageName = Path.GetFileNameWithoutExtension(dt.Rows[i]["ImageName"].ToString());
                    MemoryStream ms = new System.IO.MemoryStream(imagebyte);
                    images.Add(imageName, System.Drawing.Image.FromStream(ms));
                }
            }
           
            return images;
        }

        private DataTable ReadImages(string text) {
            try {
                using (SqlConnection con = new SqlConnection(CONSTR)) {
                    con.Open();
                    DataTable dt = new DataTable();
                    string sql = "select ImageName,ImageContent from Image where ImageName like @imageName";
                    SqlParameter[] parameter = { new SqlParameter("@imageName", "%" + text + "%") };
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddRange(parameter);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    
                    con.Close();
                    return dt; 
                } 
            } catch (Exception ex) {
                throw new ArgumentException(ex.Message);
            }
            
        } 
    }
}
