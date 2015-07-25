using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using SmhiNet.Interfaces;
using SmhiNet.Models;
using SmhiNet.Services;

namespace SmhiNet.Repositories.Base
{
    public abstract class HttpClientFetcher : IHttpFetcher
    {
        //Url to observations
        internal static readonly string BaseObservationApiUrl = @"http://opendata-download-metobs.smhi.se/api/";

        //Url to forcasts
        internal static readonly string BaseForcastApiUrl = @"http://opendata-download-metfcst.smhi.se/api/";

        //Holds max-age
        public int CacheHeadersMaxAge { get; set; }

        /// <summary>
        /// Fetches Json file from SMHI
        /// </summary>
        /// <param name="baseApiUrl">Base url to API (baseObservationApi, baseForcastApi)</param>
        /// <param name="apiUrl">url to API</param>
        /// <returns>JObject with weather data</returns>
        public JObject JsonFetcher(string baseApiUrl, string apiUrl)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    //Set HTTP header
                    client.BaseAddress = new Uri(baseApiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Read the HTTP response
                    var response = client.GetAsync(apiUrl).Result;

                    //Checks for cache controle max-age and returns an int (minutes)
                    if (response.Headers.CacheControl != null)
                    {
                        if (response.Headers.CacheControl.MaxAge != null)
                            CacheHeadersMaxAge = (int)response.Headers.CacheControl.MaxAge.Value.TotalMinutes;
                    }
                    else
                        CacheHeadersMaxAge = 0;

                    //Ensure status code is 200, else en exception is thrown
                    response.EnsureSuccessStatusCode();

                    //Reads the json content
                    var content = response.Content.ReadAsAsync<JObject>().Result;

                    return content;
                }
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException(e.ToString());
            }
        }



        internal IEnumerable<ObservationModel> PopulateWeatherObservationModel(JObject content)
        {
            //Code from stack overflow: http://stackoverflow.com/questions/30046745/checking-for-key-name-in-nested-json
            var hasDateProperty =
            content["value"].Any(v => ((JObject)v).Properties().Any(p => p.Name.Contains("date")));
            //End
            IEnumerable<ObservationModel> model;
            
            if (hasDateProperty)
            {
                model = (from item in content["value"]
                    select new ObservationModel()
                    {
                        Date = Converter.UnixTimeToDateTime((long)item["date"]),
                        Value = (float)item["value"],
                        Quality = (string)item["quality"],
                        Updated = Converter.UnixTimeToDateTime((long)item.Root["updated"]),

                        ParameterKey = (int)item.Root["parameter"]["key"],
                        ParameterName = (string)item.Root["parameter"]["name"],
                        ParameterSummary = (string)item.Root["parameter"]["summary"],
                        ParameterUnit = (string)item.Root["parameter"]["unit"],

                        StationKey = (string)item.Root["station"]["key"],
                        StationName = (string)item.Root["station"]["name"],
                        StationHeight = (int)item.Root["station"]["height"],

                        PeriodKey = (string)item.Root["period"]["key"],
                        PeriodFrom = Converter.UnixTimeToDateTime((long)item.Root["period"]["from"]),
                        PeriodTo = Converter.UnixTimeToDateTime((long)item.Root["period"]["to"]),
                        PeriodSummary = (string)item.Root["period"]["summary"],
                        PeriodSampling = (string)item.Root["period"]["sampling"],

                        PositionFrom = Converter.UnixTimeToDateTime((long)item.Root["position"][0]["from"]),
                        PositionTo = Converter.UnixTimeToDateTime((long)item.Root["position"][0]["to"]),
                        PositionHeight = (int)item.Root["position"][0]["height"],
                        Latitude = (double)item.Root["position"][0]["latitude"],
                        Longitude = (double)item.Root["position"][0]["longitude"]


                    }).ToList();
            }
            else
            {
                model = (from item in content["value"]
                         select new ObservationModel()
                         {
                             From = Converter.UnixTimeToDateTime((long)item["from"]),
                             To = Converter.UnixTimeToDateTime((long)item["to"]),
                             Ref = (string)item["ref"],
                             Value = (float)item["value"],
                             Quality = (string)item["quality"],
                             Updated = Converter.UnixTimeToDateTime((long)item.Root["updated"]),

                             ParameterKey = (int)item.Root["parameter"]["key"],
                             ParameterName = (string)item.Root["parameter"]["name"],
                             ParameterSummary = (string)item.Root["parameter"]["summary"],
                             ParameterUnit = (string)item.Root["parameter"]["unit"],

                             StationKey = (string)item.Root["station"]["key"],
                             StationName = (string)item.Root["station"]["name"],
                             StationHeight = (int)item.Root["station"]["height"],

                             PeriodKey = (string)item.Root["period"]["key"],
                             PeriodFrom = Converter.UnixTimeToDateTime((long)item.Root["period"]["from"]),
                             PeriodTo = Converter.UnixTimeToDateTime((long)item.Root["period"]["to"]),
                             PeriodSummary = (string)item.Root["period"]["summary"],
                             PeriodSampling = (string)item.Root["period"]["sampling"],

                             PositionFrom = Converter.UnixTimeToDateTime((long)item.Root["position"][0]["from"]),
                             PositionTo = Converter.UnixTimeToDateTime((long)item.Root["position"][0]["to"]),
                             PositionHeight = (int)item.Root["position"][0]["height"],
                             Latitude = (double)item.Root["position"][0]["latitude"],
                             Longitude = (double)item.Root["position"][0]["longitude"]
                         }).ToList();

            }

            return model;
        }



        internal IEnumerable<ForcastModel> PopulateForcastModel(JObject content)
        {

            var model = (from item in content["timeseries"]
                         select new ForcastModel
                         {
                             Latitude = (double)item.Root["lat"],
                             Longitude = (double)item.Root["lon"],
                             ApprovedTime = (DateTime)item.Root["approvedTime"],
                             ReferenceTime = (DateTime)item.Root["referenceTime"],
                             ValidTime = (DateTime)item["validTime"],
                             MSL = (float)item["msl"],
                             T = (float)item["t"],
                             VIS = (float)item["vis"],
                             WD = (float)item["wd"],
                             WS = (float)item["ws"],
                             R = (int)item["r"],
                             TSTM = (int)item["tstm"],
                             TCC_MEAN = (int)item["tcc_mean"],
                             LCC_MEAN = (int)item["lcc_mean"],
                             MCC_MEAN = (int)item["mcc_mean"],
                             HCC_MEAN = (int)item["hcc_mean"],
                             GUST = (float)item["gust"],
                             PMIN = (float)item["pmin"],
                             PMAX = (float)item["pmax"],
                             SPP = (int)item["spp"],
                             PCAT = (int)item["pcat"],
                             PMEAN = (float)item["pmean"],
                             PMEDIAN = (float)item["pmedian"]
                         }).ToList();

            return model;
        }
    }
}
