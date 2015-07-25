using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SmhiNet.Interfaces;
using SmhiNet.Models;
using SmhiNet.Services;
using UnitTestForSmhiNet.Base;
using UnitTestForSmhiNet.ServicesAndHelpers;



namespace UnitTestForSmhiNet.FakesRepositories
{
    class FakeWeatherObservationRepository : WeatherFetcher, IWeatherObservation
    {

        public IEnumerable<ObservationModel> GetNulls()
        {
            string filePath = @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\ValueWithNull.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);
        } 

        public IEnumerable<ObservationModel> EmptyFile()
        {
            string filePath = @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\EmptyFile.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);
        } 


        public IEnumerable<ParameterModel> GetParameters()
        {
            string filePath =
                @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\Parameter.json";

            var jsonFile = ReadJsonFile(filePath);

            var model = (from item in jsonFile["resource"]
                         select new ParameterModel
                         {
                             MinLatitude = (double)item["geoBox"]["minLatitude"],
                             MinLongitude = (double)item["geoBox"]["minLongitude"],
                             MaxLatitude = (double)item["geoBox"]["maxLatitude"],
                             MaxLongitude = (double)item["geoBox"]["maxLongitude"],
                             Key = (int)item["key"],
                             Updated = Converter.UnixTimeToDateTime((long)item["updated"]),
                             Title = (string)item["title"],
                             Summary = (string)item.Root["summary"],
                             
                             
                         }).ToList();

            return model;
        }


        public IEnumerable<WeatherStationModel> GetWeatherStations(int parameter)
        {

            var filePath = @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\StationsParameter4.json";

            var jsonFile = ReadJsonFile(filePath);

            var model = (from item in jsonFile["station"] select new WeatherStationModel
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
            }).ToList();

            return model;
        }

        public IEnumerable<ObservationModel> GetWindLatestHour(int stationId)
        {
            var filePath =
                @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\WindLatestHour.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);

        }


        public IEnumerable<ObservationModel> GetWindLatestDay(int stationId)
        {
            var filePath =
                @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\WindLatestDay.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);
        }


        public IEnumerable<ObservationModel> GetWindLatestMonths(int stationId)
        {
            var filePath =
                @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\WindLatestMonth.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);
        }

        public IEnumerable<ObservationModel> GetWindDirLatestHour(int stationId)
        {
            var filePath =
                @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\WindDirLatestHour.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);
        }

        public IEnumerable<ObservationModel> GetWindDirLatestDay(int stationId)
        {
            var filePath = @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\WindDirLatestDay.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);
        }


        public IEnumerable<ObservationModel> GetWindDirLatestMonth(int stationId)
        {
            var filePath = @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\WindDirLatestMonth.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);
        }

        public IEnumerable<ObservationModel> GetTempLatestHour(int stationId)
        {
            var filePath = @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\TempLatestHour.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);
        }

        public IEnumerable<ObservationModel> GetTempLatestDay(int stationId)
        {
            var filePath = @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\TempLatestDay.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);
        }

        public IEnumerable<ObservationModel> GetTempLatestMonths(int stationId)
        {
            var filePath = @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\TempLatestMonths.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);
        }

        public IEnumerable<ObservationModel> GetMeanTempLatestDay(int stationId)
        {
            var filePath = @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\MeanTempLatestDay.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);
        }

        public IEnumerable<ObservationModel> GetMeanTempLatestMonths(int stationId)
        {
            var filePath = @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\MeanTempLatestMonths.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);
        }

        public IEnumerable<ObservationModel> GetMaxTempLatestDay(int stationId)
        {
            var filePath = @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\MaxTempLatestDay.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);
        }

        public IEnumerable<ObservationModel> GetMaxTempLatestMonths(int stationId)
        {
            var filePath = @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\MaxTempLatestMonths.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);
        }

        public IEnumerable<ObservationModel> GetMinTempLatestDay(int stationId)
        {
            var filePath = @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\MinTempLatestDay.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);  
        }

        public IEnumerable<ObservationModel> GetMinTempLatestMonths(int stationId)
        {
            var filePath = @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\MinTempLatestMonths.json";

            var jsonFile = ReadJsonFile(filePath);

            return PopulateObservationModel(jsonFile);  
        }
    }
}
