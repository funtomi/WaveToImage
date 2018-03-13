using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WaveToText {
    class ImageManager {
        private static string _conStr = ConfigurationManager.ConnectionStrings["conStr"].ToString();
        
        public ImageManager() {

        }

        public void GetImages(string imageName) {
            if (string.IsNullOrEmpty(imageName)) {
                //return null;
            }

        }
    }
}
