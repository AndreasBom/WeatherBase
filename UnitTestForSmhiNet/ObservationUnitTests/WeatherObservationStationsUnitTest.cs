using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Lib.Observation;
using SmhiNet.Models;
using UnitTestForSmhiNet.FakesRepositories;
using System.Net.Http;
using UnitTestForSmhiNet.FakesRepositories.FakeData;
using Moq;
using Newtonsoft.Json.Linq;
using SmhiNet.Interfaces;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationStationsUnitTest
    {
        /// <summary>
        /// Asserts that method GetStations is not returning null 
        /// </summary>
        [TestMethod]
        public void Method_GetWeatherStations_TDD()
        {
            //Arrange
            var injectionWeather = new FakeWeatherObservationRepository();
            var injectionCache = new FakeCachedData();
            var weatherObj = new WeatherObservation(injectionWeather);
            
            IEnumerable<WeatherStationModel> stations = null;

            Assert.IsNull(stations);

            //Act
            stations = weatherObj.GetWeatherStations(5);
            
            //Assert
            Assert.IsNotNull(stations);
        }

        /// <summary>
        /// Counts number of items returned from method GetStations()
        /// </summary>
        [TestMethod]
        public void Method_GetweatherStations_Count()
        {
            //Arrange
            var injectionWeather = new FakeWeatherObservationRepository();
            var injectionCache = new FakeCachedData();
            var weatherObj = new WeatherObservation(injectionWeather);

            var listOfStations = weatherObj.GetWeatherStations(4);

            //Act
            var numberOfStations = listOfStations.Count();


            //Assert
            Assert.AreEqual(numberOfStations, 11);
            //Fails
            //Assert.AreEqual(numberOfStations, 100);

        }


        /// <summary>
        /// Unexpected parameter value results in an HttpRequestException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(HttpRequestException))]
        public void Method_GetWeatherStations_IntergrationTest_ExpectedException()
        {
            //Arrange
            var injectionWeather = new FakeHttpRequestException();
            var injectionCache = new FakeCachedData();
            var weatherObj = new WeatherObservation(injectionWeather);
            
            //Assert (unexpected parameter value)
            weatherObj.GetWeatherStations(500);
        }



    }
}
