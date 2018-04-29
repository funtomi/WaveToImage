using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveToText.Models {
    /// <summary>
    /// 城市类
    /// </summary>
   public class CityModel {
       public int CityId { get; set; }
       public string Name { get; set; }
       public int CityIndex { get; set; }
       public int ProvinceId { get; set; }
    }
}
