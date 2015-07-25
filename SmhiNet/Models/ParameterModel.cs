using System;
using System.Collections.Generic;

namespace SmhiNet.Models
{
   /// <summary>
   /// Model for parameters
   /// </summary>
    public class ParameterModel
    {
        public double MinLatitude { get; set; }
        public double MinLongitude { get; set; }
        public double MaxLatitude { get; set; }
        public double MaxLongitude { get; set; }
        public int Key { get; set; }
        public DateTime? Updated { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
    }
}
