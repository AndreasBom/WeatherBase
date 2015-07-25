using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmhiDemo.Pages.Shared
{
    public partial class Template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSearch_OnClick(object sender, EventArgs e)
        {
            //Saves search city in Session varible
            var city = TextBoxSearch.Text;
            Session["forcastsearch"] = city;
            Server.Transfer("~/Pages/Forcast.aspx");
        }
    }
}