using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmhiNet.Interfaces;
using SmhiNet.Models;
using SmhiNet.Services;

namespace UnitTestForSmhiNet.Base
{
    public abstract class WeatherFetcher
    {
        /// <summary>
        /// Reads a jsonfile
        /// </summary>
        /// <param name="path">Path to json file</param>
        /// <returns>JObject</returns>
        public static JObject ReadJsonFile(string path)
        {
            return JObject.Parse(File.ReadAllText(path));
        }


        public IEnumerable<ObservationModel> PopulateObservationModel(JObject jsonFile)
        {

            var model = (from item in jsonFile["value"]
                select new ObservationModel
                {
                    Date = Converter.UnixTimeToDateTime((long?) item["date"]),
                    Value = (float) item["value"],
                    Quality = (string) item["quality"],
                    Updated = Converter.UnixTimeToDateTime((long) item.Root["updated"]),

                    ParameterKey = (int) item.Root["parameter"]["key"],
                    ParameterName = (string) item.Root["parameter"]["name"],
                    ParameterSummary = (string) item.Root["parameter"]["summary"],
                    ParameterUnit = (string) item.Root["parameter"]["unit"],

                    StationKey = (string) item.Root["station"]["key"],
                    StationName = (string) item.Root["station"]["name"],
                    StationHeight = (int) item.Root["station"]["height"],

                    PeriodKey = (string) item.Root["period"]["key"],
                    PeriodFrom = Converter.UnixTimeToDateTime((long) item.Root["period"]["from"]),
                    PeriodTo = Converter.UnixTimeToDateTime((long) item.Root["period"]["to"]),
                    PeriodSummary = (string) item.Root["period"]["summary"],
                    PeriodSampling = (string) item.Root["period"]["sampling"],

                    PositionFrom = Converter.UnixTimeToDateTime((long) item.Root["position"][0]["from"]),
                    PositionTo = Converter.UnixTimeToDateTime((long) item.Root["position"][0]["to"]),
                    PositionHeight = (int) item.Root["position"][0]["height"],
                    Latitude = (double) item.Root["position"][0]["latitude"],
                    Longitude = (double) item.Root["position"][0]["longitude"]


                });

            return model;
        }
    }
}
