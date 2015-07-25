using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmhiNet.Interfaces;
using SmhiNet.Lib.Forcast;
using SmhiNet.Lib.Observation;
using SmhiNet.Models;
using SmhiDemo.Models;


namespace SmhiDemo.Pages
{
    public partial class MapView : System.Web.UI.Page
    {
        //private WeatherForcast _weatherforcast;
        private Service _weatherforcast;
        private IEnumerable<ForcastModel> _forcast;
       
        

        public Service WeatherForcast
        {
            get { return _weatherforcast ?? (_weatherforcast = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (__Latitude.Value != "" || __Longitude.Value != "")
            {
                if (Session["forcast"] == null)
                {
                    //_forcast = WeatherForcast.GetForcast(__Latitude.Value, __Longitude.Value);
                    _forcast = WeatherForcast.GetForcastLongPeriod(__Latitude.Value, __Longitude.Value);
                    Session["forcast"] = _forcast;

                    
                }
                else
                {
                    _forcast = (IEnumerable<ForcastModel>)Session["forcast"];
                }
                
                    ListViewForcast.DataSource = _forcast;
                    ListViewForcast.DataBind();    
                
                

                //Header
                var periodFrom = (from start in _forcast select start.ValidTime).First();
                var periodTo = (from end in _forcast select end.ValidTime).Last();

                period.InnerHtml = String.Format("Prognos gäller för perioden {0} - {1}", periodFrom.ToShortDateString(), periodTo.ToShortDateString());
            }
        }

        


        protected void ButtonGetForcast_OnClick(object sender, EventArgs e)
        {

            
        }


        protected void DataPagerForcast_OnPreRender(object sender, EventArgs e)
        {
            
        }
    }
}