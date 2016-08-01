using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernateTest.Data.Vo;

namespace NHibernateTest
{
    public partial class _Default : Page
    {
        private BindingList<MyDatagridObject> table = new BindingList<MyDatagridObject>
                {
                    new MyDatagridObject
                    {
                        Name = "Alin",
                        Date = DateTime.Now,
                        Hours = 10

                    },
                    new MyDatagridObject
                    {
                        Name = "Alin",
                        Date = DateTime.Now,
                        Hours = 10

                    },
                    new MyDatagridObject
                    {
                        Name = "Alin",
                        Date = DateTime.Now,
                        Hours = 10
                    }
                };

        private DogModel dog = new DogModel
        {
            faceUrl = "http://r.ddmcdn.com/s_f/o_1/cx_633/cy_0/cw_1725/ch_1725/w_720/APL/uploads/2014/11/too-cute-doggone-it-video-playlist.jpg",
            Likes = new List<string>
            {
                "Like 1",
                "Like 2",
                "Like 3"
            },
            Name = "Dog"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["table"] = table;
            }
            else
            {
                table = ViewState["table"] as BindingList<MyDatagridObject>;
                BindData();
            }
            btnAddItem.Click += BtnAddItemOnClick;
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            btnAddItem.Click -= BtnAddItemOnClick;
        }

        private void BtnAddItemOnClick(object sender, EventArgs eventArgs)
        {
            table.AddNew();
            ViewState["table"] = table;
            BindData();
        }

        private void BindData()
        {
            grdTimesheet.DataSource = table;
            grdTimesheet.DataBind();
        }

        protected void grdTimesheet_OnEditCommand(object source, DataGridCommandEventArgs e)
        {
            grdTimesheet.EditItemIndex = e.Item.ItemIndex;
            BindData();
        }

        protected void grdTimesheet_OnUpdateCommand(object source, DataGridCommandEventArgs e)
        {
            var index = e.Item.DataSetIndex;
            
            table[index].Hours = int.Parse(((TextBox)e.Item.Cells[3].Controls[0]).Text);

            grdTimesheet.EditItemIndex = -1;
            BindData();
        }

        public int GetCount()
        {
            return 0;
        }
    }

    [Serializable]
    public class MyDatagridObject
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
    }

    public class DogModel
    {
        public string Name { get; set; }
        public string faceUrl { get; set; }
        public List<string> Likes { get; set; }

    }

}