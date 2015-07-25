using System;
using System.Collections.Generic;
using System.Configuration;
using GeoCode;
using SmhiNet.Models;
using SmhiDemo.Models;

namespace SmhiDemo.Pages
{
    public class ForcastWithImage
    {
        
        public string ImageUrl { get; set; }
        public float Temperature { get; set; }
        public DateTime Date { get; set; }
    }

    public partial class Forcast : System.Web.UI.Page
    {
        private Service _weatherForcast;
        private IEnumerable<ForcastModel> _forcast;

        private Service WeatherForcast
        {
            get { return _weatherForcast ?? (_weatherForcast = new Service()); }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

      


        public IEnumerable<ForcastWithImage> RepeaterForcast_GetData()
        {
            
            if (Session["forcastsearch"] != null)
            {
                var geo = new GeoCoordinates(ConfigurationManager.AppSettings["GoogleGeoCode"])
                {
                    City = (string)Session["forcastsearch"]
                };
                geo.AddressToCoordinates();


                var forcast = WeatherForcast.GetForcastShortPeriod(geo.Latitude, geo.Longitude);

                List<ForcastWithImage> imageList = new List<ForcastWithImage>();

                foreach (var f in forcast)  
                {
                    var model = new ForcastWithImage();
                    var cloudiness = f.TCC_MEAN;
                    var rain = f.PMEAN;
                    var thunder = f.TSTM;

                    if (thunder > 50)
                    {
                        model.ImageUrl = "~/Media/WeatherImages/thunder.png";
                        model.Temperature = f.T;
                        model.Date = f.ValidTime;
                    }
                    else
                    {
                        if (cloudiness <= 2)
                        {
                            model.ImageUrl = "~/Media/WeatherImages/sun.png";
                            model.Temperature = f.T;
                            model.Date = f.ValidTime;
                        }
                        else if (cloudiness > 2 && cloudiness < 5)
                        {
                            if (rain < 1)
                            {
                                model.ImageUrl = "~/Media/WeatherImages/suncloud.png";
                                model.Temperature = f.T;
                                model.Date = f.ValidTime;
                            }
                            else
                            {
                                model.ImageUrl = "~/Media/WeatherImages/sunrain.png";
                                model.Temperature = f.T;
                                model.Date = f.ValidTime;
                            }
                        }
                        else if (cloudiness >= 5)
                        {
                            if (rain < 1)
                            {
                                model.ImageUrl = "~/Media/WeatherImages/cloud.png";
                                model.Temperature = f.T;
                                model.Date = f.ValidTime;
                            }
                            else
                            {
                                model.ImageUrl = "~/Media/WeatherImages/rain.png";
                                model.Temperature = f.T;
                                model.Date = f.ValidTime;
                            }
                        }
                    }

                    imageList.Add(model);
                }

                //Set header
                LabelCity.Text = "Prognos för " + (string)Session["forcastsearch"];

                return imageList;
            }
            return null;
        } 
    }
}