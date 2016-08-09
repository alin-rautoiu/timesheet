using System;
using System.Transactions;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using log4net.Config;
using NHibernateTest.Data.Dao;
using NHibernateTest.Data.Vo;
using NHibernateTest.Nhibernate;
using NHibernate.Transform;
using System.Web.Providers.Entities;
using NHibernate;
using static System.Collections.Specialized.BitVector32;

namespace NHibernateTest
{
    public class Global : HttpApplication
    {
        protected SessionHelper SessionHelper = null;

        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    SessionHelper = new SessionHelper();
        //    SessionHelper.OpenSession();
        //}

        //protected void Application_EndRequest(object sender, EventArgs e)
        //{
        //    SessionHelper = new SessionHelper();
        //    SessionHelper.CloseSession();
        //}



        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            XmlConfigurator.Configure();



        }
    }
}