using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping;
using NHibernate.Mapping.Attributes;

namespace NHibernateTest.Data.Vo
{
    [Class(NameType = typeof(Task), SchemaAction = "none", Table = "Task", Mutable = false)]
    [Serializable]
    public class Task :BaseVo<int>
    {
        [Property]
        public virtual string Name{ get; set; }
        [Property]
        public virtual int ProjectId { get; set; }
       
        [ManyToOne(Column = "ProjectId")]
   
        [Set(0, Name = "Timesheets", Inverse = true)]
        [Key(1, Column = "TimesheetId", ForeignKey = "FK_Timesheet_Task")]
        [OneToMany(2, ClassType = typeof(Task))]
        public virtual ISet<Timesheet> Timesheets { get; set; }
    }
}