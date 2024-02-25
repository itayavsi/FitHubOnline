using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.Web.Optimization;


namespace ItayProject
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["userName"] = "Itay";
            Application["password"] = "Itay1212!";
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["userName"] = "Visitor";
            Session["logIn"] = false;
            Session["admin"] = false;
            Session["password"] = "no password";
            Session["firstName"] = "Visitor";
            Session["lastName"] = "";
            Session["UserId"] = 0;
        }
    }

}