using System;

namespace SmhiNet.Models
{
    /// <summary>
    /// Model for stations
    /// </summary>
    public class WeatherStationModel
    {
        public int ParameterKey { get; set; }
        public DateTime? DataUpdated { get; set; }
        public string DataSummary { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public float Height { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime? Updated { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
    }
}
