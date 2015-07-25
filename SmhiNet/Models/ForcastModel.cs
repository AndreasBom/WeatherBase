using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmhiNet.Models
{
    /// <summary>
    /// Model for forcast
    /// </summary>
    public class ForcastModel
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime ApprovedTime { get; set; }
        public DateTime ReferenceTime { get; set; }
        /// <summary>
        /// Time for forcast
        /// </summary>
        public DateTime ValidTime { get; set; }
        /// <summary>
        /// Pressure reduced to MSL, in unit hPh
        /// </summary>
        public float MSL { get; set; }
        /// <summary>
        /// Temperature, in degree Celsius
        /// </summary>
        public float T { get; set; }
        /// <summary>
        /// Visibility, in kilometers
        /// </summary>
        public float VIS { get; set; }
        /// <summary>
        /// Wind direction, in degrees
        /// </summary>
        public float WD { get; set; }
        /// <summary>
        /// Wind velocity, in meter per seconds
        /// </summary>
        public float WS { get; set; }
        /// <summary>
        /// Relative humidity, in procent
        /// </summary>
        public int R { get; set; }
        /// <summary>
        /// Probability thunderstorm, in procent
        /// </summary>
        public int TSTM { get; set; }
        /// <summary>
        /// Total cloud cover, in scale 0-8
        /// </summary>
        public int TCC_MEAN{ get; set; }
        /// <summary>
        /// Low cloud cover, in scale 0-8
        /// </summary>
        public int LCC_MEAN { get; set; }
        /// <summary>
        /// Medium cloud cover, in scale 0-8
        /// </summary>
        public int MCC_MEAN { get; set; }
        /// <summary>
        /// High cloud cover, in scale 0-8
        /// </summary>
        public float HCC_MEAN { get; set; }
        /// <summary>
        /// Wind gust, in meter per second
        /// </summary>
        public float GUST { get; set; }
        /// <summary>
        /// Min precipitation, in millimeter per hour
        /// </summary>
        public float PMIN { get; set; }
        /// <summary>
        /// Max precipitation, in millimeter per hour
        /// </summary>
        public float PMAX { get; set; }
        /// <summary>
        /// Frozen part of total precipitation, in procent
        /// </summary>
        public int SPP { get; set; }
        /// <summary>
        /// Category of precipitation, 
        /// 0 no, 
        /// 1 snow, 
        /// 2 snow and rain, 
        /// 3 rain, 
        /// 4 drizzle, 
        /// 5, freezing rain, 
        /// 6 freezing drizzle
        /// </summary>
        public int PCAT { get; set; }
        /// <summary>
        /// Mean precipitation, in millimeter per hour
        /// </summary>
        public float PMEAN { get; set; }
        /// <summary>
        /// Mean precipitation, in millimeter per hour
        /// </summary>
        public float PMEDIAN { get; set; }
    }
}
