using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernateTest.Data.Vo;
using System.Transactions;
using NHibernateTest.Nhibernate;
using NHibernate.Linq;
using NHibernateTest.Data.Dao;
using System.Data;
using NHibernate;
using System.Data.SqlClient;
using System.Configuration;

namespace NHibernateTest
{
    public partial class _Default : Page
    {
        
        String[] days = new string[]
        {
                 "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
        };

        Timesheet timesheet = new Timesheet
        {
            Comment = "no comment",
            Daysheets = new HashSet<Daysheet>
            {
                new Daysheet
                {
                    WorkedHour = 8,
                    Date = DateTime.Today
                },
                new Daysheet
                {
                    WorkedHour = 8,
                    Date = DateTime.Today.AddDays(1)
                },
                new Daysheet
                {
                    WorkedHour = 8,
                    Date = DateTime.Today.AddDays(2)
                },
                new Daysheet
                {
                    WorkedHour = 8,
                    Date = DateTime.Today.AddDays(3)
                },
                new Daysheet
                {
                    WorkedHour = 8,
                    Date = DateTime.Today.AddDays(4)
                },
                new Daysheet
                {
                    WorkedHour = 8,
                    Date = DateTime.Today.AddDays(5)
                },
                 new Daysheet
                {
                    WorkedHour = 8,
                    Date = DateTime.Today.AddDays(6)
                }

            }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TemplateField tfield = new TemplateField();
                tfield.HeaderText = "Project Name";
                ProjectGrid.Columns.Add(tfield);

                tfield = new TemplateField();
                tfield.HeaderText = "Task name/Description";
                ProjectGrid.Columns.Add(tfield);

                tfield = new TemplateField();
                tfield.HeaderText = "Comment";
                ProjectGrid.Columns.Add(tfield);

                var count = 0;
                foreach (var item in timesheet.Daysheets.ToList())
                {
                    tfield = new TemplateField();
                    tfield.HeaderText = days[count++];
                    ProjectGrid.Columns.Add(tfield);

                }
                BindGrid();
            }
        }

        private void BindGrid()
        {
            var projects = new ProjectDao().LoadAll();
            

            var dt = new DataTable();
            dt.Columns.AddRange(
                new DataColumn[]
                {
                    new DataColumn("Project Name", typeof(string)),
                    new DataColumn("Task name/Description", typeof(string)),
                    new DataColumn("Comment",typeof(string))
                });

            var count = 0;
            foreach (var item in timesheet.Daysheets.ToList())
            {

                dt.Columns.Add(new DataColumn(days[count], typeof(int)));
                count++;
            }

            DateTime startDay = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            DateTime endDay = startDay.AddDays(6);

            var daysheets = new DaysheetDao().LoadAll().Where(x => x.Date >= startDay && x.Date <= endDay).ToList();
            var timesheets = new TimesheetDao().LoadAll();
            var tasks = new TaskDao().LoadAll();

            foreach (var day in daysheets)
            {
                var row = dt.NewRow();
                for (var k = 0; k < 6; k++)
                {
                    if (day.Date.DayOfWeek.ToString() == days[k])
                    {
                        int index = k;
                        row[index + 3] = day.WorkedHour;
                        break;
                    }
                }
                var timesheetId = day.Timesheet.Id;
                foreach(var time in timesheets)
                {
                    
                    if(time.Id == timesheetId)
                    {
                        row[2] = time.Comment;
                        var taskId = time.Task.Id;

                        foreach(var task in tasks)
                        {
                            if(task.Id == taskId)
                            {
                                row[1] = task.Name;
                                var projectId = task.Project.Id;

                                foreach(var project in projects)
                                {
                                    if(projectId == project.Id)
                                    {
                                        row[0] = project.Name;
                                    }
                                    else { continue; }
                                }
                            }
                            else { continue; }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                dt.Rows.Add(row);
            }


            ProjectGrid.DataSource = dt;
            ProjectGrid.DataBind();

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtBoxProject = new TextBox();
                txtBoxProject.ID = "txtProject";
                txtBoxProject.Text = (e.Row.DataItem as DataRowView).Row["Project Name"].ToString();
                e.Row.Cells[1].Controls.Add(txtBoxProject);
                txtBoxProject.ReadOnly = false;

                TextBox txtBoxTask = new TextBox();
                txtBoxTask.ID = "txtTask";
                txtBoxTask.Text = (e.Row.DataItem as DataRowView).Row["Task name/Description"].ToString();
                e.Row.Cells[2].Controls.Add(txtBoxTask);
                txtBoxTask.ReadOnly = true;

                TextBox txtBoxComment = new TextBox();
                txtBoxComment.ID = "txtProject";
                txtBoxComment.Text = (e.Row.DataItem as DataRowView).Row["Comment"].ToString();
                e.Row.Cells[3].Controls.Add(txtBoxComment);
                txtBoxComment.ReadOnly = true;

                int count = 4;
                for(var i = 0; i < 7; i++)
                {
                    TextBox txtDay = new TextBox();
                    txtDay.ID = "txtDay";
                    txtDay.Text = (e.Row.DataItem as DataRowView).Row[days[i]].ToString();
                    e.Row.Cells[count++].Controls.Add(txtDay);
                }
               
            }
            
        }
    }
}