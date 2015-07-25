using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Lib.Observation;

namespace UnitTestForSmhiNet.IntegrationTests
{
    [TestClass]
    public class Temp_IntegrationTest
    {


        [TestMethod]
        public void GetTempLatestHour_TDD()
        {
            var weatherObservation = new WeatherObservation();

            var temp = weatherObservation.GetTempLatestHour(71190);

            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void GetTempLatestHour_Counting_ReturnValue()
        {
            var weatherObservation = new WeatherObservation();
            var temp = weatherObservation.GetTempLatestHour(71190);

            var count = temp.Count();

            Assert.AreEqual(count, 1);
        }


        [TestMethod]
        public void GetTempLatestDay_TDD()
        {
            var weatherObservation = new WeatherObservation();

            var tempObj = weatherObservation.GetTempLatestDay(71190);

            Assert.IsNotNull(tempObj);
        }

        [TestMethod]
        public void GetTempLatestDay_Counting_ReturnValue()
        {
            var weatherObservation = new WeatherObservation();

            var tempObj = weatherObservation.GetTempLatestDay(71190);
            var count = tempObj.Count();

            Assert.AreEqual(count, 24);
        }


        [TestMethod]
        public void GetTempLatestMonths_TDD()
        {
            var weatherObservation = new WeatherObservation();

            var tempObj = weatherObservation.GetTempLatestMonths(71190);

            Assert.IsNotNull(tempObj);
        }

        //Will not always pass
        [TestMethod]
        public void GetTempLatestMonths_Counting_ReturnValue()
        {
            var weatherObservation = new WeatherObservation();

            var tempObj = weatherObservation.GetTempLatestMonths(71190);
            var count = tempObj.Count();

            Assert.AreEqual(count, 3036);
        }


        
        [TestMethod]
        public void GetMeanTempLatestDay_TDD()
        {
            var weatherObservation = new WeatherObservation();

            var tempObj = weatherObservation.GetMeanTempLatestDay(71190);

            Assert.IsNotNull(tempObj);
        }


        [TestMethod]
        public void GetMeanTempLatestDay_Counting_ReturnValues()
        {
            var weatherObservation = new WeatherObservation();
            var tempObj = weatherObservation.GetMeanTempLatestDay(71190);

            var count = tempObj.Count();

            Assert.AreEqual(count, 1);
        }


        [TestMethod]
        public void GetMeanTempLatestMonths_TDD()
        {
            var weatherObservation = new WeatherObservation();
            var tempObj = weatherObservation.GetMeanTempLatestMonths(71190);

            Assert.IsNotNull(tempObj);
        }


        [TestMethod]
        public void GetMeanTempLatestMonths_Counting_ReturnValues()
        {
            var weatherObservation = new WeatherObservation();
            var tempObj = weatherObservation.GetMeanTempLatestMonths(71190);

            var count = tempObj.Count();

            Assert.AreEqual(count, 130);
        }


        [TestMethod]
        public void GetMaxTempLatestDay_TDD()
        {
            var weatherObservation = new WeatherObservation();
            var tempObj = weatherObservation.GetMaxTempLatestDay(71190);

            Assert.IsNotNull(tempObj);
        }


        [TestMethod]
        public void GetMaxTempLatestMonths_TDD()
        {
            var weatherObservation = new WeatherObservation();
            var tempObj = weatherObservation.GetMaxTempLatestMonths(71190);

            Assert.IsNotNull(tempObj);
        }


        [TestMethod]
        public void GetMinTempLatestDay_TDD()
        {
            var weatherObservation = new WeatherObservation();
            var tempObj = weatherObservation.GetMinTempLatestDay(71190);

            Assert.IsNotNull(tempObj);
        }

        [TestMethod]
        public void GetMinTempLatestDay_Counting_ReturnValue()
        {
            var weatherObservation = new WeatherObservation();
            var tempObj = weatherObservation.GetMinTempLatestDay(71190).Count();

            Assert.AreEqual(tempObj, 1);
        }


        [TestMethod]
        public void GetMinTempLatestMonths_TDD()
        {
            var weatherObservation = new WeatherObservation();
            var tempObj = weatherObservation.GetMinTempLatestMonths(71190);

            Assert.IsNotNull(tempObj);
        }


        
        [TestMethod]
        public void GetMinTempLatestMonths_Counting_ReturnValue()
        {
            var weatherObservation = new WeatherObservation();
            var tempObj = weatherObservation.GetMinTempLatestMonths(71190).Count();

            Assert.AreEqual(tempObj, 130);
        }


    }
}
