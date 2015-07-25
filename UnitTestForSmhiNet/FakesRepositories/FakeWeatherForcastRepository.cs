using System;
using System.Collections.Generic;
using System.Linq;
using SmhiNet.Interfaces;
using SmhiNet.Models;
using UnitTestForSmhiNet.Base;


namespace UnitTestForSmhiNet.FakesRepositories
{
    class FakeWeatherForcastRepository : IWeatherForcast
    {
        public IEnumerable<ForcastModel> GetForcast(double latitude, double longitude)
        {
            string filePath = @"C:\Users\Andreas\Copy\Skola\Linneuniversitetet\Individuellt_Mjukvaruprojekt\SmhiNet\UnitTestForSmhiNet\FakesRepositories\FakeData\Forcast.json";

            var jsonFile = WeatherFetcher.ReadJsonFile(filePath);

            var model = (from item in jsonFile["timeseries"]
                select new ForcastModel
                {
                    Latitude = (double) item.Root["lat"],
                    Longitude = (double)item.Root["lon"],
                    ApprovedTime = (DateTime)item.Root["approvedTime"],
                    ReferenceTime = (DateTime)item.Root["referenceTime"],
                    ValidTime = (DateTime)item["validTime"],
                    MSL = (float)item["msl"],
                    T = (float)item["t"],
                    VIS = (float)item["vis"],
                    WD = (float)item["wd"],
                    WS = (float)item["ws"],
                    R = (int)item["r"],
                    TSTM = (int)item["tstm"],
                    TCC_MEAN = (int)item["tcc_mean"],
                    LCC_MEAN = (int)item["lcc_mean"],
                    MCC_MEAN = (int)item["mcc_mean"],
                    HCC_MEAN = (int)item["hcc_mean"],
                    GUST = (float)item["gust"],
                    PMIN = (float)item["pmin"],
                    PMAX = (float)item["pmax"],
                    SPP = (int)item["spp"],
                    PCAT = (int)item["pcat"],
                    PMEAN = (float)item["pmean"],
                    PMEDIAN = (float)item["pmedian"]
                }).ToList();

            return model;
        }


        public IEnumerable<ForcastModel> GetForcast(string latitude, string longitude)
        {
            throw new NotImplementedException();
        }
    }
}
