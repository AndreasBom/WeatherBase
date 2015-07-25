using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmhiNet.Interfaces;
using SmhiNet.Models;

namespace UnitTestForSmhiNet.FakesRepositories
{
    class FakeCacheReturnsParameterModel : IWeatherObservation
    {
        private FakeCachedData _cache = new FakeCachedData();

        public IEnumerable<ParameterModel> GetParameters()
        {
            if (_cache.HasValue("parameter"))
            {
                var parameter = new List<ParameterModel>
                {
                    new ParameterModel
                    {
                        Title = "var parametersFromCache"
                    }
                };

                return parameter;
            }
            else
            {
                var parameter = new List<ParameterModel>
                {
                    new ParameterModel
                    {
                        Title = "parametersNotCached"
                    }
                    
                };
                _cache.SetCache("parameter", parameter, 1);

                return parameter;
            }
        }

        public IEnumerable<SmhiNet.Models.WeatherStationModel> GetWeatherStations(int parameter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObservationModel> GetWindLatestHour(int stationId)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<ObservationModel> GetWindLatestDay(int stationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObservationModel> GetWindLatestMonths(int stationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObservationModel> GetWindDirLatestHour(int stationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObservationModel> GetWindDirLatestDay(int stationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObservationModel> GetWindDirLatestMonth(int stationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObservationModel> GetTempLatestHour(int stationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObservationModel> GetTempLatestDay(int stationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObservationModel> GetTempLatestMonths(int stationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObservationModel> GetMeanTempLatestHour(int stationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObservationModel> GetMeanTempLatestDay(int stationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObservationModel> GetMeanTempLatestMonths(int stationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObservationModel> GetMaxTempLatestDay(int stationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObservationModel> GetMaxTempLatestMonths(int stationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObservationModel> GetMinTempLatestDay(int stationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObservationModel> GetMinTempLatestMonths(int stationId)
        {
            throw new NotImplementedException();
        }
    }
}
