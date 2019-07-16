using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleWebchat.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string connString = ConfigurationManager.ConnectionStrings["SimpleWebchatConnection"].ConnectionString;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Uygulama Başladığında SQL Dependency Çalışır
            SqlDependency.Start(connString);
        }
        protected void Application_End()
        {
            //Uygulama Sonlandığında SQL Dependency Sonlanır
            SqlDependency.Stop(connString);
        }
    }
}
