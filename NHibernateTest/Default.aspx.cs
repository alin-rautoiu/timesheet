using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernateTest.Data.Vo;
using System.Web.Providers.Entities;
using NHibernate.Transform;
using NHibernateTest.Data.Dao;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace NHibernateTest
{
    public partial class _Default : Page
    {
        void Grid(int WeekNumber)
        {
            var pontaje = new PontajDao().getAllPontaje(WeekNumber);
            GridView1.DataSource = pontaje;
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            int WeekNumber = Int32.Parse(txtName.Value);
            Grid(WeekNumber);
        }
        protected void AddProject(string Project)
        {
            var projectDao = new ProjectDao();
            var project = new Project() { Name = Project };
            projectDao.SaveOrUpdate(project);
        }
        protected void AddTask(string Task, int ProjectId)
        {
            var taskDao = new TaskDao();
            var task = new Task() { Name = Task, ProjectId = ProjectId };
            taskDao.SaveOrUpdate(task);
        }
        protected void AddTimeSheet(int UserId, string Comment, int TaskId)
        {
            var timeSheetDao = new TimesheetDao();
            var taskDao = new TaskDao();
            var task = taskDao.LoadById(TaskId);
            var timeSheet = new Timesheet() { UserId = UserId, Comment = Comment ,Task=task};
            timeSheetDao.SaveOrUpdate(timeSheet);
        }
        protected void AddDaySheet( DateTime Data, int WorkedHour, int TimeSheetId)
        {
            var daySheetDao = new DaysheetDao();
            var timeSheetDao = new TimesheetDao();
            var timesheet= timeSheetDao.LoadById(TimeSheetId);
            var daysheet = new Daysheet() { Data= Data, WorkedHour = WorkedHour,Timesheet=timesheet};
            daySheetDao.SaveOrUpdate(daysheet);

        }
        protected void SubmitProject_Click(object sender, EventArgs e)
        {
            string Project = project.Value.ToString();
            AddProject(Project);
        }

        protected void SubmitTask_Click(object sender, EventArgs e)
        {
            string Task = task.Value.ToString();
            int ProjectId = Int32.Parse(projectid.Value);
            AddTask(Task, ProjectId);
        }

        protected void SubmitTimeSheet_Click(object sender, EventArgs e)
        {
            int UserId = Int32.Parse(userid.Value);
            string Comment = comment.Value.ToString();
            int TaskId = Int32.Parse(taskid.Value);
            AddTimeSheet(UserId, Comment, TaskId);
        }

        protected void SubmitDaySheet_Click(object sender, EventArgs e)
        {

            DateTime Data = DateTime.Parse(data.Value);
            int WorkedHour = Int32.Parse(workedhour.Value);
            int TimeSheetId = Int32.Parse(timesheetid.Value);
            AddDaySheet(Data, WorkedHour, TimeSheetId);
        }
    }
}