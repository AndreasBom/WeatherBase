using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Services;

namespace UnitTestForSmhiNet.ServicesAndHelpers
{
    [TestClass]
    public class ConverterUnitTest
    {
        [TestMethod]
        public void ConverterClass_Testing_UnixTimeToDateTime_Correct_Parameter()
        {
            //Arrange
            long dateAsLong = 1428998400000;
            DateTime? expected = new DateTime(2015,04,14,10,0,0,DateTimeKind.Local);

            //Act
            DateTime? actual = SmhiNet.Services.Converter.UnixTimeToDateTime(dateAsLong);

            //Assert
            Assert.AreEqual(expected, actual);
            
            //Assert.AreEqual(expected, 1000000000000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConverterClass_UnixtimeToDateTime_OutOfRangeExeption()
        {
            //Arrange
            long dateAsLongOutOfRange = -1455550000555000;
            DateTime expected = new DateTime(2015, 04, 14, 10, 0, 0, DateTimeKind.Local);

            //Act
            DateTime? actual = SmhiNet.Services.Converter.UnixTimeToDateTime(dateAsLongOutOfRange);
        }

        [TestMethod]
        public void DegreeToCompassPoint_Asserting_Value_N()
        {
            var degree = SmhiNet.Services.Converter.DegreeToCompassPoint(0);

            Assert.AreEqual(degree.ToString(), "N");
        }

        [TestMethod]
        public void DegreeToCompassPoint_Asserting_Value_W()
        {
            var degree = SmhiNet.Services.Converter.DegreeToCompassPoint(270);

            Assert.AreEqual(degree.ToString(), "W");
        }

        [TestMethod]
        public void DegreeToCompassPoint_Asserting_Value_S()
        {
            var degree = SmhiNet.Services.Converter.DegreeToCompassPoint(180);

            Assert.AreEqual(degree.ToString(), "S");
        }

        [TestMethod]
        public void DegreeToCompassPoint_Asserting_Value_E()
        {
            var degree = SmhiNet.Services.Converter.DegreeToCompassPoint(90);

            Assert.AreEqual(degree.ToString(), "E");
        }

        [TestMethod]
        public void DegreeToCompassPoint_Asserting_Value_NNE()
        {
            var degree = SmhiNet.Services.Converter.DegreeToCompassPoint(20);

            Assert.AreEqual(degree.ToString(), "NNE");
        }

        [TestMethod]
        public void DegreeToCompassPoint_Asserting_Value_SSW()
        {
            var degree = SmhiNet.Services.Converter.DegreeToCompassPoint(213);

            Assert.AreEqual(degree.ToString(), "SSW");
        }

        [TestMethod]
        public void DegreeToCompassPoint_Asserting_Value_WNW()
        {
            var degree = SmhiNet.Services.Converter.DegreeToCompassPoint(303);

            Assert.AreEqual(degree.ToString(), "WNW");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DegreeToCompass_ParameterOutOfRange_Expects_ArgumentOutOfRange()
        {
            var degree = SmhiNet.Services.Converter.DegreeToCompassPoint(500);   
        }

    }
}
