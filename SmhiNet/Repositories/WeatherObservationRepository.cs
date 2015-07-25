using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json.Linq;
using SmhiNet.Interfaces;
using SmhiNet.Models;
using SmhiNet.Repositories.Base;
using SmhiNet.Services;



namespace SmhiNet.Repositories
{
    internal class WeatherObservationRepository : HttpClientFetcher, IWeatherObservation
    {
        private ICachedData _cachedData;


        /// <summary>
        /// Default Constructor
        /// </summary>
        public WeatherObservationRepository()
            : this(new CachedDataRepository())
        {

        }

        /// <summary>
        /// Constructor injection
        /// </summary>
        /// <param name="cachedData"></param>
        public WeatherObservationRepository(ICachedData cachedData)
        {
            _cachedData = cachedData;

        }



        /// <summary>
        /// Gets a list of parameters. Retrives data from method FetchParameters or cache memory. Data is saved in cache memory for 60 minutes
        /// </summary>
        /// <returns>IEnumerable ParameterModels</returns>
        public IEnumerable<ParameterModel> GetParameters()
        {
            if (_cachedData.HasValue("parameters"))
            {
                return _cachedData.GetCache("parameters") as IEnumerable<ParameterModel>;
            }
            else
            {
                var parameters = FetchParameters();
                _cachedData.SetCache("parameters", parameters, 60);

                return parameters;
            }

        }


        /// <summary>
        /// Fetches parameters from SMHI
        /// </summary>
        /// <returns>IEnumerable ParameterModel</returns>
        private IEnumerable<ParameterModel> FetchParameters()
        {
            var url = "version/latest.json";

            var content = JsonFetcher(BaseObservationApiUrl, url);

            if (content != null)
            {
                var model = (from val in content["resource"]
                             select new ParameterModel
                             {
                                 MinLatitude = (double)val["geoBox"]["minLatitude"],
                                 MinLongitude = (double)val["geoBox"]["minLongitude"],
                                 MaxLatitude = (double)val["geoBox"]["maxLatitude"],
                                 MaxLongitude = (double)val["geoBox"]["maxLongitude"],
                                 Key = (int)val["key"],
                                 Updated = Converter.UnixTimeToDateTime((long)val["updated"]),
                                 Title = (string)val["title"],
                                 Summary = (string)val["summary"]
                             }).ToList();

                return model;
            }
            return null;
        }


        /// <summary>
        /// Gets a list of weather stations for a specific parameter. Retrives data from method FetchStations or cache memory. Data is saved in cache memory for 60 minutes
        /// </summary>
        /// <param name="parameter">int parameter</param>
        /// <returns>IEnumerable WeatherStationModel</returns>
        public IEnumerable<WeatherStationModel> GetWeatherStations(int parameter)
        {
            if (_cachedData.HasValue("stations" + parameter))
            {
                return _cachedData.GetCache("stations" + parameter) as IEnumerable<WeatherStationModel>;
            }
            else
            {
                var stations = FetchStations(parameter);
                _cachedData.SetCache("stations" + parameter, stations, 60);

                return stations;
            }
        }


        /// <summary>
        /// Fetches all weather stations for a specified parameter from SMHI
        /// </summary>
        /// <param name="parameter">int parameter</param>
        /// <returns>IEnumerable WeatherStationsModel</returns>
        private IEnumerable<WeatherStationModel> FetchStations(int parameter)
        {
            var url = String.Format("version/latest/parameter/{0}.json", parameter);

            var content = JsonFetcher(BaseObservationApiUrl,url);

            //Adds stations that has data new than one month. Disused stations with old data are ignored
            var model = (from item in content["station"]
                         select new WeatherStationModel
                         {
                             ParameterKey = (int)item.Root["key"],
                             DataUpdated = Converter.UnixTimeToDateTime((long)item.Root["updated"]),
                             DataSummary = (string)item.Root["summary"],
                             Name = (string)item["name"],
                             Id = (int)item["id"],
                             Height = (float)item["height"],
                             Latitude = (double)item["latitude"],
                             Longitude = (double)item["longitude"],
                             Updated = Converter.UnixTimeToDateTime((long)item["updated"]),
                             Title = (string)item["title"],
                             Summary = (string)item["summary"]
                         }).Where(a => a.Updated > DateTime.UtcNow.AddMonths(-1));

            return model;
        }


