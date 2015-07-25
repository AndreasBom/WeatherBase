using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using SmhiDemo.App_Start;

namespace SmhiDemo
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = true;
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var jQuery = new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-1.9.1.min.js",
                DebugPath = "~/Scripts/jquery-1.9.1.js",
                CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.9.1.min.js",
                CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.9.1.js"
            };
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jQuery);
        }
    }
}