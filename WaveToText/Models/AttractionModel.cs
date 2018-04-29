using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveToText.Models {
    /// <summary>
    /// 景点类
    /// </summary>
   public class AttractionModel {
       public int AttractionId { get; set; }
       public string AttractionName { get; set; }
       public string AttractionDescription { get; set; }
       public int CityId { get; set; }
    }
}
