using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Lib.Observation;

namespace UnitTestForSmhiNet.IntegrationTests
{
    [TestClass]
    public class Cache_and_Wind_IntegrationTest
    {
        private WeatherObservation _weather;
        

        [TestInitialize]
        public void Init()
        {
            _weather = new WeatherObservation();
        }


        [TestMethod]
        public void CacheMemory_Methods_SetCache_And_GetCache_For_Parameter()
        {

            //Arrange
            var fetchFile = new WeatherObservation();


            //Act (USE DEBUGER TO BE SURE THE SECOND GETPARAMETERS FETCHES FROM CACHE)
            var firstFetch = fetchFile.GetParameters();
            var secondFetche = fetchFile.GetParameters();

            //Assert
            Assert.AreSame(firstFetch, secondFetche);

        }

        [TestMethod]
        public void CacheMemory_Methods_SetCache_And_GetCache_For_Stations()
        {

            //Arrange
            var fetchFile = new WeatherObservation();


            //Act (USE DEBUGER TO BE SURE THE SECOND GETPARAMETERS FETCHES FROM CACHE)
            var firstFetch = fetchFile.GetWeatherStations(4);
            var secondFetche = fetchFile.GetWeatherStations(4);

            //Assert 
            Assert.AreSame(firstFetch, secondFetche);

        }


        [TestMethod]
        public void GetWindLatestDay_TDD()
        {
            //Arrange
            var fetcher = new WeatherObservation();

            //Act 
            var fetchWind = fetcher.GetWindLatestDay(71190);

            //Assert 
            Assert.IsNotNull(fetchWind);
        }


        [TestMethod]
        public void GetWindLatestDay_Testing_Cache()
        {
            //Arrange
            var fetcher = new WeatherObservation();

            //Act (USE DEBUGER TO BE SURE THE SECOND GETPARAMETERS FETCHES FROM CACHE)
            var fetchWind1 = fetcher.GetWindLatestDay(71190);
            var fetchWind2 = fetcher.GetWindLatestDay(71190);

            //Assert 
            Assert.AreSame(fetchWind1, fetchWind2);
        }


        [TestMethod]
        public void GetWindLatestMonths_TDD()
        {
            //Arrange
            var fetcher = new WeatherObservation();

            //Act 
            var fetchWind = fetcher.GetWindLatestMonths(71190);

            //Assert 
            Assert.IsNotNull(fetchWind);
        }


        [TestMethod]
        public void GetWindLatestMonths_Testing_Cache()
        {
            //Arrange
            var fetcher = new WeatherObservation();

            //Act (USE DEBUGER TO BE SURE THE SECOND GETPARAMETERS FETCHES FROM CACHE)
            var fetchWind1 = fetcher.GetWindLatestMonths(71190);
            var fetchWind2 = fetcher.GetWindLatestMonths(71190);
            
            //Assert 
            Assert.AreSame(fetchWind1, fetchWind2);
        }


        [TestMethod]
        public void GetWindDirLatestHour_TDD()
        {
            var windDir = _weather.GetWindDirLatestHour(71190);
            
            Assert.IsNotNull(windDir);
        }

        [TestMethod]
        public void GetWindDirLatestHour_Count_ReturnValue()
        {
            var windDir = _weather.GetWindDirLatestHour(71190);

            var count = windDir.Count();

            Assert.AreEqual(count, 1);

        }

        [TestMethod]
        public void GetWindDirLatestDay_TDD()
        {
            var windDir = _weather.GetWindDirLatestDay(71190);

            Assert.IsNotNull(windDir);
        }

        [TestMethod]
        public void GetWindDirLatestDay_Counting_ReturnValue()
        {
            var windDir = _weather.GetWindDirLatestDay(71190);

            var count = windDir.Count();

            Assert.AreEqual(count, 24);
        }


        [TestMethod]
        public void GetWindDirLatestMonth_TDD()
        {
            var windDir = _weather.GetWindDirLatestMonth(71190);

            Assert.IsNotNull(windDir);
        }

        //Will not always pass!
        [TestMethod]
        public void GetWindDirLatestMonth_Count()
        {
            var windDir = _weather.GetWindDirLatestMonth(71190);

            var count = windDir.Count();

            Assert.AreEqual(count, 3024);
        }


    }
}
