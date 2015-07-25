using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace SmhiDemo.App_Start
{
    class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Default", "", "~/Pages/ThreeColumns.aspx");
            routes.MapPageRoute("Forcast", "Forcast/", "~/Pages/Forcast.aspx");
            routes.MapPageRoute("Graph", "Graph/", "~/Pages/Graph.aspx");
        }
    }
}
