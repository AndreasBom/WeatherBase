using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Interfaces;
using SmhiNet.Lib.Observation;
using SmhiNet.Models;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationGetWindDirLatestMonthUnitTest
    {
        private WeatherObservation _weather;
        private IEnumerable<ObservationModel> _windDir; 

        [TestInitialize]
        public void Init()
        {
            _weather = new WeatherObservation(new FakeWeatherObservationRepository());

            _windDir = _weather.GetWindDirLatestMonth(95455);

        }


        [TestMethod]
        public void GetWindDirLatestMonth_TDD()
        {
            var weather = new WeatherObservation(new FakeWeatherObservationRepository());

            var windDir = weather.GetWindDirLatestMonth(75454);

            Assert.IsNotNull(windDir);
        }


        [TestMethod]
        public void GetWindDirLatestMonth_Count_ReturnValue()
        {
            var count = _windDir.Count();

            Assert.AreEqual(count, 3024);
        }

        [TestMethod]
        public void GetWindDirLatestMonth_FirstReturnValue()
        {
            var value = (from v in _windDir select v.Value).First();

            Assert.AreEqual(value, 275);
        }
    }
}
