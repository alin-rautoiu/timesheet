using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernateTest.Data.Vo;
using NHibernateTest.Nhibernate;
using NHibernate;
using NHibernateTest.Data.Dao;

namespace NHibernateTest
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ManipulateProject();
        }


        private void ManipulateProject()
        {
            try
            {
                SessionHelper sessionHelper = new SessionHelper();
                using (ITransaction transaction = sessionHelper.Current.BeginTransaction())
                {

                    ProjectDao project = new ProjectDao();
                    Project FromZeroToHero = new Project();
                    FromZeroToHero.Name = "FromZeroToHero";
                    project.SaveOrUpdate(FromZeroToHero);
                    transaction.Commit();
                    sessionHelper.CloseSession();
                }

            }
            catch
            {

            }

          
        }
    }


 

}