        /// <summary>
        /// Gets windobservation för latest hour. Retrives data from method FetchWindLatestHour or cache memory. Data is saved in cache memory for 10 minutes
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public IEnumerable<ObservationModel> GetWindLatestHour(int stationId)
        {

            if (_cachedData.HasValue("getwindlatesthour" + stationId))
            {
                return _cachedData.GetCache("getwindlatesthour" + stationId) as IEnumerable<ObservationModel>;
            }
            else
            {
                var obj = FetchWindLatestHour(stationId);
                _cachedData.SetCache("getwindlatesthour" + stationId, obj, CacheHeadersMaxAge);

                return obj;
            }
        }


        private IEnumerable<ObservationModel> FetchWindLatestHour(int stationId)
        {
            var url = String.Format("version/latest/parameter/4/station/{0}/period/latest-hour/data.json", stationId);

            var content = JsonFetcher(BaseObservationApiUrl,url);

            return PopulateWeatherObservationModel(content);
        }



        /// <summary>
        /// Gets windobservation för latest day. Retrives data from method FetchWindLatestDay or cache memory. Data is saved in cache memory for 10 minutes
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public IEnumerable<ObservationModel> GetWindLatestDay(int stationId)
        {
            if (_cachedData.HasValue("getwindlatestday" + stationId))
            {
                return _cachedData.GetCache("getwindlatestday" + stationId) as IEnumerable<ObservationModel>;
            }
            else
            {
                var data = FetchWindLatestDay(stationId);
                _cachedData.SetCache("getwindlatestday" + stationId, data, CacheHeadersMaxAge);

                return data;
            }
        }


        /// <summary>
        /// Gets windobservation för latest months. Retrives data from method FetchWindLatestMonth or cache memory. Data is saved in cache memory for 10 minutes
        /// </summary>
        /// <param name="stationId">int stationId</param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetWindLatestMonths(int stationId)
        {
            if (_cachedData.HasValue("GetWindLatestMonths" + stationId))
            {
                return _cachedData.GetCache("GetWindLatestMonths" + stationId) as IEnumerable<ObservationModel>;
            }
            else
            {
                var data = FetchWindLatestMonth(stationId);
                _cachedData.SetCache("GetWindLatestMonths" + stationId, data, CacheHeadersMaxAge);

                return data;
            }
        }


        /// <summary>
        /// Gets windobservation för latest months. Retrives data from method FetchWindDirLatestHour or cache memory. Data is saved in cache memory for 10 minutes
        /// </summary>
        /// <param name="stationId">int stationId</param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetWindDirLatestHour(int stationId)
        {
            if (_cachedData.HasValue("getwinddirlatesthour" + stationId))
            {
                return _cachedData.GetCache("getwinddirlatesthour" + stationId) as IEnumerable<ObservationModel>;
            }
            else
            {
                var data = FetchWindDirLatestHour(stationId);
                _cachedData.SetCache("getwinddirlatesthour" + stationId, data, CacheHeadersMaxAge);

                return data;
            }
        }


        private IEnumerable<ObservationModel> FetchWindLatestMonth(int stationId)
        {
            var url = String.Format("version/latest/parameter/4/station/{0}/period/latest-months/data.json", stationId);

            //JsonFetcher inherent from abstract class
            var content = JsonFetcher(BaseObservationApiUrl,url);

            return PopulateWeatherObservationModel(content).OrderByDescending(d=>d.Date);
        }


        public IEnumerable<ObservationModel> GetWindDirLatestDay(int stationId)
        {
            if (_cachedData.HasValue("getwinddirlatestday" + stationId))
            {
                return _cachedData.GetCache("getwinddirlatestday" + stationId) as IEnumerable<ObservationModel>;
            }
            else
            {
                var data = FetchWindDirLatestDay(stationId);
                _cachedData.SetCache("getwinddirlatestday" + stationId, data, CacheHeadersMaxAge);

                return data;
            }
        }

        public IEnumerable<ObservationModel> GetWindDirLatestMonth(int stationId)
        {
            if (_cachedData.HasValue("getwinddirlatestmonth" + stationId))
            {
                return _cachedData.GetCache("getwinddirlatestmonth" + stationId) as IEnumerable<ObservationModel>;
            }
            else
            {
                var data = FetchWindDirLatestMonth(stationId);
                _cachedData.SetCache("getwinddirlatestmonth" + stationId, data, CacheHeadersMaxAge);

                return data;
            }

        }

