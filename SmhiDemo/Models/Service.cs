using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmhiNet.Interfaces;
using SmhiNet.Lib.Forcast;
using SmhiNet.Models;
using System.ComponentModel.DataAnnotations;

namespace SmhiDemo.Models
{
    public class Service
    {
        private WeatherForcast _weatherforcast;

        private WeatherForcast WeatherForcast
        {
            get { return _weatherforcast ?? (_weatherforcast = new WeatherForcast()); }
        }


        /// <summary>
        /// Returns short term forcast. Values for every hour
        /// </summary>
        /// <param name="latitude">string latitude</param>
        /// <param name="longitude">string longitude</param>
        /// <returns></returns>
        public IEnumerable<ForcastModel> GetForcastShortPeriod(string latitude, string longitude)
        {
            var forcastShortPeriod = new List<ForcastModel>(24);
            
            var forcastAllValues = WeatherForcast.GetForcast(latitude, longitude);


            //Temp varible to hold previus value    
            var temp = default(ForcastModel);
            var firstLoop = true;
            
            //Adds forcast to List if time difference (ValidTime) is 1 hour between objects in forcastAllValues. 
            foreach (var forcast in forcastAllValues)
            {
                if (firstLoop)
                {
                    forcastShortPeriod.Add(forcast);
                    firstLoop = false;
                }
                    
                else
                {
                    if (forcast.ValidTime == temp.ValidTime.AddHours(1))
                    {
                        forcastShortPeriod.Add(forcast);
                    }
                }
                temp = forcast;
            }
            forcastShortPeriod.TrimExcess();
            return forcastShortPeriod;
        }

        public IEnumerable<ForcastModel> GetForcastShortPeriod(double latitude, double longitude)
        {
            var forcastShortPeriod = new List<ForcastModel>(24);



            var forcastAllValues = WeatherForcast.GetForcast(latitude, longitude);


            //Temp varible to hold previus value    
            var temp = default(ForcastModel);
            var firstLoop = true;

            //Adds forcast to List if time difference (ValidTime) is 1 hour between objects in forcastAllValues. 
            foreach (var forcast in forcastAllValues)
            {
                if (firstLoop)
                {
                    forcastShortPeriod.Add(forcast);
                    firstLoop = false;
                }

                else
                {
                    if (forcast.ValidTime == temp.ValidTime.AddHours(1))
                    {
                        forcastShortPeriod.Add(forcast);
                    }
                }
                temp = forcast;
            }
            forcastShortPeriod.TrimExcess();
            return forcastShortPeriod;
        }


        /// <summary>
        /// Returns long term forcast. One value per day (12:00pm).
        /// </summary>
        /// <param name="latitude">string latitude</param>
        /// <param name="longitude">string longitude</param>
        /// <returns></returns>
        public IEnumerable<ForcastModel> GetForcastLongPeriod(string latitude, string longitude)
        {
            var forcastLongPeriod = new List<ForcastModel>(16);

            var forcastAllValues = WeatherForcast.GetForcast(latitude, longitude);

            forcastLongPeriod = (from forcast in forcastAllValues
                where forcast.ValidTime.ToShortTimeString() == Convert.ToDateTime("12:00:00").ToShortTimeString()
                select forcast).ToList();

            forcastLongPeriod.TrimExcess();
            return forcastLongPeriod;
        }

    }
}
