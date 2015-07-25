using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestForSmhiNet.Base;
using UnitTestForSmhiNet.ServicesAndHelpers;

namespace UnitTestForSmhiNet.MiscUnitTests
{
    [TestClass]
    public class JsonFileReaderUnitTest
    {
       
            /// <summary>
        /// Testing that the WeatherFetcher is able to read a json file.
        /// </summary>
        [TestMethod]
        public void JsonFileReader_Test_for_correct_value()
        {
            var obj =
                WeatherFetcher.ReadJsonFile(
                    @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\Parameter.json");

            var version = (string)obj.SelectToken("key");
            var parameterKey = (int) obj.SelectToken("resource[0].key");


            Assert.AreEqual(version, "latest");
            Assert.AreEqual(parameterKey, 17);

            //Fails
            //Assert.AreEqual(actual, "Test");
        }
    }
}