        public IEnumerable<ObservationModel> GetTempLatestHour(int stationId)
        {
            if (_cachedData.HasValue("gettemplatesthour" + stationId))
            {
                return _cachedData.GetCache("gettemplatesthour" + stationId) as IEnumerable<ObservationModel>;
            }
            else
            {
                var data = FetchTempLatestHour(stationId);
                _cachedData.SetCache("gettemplatesthour" + stationId, data, CacheHeadersMaxAge);

                return data;
            }
        }

        private IEnumerable<ObservationModel> FetchWindLatestDay(int stationId)
        {
            var url = String.Format("version/latest/parameter/4/station/{0}/period/latest-day/data.json", stationId);

            var content = JsonFetcher(BaseObservationApiUrl, url);

            return PopulateWeatherObservationModel(content).OrderByDescending(d => d.Date);
        }


        private IEnumerable<ObservationModel> FetchWindDirLatestHour(int stationId)
        {
            var url = String.Format("version/latest/parameter/3/station/{0}/period/latest-hour/data.json", stationId);

            var content = JsonFetcher(BaseObservationApiUrl,url);

            return PopulateWeatherObservationModel(content);
        }


        private IEnumerable<ObservationModel> FetchTempLatestHour(int stationId)
        {
            var url = String.Format("version/latest/parameter/1/station/{0}/period/latest-hour/data.json", stationId);

            var content = JsonFetcher(BaseObservationApiUrl,url);

            return PopulateWeatherObservationModel(content);
        }

        public IEnumerable<ObservationModel> GetTempLatestDay(int stationId)
        {
            if (_cachedData.HasValue("gettemplatestday" + stationId))
            {
                return _cachedData.GetCache("gettemplatestday" + stationId) as IEnumerable<ObservationModel>;
            }
            else
            {
                var data = FetchTempLatestDay(stationId);
                _cachedData.SetCache("gettemplatestday" + stationId, data, CacheHeadersMaxAge);

                return data;
            }
        }

        public IEnumerable<ObservationModel> GetTempLatestMonths(int stationId)
        {
            if (_cachedData.HasValue("gettemplatestmonths" + stationId))
            {
                return _cachedData.GetCache("gettemplatestmonths" + stationId) as IEnumerable<ObservationModel>;
            }
            else
            {
                var data = FetchTempLatestMonths(stationId);
                _cachedData.SetCache("gettemplatestmonths" + stationId, data, CacheHeadersMaxAge);

                return data;
            }
        }


        public IEnumerable<ObservationModel> GetMeanTempLatestDay(int stationId)
        {
            if (_cachedData.HasValue("getmeantemplatestday" + stationId))
            {
                return _cachedData.GetCache("getmeantemplatestday" + stationId) as IEnumerable<ObservationModel>;
            }
            else
            {
                var data = FetchMeanTempLatestDay(stationId);
                _cachedData.SetCache("getmeantemplatestday" + stationId, data, CacheHeadersMaxAge);

                return data;
            }
        }

        public IEnumerable<ObservationModel> GetMeanTempLatestMonths(int stationId)
        {
            if (_cachedData.HasValue("getmeantemplatestmonths" + stationId))
            {
                return _cachedData.GetCache("getmeantemplatestmonths" + stationId) as IEnumerable<ObservationModel>;
            }
            else
            {
                var data = FetchMeanTempLatestMonths(stationId);
                _cachedData.SetCache("getmeantemplatestmonths" + stationId, data, CacheHeadersMaxAge);

                return data;
            }
        }

        public IEnumerable<ObservationModel> GetMaxTempLatestDay(int stationId)
        {
            if (_cachedData.HasValue("getmaxtemplatestday" + stationId))
            {
                return _cachedData.GetCache("getmaxtemplatestday" + stationId) as IEnumerable<ObservationModel>;
            }
            else
            {
                var data = FetchMaxTempLatestDay(stationId);
                _cachedData.SetCache("getmaxtemplatestday" + stationId, data, CacheHeadersMaxAge);

                return data;
            }
        }

        public IEnumerable<ObservationModel> GetMaxTempLatestMonths(int stationId)
        {
            if (_cachedData.HasValue("getmaxtemplatestmonths" + stationId))
            {
                return _cachedData.GetCache("getmaxtemplatestmonths" + stationId) as IEnumerable<ObservationModel>;
            }
            else
            {
                var data = FetchMaxTempLatestMonths(stationId);
                _cachedData.SetCache("getmaxtemplatestmonths" + stationId, data, CacheHeadersMaxAge);

                return data;
            }
        }

