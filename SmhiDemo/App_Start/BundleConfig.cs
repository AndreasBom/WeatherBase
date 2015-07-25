using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;


namespace SmhiDemo
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //JS

            bundles.Add(new ScriptBundle("~/bundles/JQuery").Include(
                "~/Scripts/jquery-1.9.1.js",
                "~/Scripts/jquery-1.9.0.intellisence.js",
                "~/Scripts/bootstrap.js"
                ));

            //CSS

            bundles.Add(new ScriptBundle("~/bundles/BootstrapCss").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme-css"
                ));
        }
    }
}
