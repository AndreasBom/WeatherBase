using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmhiNet.Interfaces;
using SmhiNet.Lib.Observation;
using SmhiNet.Models;

namespace SmhiDemo.Pages
{
    /// <summary>
    /// Class holds data that will populate google charts
    /// </summary>
    public class ChartDetails
    {
        public float WindVelocity { get; set; }
        public float MeanTemp { get; set; }
        public float MinTemp { get; set; }
        public float MaxTemp { get; set; }
        public string Time { get; set; }
        public string Station { get; set; }
    }

    public partial class Graph : System.Web.UI.Page
    {
        private static readonly WeatherObservation WeatherObj;
        private static readonly IEnumerable<WeatherStationModel> Stations;
        private static int _stationKey;

        static Graph()
        {
            WeatherObj = new WeatherObservation();
            Stations = WeatherObj.GetWeatherStations(4);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            //In case of unsearchable weatherstation will show a placeholder with error message.
            PlaceHolderError.Visible = false;
        }



        /// <summary>
        /// Returns data that populates wind data in google chart
        /// </summary>
        /// <returns>List ChartDetails</returns>
        [WebMethod]
        public static List<ChartDetails> GetChartDataWind()
        {
            var windObj = WeatherObj.GetWindLatestDay(_stationKey);

            List<ChartDetails> dataList = windObj.Select(wind => new ChartDetails
            {
                WindVelocity = wind.Value,
                Time = wind.Date.ToString(),
                Station = wind.StationName
            }).ToList();

            var reversedDataList = dataList.OrderBy(p => p.Time).ToList();
            return reversedDataList;
        }


        /// <summary>
        /// Returns data that populates Temperature data in google chart
        /// </summary>
        /// <returns>List chartDetails</returns>
        [WebMethod]
        public static List<ChartDetails> GetChartDataTemperature()
        {
            var tempObj = WeatherObj.GetMeanTempLatestMonths(_stationKey).ToList();
            var meanTemp = tempObj.Select(p => p.Value).ToList().ToList();
            var time = tempObj.Select(p => p.Date).ToList().ToList();
            var station = tempObj.Select(p => p.StationName).FirstOrDefault();


            var maxTemp = WeatherObj.GetMaxTempLatestMonths(_stationKey).Select(p => p.Value).ToList();
            var minTemp = WeatherObj.GetMinTempLatestMonths(_stationKey).Select(p => p.Value).ToList();


            List<ChartDetails> dataList = new List<ChartDetails>();

            for (int i = 0; i < meanTemp.Count; i++)
            {
                var chart = new ChartDetails
                {
                    MeanTemp = meanTemp[i],
                    MaxTemp = maxTemp[i],
                    MinTemp = minTemp[i],
                    Time = time[i].ToString(),
                    Station = station
                };

                dataList.Add(chart);
            }

            var dataListReversed = dataList.OrderBy(p => p.Time).ToList();
            return dataListReversed;

        }


        /// <summary>
        /// Autocomplete in weather station search box. Will show available stations
        /// </summary>
        /// <param name="stationName">searchbox value (station name)</param>
        /// <returns>Json formated list with name of weather stations</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> GetStationName(string stationName)
        {

            var allStations = (from station in Stations
                               where station.Name.ToLower().StartsWith(stationName.ToLower())
                               select station.Name).ToList();

            return allStations;
        }


        /// <summary>
        /// ButtonSearch_click will search for weather station 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSearch_OnClick(object sender, EventArgs e)
        {
            //Get weatherStation (taking windkey as parameter)
            var weatherObj = new WeatherObservation();
            var stations = weatherObj.GetWeatherStations(4);

            //input from user. weather station search
            var seachBoxValue = TextBoxSearchWindTemp.Text;

            try
            {
                _stationKey = (int)(from station in stations where station.Name.Contains(seachBoxValue) select station.Id).First();
            }
            catch
            {
                PlaceHolderError.Visible = true;
                LabelError.Text = "Ingen mätstation med det namnet hittades";
            }


        }
    }
}