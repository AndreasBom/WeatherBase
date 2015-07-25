using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using SmhiNet.Interfaces;
using System.Web;
using SmhiNet.Models;

namespace UnitTestForSmhiNet.FakesRepositories.FakeData
{
    public class FakeHttpRequestException : IWeatherObservation
    {


        public IEnumerable<SmhiNet.Models.ParameterModel> GetParameters()
        {
            
            throw new HttpRequestException();
            
        }

        public IEnumerable<SmhiNet.Models.WeatherStationModel> GetWeatherStations(int parameter)
        {
            if (parameter < 1 || parameter > 20)
            {
                throw new HttpRequestException();
            }

            return null;
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
