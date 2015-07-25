using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using SmhiNet.Interfaces;
using SmhiNet.Lib.Observation;
using SmhiNet.Models;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationGetWindDirLatestHourUnitTest
    {
        private IWeatherObservation _weather;
        private IEnumerable<ObservationModel> _windDir;

        [TestInitialize]
        public void Init()
        {
            _weather = new WeatherObservation(new FakeWeatherObservationRepository());
            _windDir = _weather.GetWindDirLatestHour(71190);
        }


        [TestMethod]
        public void GetWindDirLatestHour_TDD()
        {
            _windDir = _weather.GetWindDirLatestHour(71190);

            Assert.IsNotNull(_windDir);
        }

        [TestMethod]
        public void GetWindDirLatestHour_Count_Result()
        {
            var count = (from wd in _windDir select wd.Value).Count();

            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void GetWindDirLatestHour_Assert_WindDirValue()
        {
            var value = (from wd in _windDir select wd.Value).FirstOrDefault();
            var expected = 300;

            Assert.AreEqual(expected, value);
        }
    }
}
