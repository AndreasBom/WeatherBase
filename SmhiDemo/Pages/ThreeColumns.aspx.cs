using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.UI.WebControls;
using SmhiDemo.Models;
using SmhiNet.Lib.Observation;
using SmhiNet.Models;

namespace SmhiDemo.Pages
{
    public partial class ThreeColumns : System.Web.UI.Page
    {
        private WeatherObservation _weatherObservation;
        private IEnumerable<ParameterModel> _parameters;
        private IEnumerable<WeatherStationModel> _stations;
        private IEnumerable<WeatherObservation> _observation;
        private string _errorMessage;
        private Sanitized _sanitizedParameters;

        public string ErrorMessage { get { return _errorMessage; } }

        private WeatherObservation WeatherObservation
        {
            get { return _weatherObservation ?? (_weatherObservation = new WeatherObservation()); }
        }

        private Sanitized Sanitized
        {
            get { return _sanitizedParameters ?? (_sanitizedParameters = new Sanitized()); }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IEnumerable<ParameterModel> RepeaterParameters_GetData()
        {
            Session.Remove("parameterKey");
            Session.Remove("stationId");
            
            //_parameters = WeatherObservation.GetParameters();//Returns all parameters
            
            _parameters = Sanitized.SanitizedParameters();//Returns parameters included in SMHIdotNet library
            Session["parameters"] = _parameters;
            
            return _parameters;
        }

        protected void RepeaterParameters_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            var index = e.Item.ItemIndex;
            var parameter = ((IEnumerable<ParameterModel>)Session["parameters"]).ElementAt(index);
            Session["parameterKey"] = parameter.Key;

            RepeaterStations.DataSource = _stations;
            RepeaterStations.DataBind();

            if (Session["stationId"] != null)
            {
                RepeaterObservation.DataSource = null;
                RepeaterObservation.DataBind();
            }
            
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


            RepeaterObservation.DataSource = _observation;
            RepeaterObservation.DataBind();
        }

        public IEnumerable<ObservationModel> RepeaterObservation_GetData()
        {
            try
            {
                if (Session["stationId"] != null)
                {
                    var obs = WeatherObservation.GetWeatherLatestDay((int)Session["parameterKey"],
                    (int)Session["stationId"]);

                    return obs;
                }
            }
            catch
            {
                _errorMessage = "Ingen data";
            }
            
            return null;
        }


        
    }
}