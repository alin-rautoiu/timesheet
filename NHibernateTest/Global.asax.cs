using System;
using System.Transactions;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using log4net.Config;
using NHibernateTest.Data.Dao;
using NHibernateTest.Data.Vo;
using NHibernateTest.Nhibernate;
using NHibernate;
using System.Collections.Generic;
using NHibernate.Criterion;
using System.Collections;
using System.Linq;

namespace NHibernateTest
{
    public class Global : HttpApplication
    {
        protected SessionHelper SessionHelper = null;

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            SessionHelper = new SessionHelper();
            SessionHelper.OpenSession();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            SessionHelper = new SessionHelper();
            SessionHelper.CloseSession();
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            XmlConfigurator.Configure();


            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {

                    SessionHelper = new SessionHelper();
                    SessionHelper.OpenSession();
                    //var projectDao = new ProjectDao();
                    //var taskDao = new TaskDao();
                    //var newTask = new Task();
                    //newTask.Name = "Task 4";
                    //newTask.Project = projectDao.LoadById(4);
                    //SessionHelper.Current.Save(newTask);
                    //SessionHelper.Current.Flush();
                    //taskDao.SaveOrUpdate(newTask);
                    //SessionHelper.Current.QueryOver<Project>().JoinQueryOver(p => p.Tasks).Select(p => p.Name);
                    ////IEnumerable <string> query = from Project in projects
                    ////                            join Task in tasks
                    ////                            on new {Project.Id}
                    ////                            equals new { Task.ProjectId }
                    ////                            select Project.Name + " " + Task.Name;

                    //var timesheet = new TimesheetDao().LoadById(1);
                    //var daysheetDao = new DaysheetDao();
                    //var projects = new ProjectDao().LoadAll();
                    //var task = new TaskDao().LoadAll();

                    //var daysheet = new Daysheet();
                    //daysheet.Date = DateTime.Now;
                    //daysheet.WorkedHour = 8;
                    //daysheet.Timesheet = timesheet;
                    //SessionHelper.Current.Save(daysheet);
                    //SessionHelper.Current.Flush();
                    transaction.Complete();
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                SessionHelper.CloseSession();
            }
        }
    }
}