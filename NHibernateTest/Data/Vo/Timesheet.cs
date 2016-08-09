using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping.Attributes;

namespace NHibernateTest.Data.Vo
{
    [Class(NameType = typeof(Timesheet), SchemaAction = "none", Table = "Timesheet", Mutable = false)]
    [Serializable]
    public class Timesheet :BaseVo<int>
    {
        [Property]
        public virtual int UserId { get; set; }
        [Property]
        public virtual string Comment { get; set; }
        [Property]
        [ManyToOne(Column = "TaskId", ForeignKey = "FK_Timesheet_Task")]
        public virtual Task Task { get; set; }
       
    }
}