        public IEnumerable<ObservationModel> GetMinTempLatestDay(int stationId)
        {
            if (_cachedData.HasValue("getmintemplatestday" + stationId))
            {
                return _cachedData.GetCache("getmintemplatestday" + stationId) as IEnumerable<ObservationModel>;
            }
            else
            {
                var data = FetchMinTempLatestDay(stationId);
                _cachedData.SetCache("getmintemplatestday" + stationId, data, CacheHeadersMaxAge);

                return data;
            }
        }

        public IEnumerable<ObservationModel> GetMinTempLatestMonths(int stationId)
        {
            if (_cachedData.HasValue("getmintemplatestmonths" + stationId))
            {
                return _cachedData.GetCache("getmintemplatestmonths" + stationId) as IEnumerable<ObservationModel>;
            }
            else
            {
                var data = FetchMinTempLatestMonths(stationId);
                _cachedData.SetCache("getmintemplatestmonths" + stationId, data, CacheHeadersMaxAge);

                return data;
            }
        }



        private IEnumerable<ObservationModel> FetchMinTempLatestMonths(int stationId)
        {
            var url = String.Format("version/latest/parameter/19/station/{0}/period/latest-months/data.json", stationId);

            var content = JsonFetcher(BaseObservationApiUrl, url);

            return PopulateWeatherObservationModel(content).OrderByDescending(d=>d.Date);
        }

        private IEnumerable<ObservationModel> FetchMinTempLatestDay(int stationId)
        {
            var url = String.Format("version/latest/parameter/19/station/{0}/period/latest-day/data.json", stationId);

            var content = JsonFetcher(BaseObservationApiUrl, url);

            return PopulateWeatherObservationModel(content).OrderByDescending(d=>d.Date);
        }

        private IEnumerable<ObservationModel> FetchMaxTempLatestMonths(int stationId)
        {
            var url = String.Format("version/latest/parameter/20/station/{0}/period/latest-months/data.json", stationId);

            var content = JsonFetcher(BaseObservationApiUrl, url);

            return PopulateWeatherObservationModel(content).OrderByDescending(d=>d.Date);
        }

        private IEnumerable<ObservationModel> FetchMaxTempLatestDay(int stationId)
        {
            var url = String.Format("version/latest/parameter/20/station/{0}/period/latest-day/data.json", stationId);

            var content = JsonFetcher(BaseObservationApiUrl, url);

            return PopulateWeatherObservationModel(content);
        }

        private IEnumerable<ObservationModel> FetchMeanTempLatestMonths(int stationId)
        {
            var url = String.Format("version/latest/parameter/2/station/{0}/period/latest-months/data.json", stationId);

            var content = JsonFetcher(BaseObservationApiUrl, url);

            return PopulateWeatherObservationModel(content).OrderByDescending(d=>d.Date);
        }

        private IEnumerable<ObservationModel> FetchMeanTempLatestDay(int stationId)
        {
            var url = String.Format("version/latest/parameter/2/station/{0}/period/latest-day/data.json", stationId);

            var content = JsonFetcher(BaseObservationApiUrl,url);

            return PopulateWeatherObservationModel(content);
        }

        private IEnumerable<ObservationModel> FetchTempLatestMonths(int stationId)
        {
            var url = String.Format("version/latest/parameter/1/station/{0}/period/latest-months/data.json", stationId);

            var content = JsonFetcher(BaseObservationApiUrl,url);

            return PopulateWeatherObservationModel(content).OrderByDescending(d=>d.Date);
        }

        private IEnumerable<ObservationModel> FetchTempLatestDay(int stationId)
        {
            var url = String.Format("version/latest/parameter/1/station/{0}/period/latest-day/data.json", stationId);

            var content = JsonFetcher(BaseObservationApiUrl,url);

            return PopulateWeatherObservationModel(content);
        }

        private IEnumerable<ObservationModel> FetchWindDirLatestMonth(int stationId)
        {
            var url = String.Format("version/latest/parameter/3/station/{0}/period/latest-months/data.json", stationId);

            var content = JsonFetcher(BaseObservationApiUrl,url);

            return PopulateWeatherObservationModel(content).OrderByDescending(d=>d.Date);
        }

        private IEnumerable<ObservationModel> FetchWindDirLatestDay(int stationId)
        {
            var url = String.Format("version/latest/parameter/3/station/{0}/period/latest-day/data.json", stationId);

            var content = JsonFetcher(BaseObservationApiUrl,url);

            return PopulateWeatherObservationModel(content);
        }
    }
}
