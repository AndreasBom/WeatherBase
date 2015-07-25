using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmhiNet.Lib.Observation;
using SmhiNet.Models;

namespace SmhiDemo.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        private WeatherObservation _weatherObservation;
        private IEnumerable<ParameterModel> _parameters;
        private IEnumerable<WeatherStationModel> _stations; 

        private WeatherObservation WeatherObservation
        {
            get { return _weatherObservation ?? (_weatherObservation = new WeatherObservation()); }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        
        public IEnumerable<ParameterModel> RepeaterParameters_GetData()
        {
            _parameters = WeatherObservation.GetParameters();
            Session["parameters"] = _parameters;

            return _parameters;
            return null;
        }

        protected void RepeaterParameters_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {

            var index = e.Item.ItemIndex;
            var parameter = ((IEnumerable<ParameterModel>)Session["parameters"]).ElementAt(index);
            Session["parameterKey"] = parameter.Key;
            RepeaterStations_GetData();

        }

        public IEnumerable<WeatherStationModel> RepeaterStations_GetData()
        {

            if (Session["parameterKey"] != null)
            {
                var selectedParameter = (int)Session["parameterKey"];
                _stations = WeatherObservation.GetWeatherStations(selectedParameter);
                Session["stations"] = _stations;
                return _stations;
            }
            return null;
        }

        protected void RepeaterStations_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var index = e.Item.ItemIndex;
            var station = ((IEnumerable<WeatherStationModel>)Session["stations"]).ElementAt(index);
            Session["stationId"] = station.Id;
            RepeaterObservation_GetData();
        }


        public IEnumerable<ObservationModel> RepeaterObservation_GetData()
        {
            if (Session["stationId"] != null)
            {
                var observation = WeatherObservation.GetWindLatestDay((int)Session["stationId"]);
                return observation;
            }

            return null;

        }

        
    }
}