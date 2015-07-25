using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Interfaces;
using SmhiNet.Lib.Observation;
using SmhiNet.Models;
using SmhiNet.Services;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationGetWindDirLatestDayUnitTest
    {
        private IWeatherObservation _weather;
        private IEnumerable<ObservationModel> _windDir;

        [TestInitialize]
        public void Init()
        {
            _weather = new WeatherObservation(new FakeWeatherObservationRepository());

            _windDir = _weather.GetWindDirLatestDay(71190);
        }


        [TestMethod]
        public void GetWindDirLatestDay_Tdd()
        {
            _weather = new WeatherObservation(new FakeWeatherObservationRepository());
            
            _windDir = _weather.GetWindDirLatestDay(71190);
            
            Assert.IsNotNull(_windDir);
        }

        [TestMethod]
        public void GetWindDirLatestDay_CountValue()
        {
            var count = _windDir.Count();

            Assert.AreEqual(count, 24);
        }


        [TestMethod]
        public void GetWindDirLatestDay_FirstReturnedValue_CompassPoint()
        {
            var value = (from w in _windDir select w.Value).First();

            Assert.AreEqual(value.ToCompassPoint().ToString(), "E");
            
        }

        [TestMethod]
        public void GetWindDirLatestDay_FirstReturnedValue_Degree()
        {
            var value = (from w in _windDir select w.Value).First();

            Assert.AreEqual(value, 100);

        }
    }
}
