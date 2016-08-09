using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping.Attributes;
using NHibernateTest.Data.Vo;

namespace NHibernateTest.Data.Vo
{
    [Class(NameType = typeof(Daysheet), SchemaAction = "none", Table = "Daysheet", Mutable = false)]
    [Serializable]
    public class Daysheet : BaseVo<int>
    {
        [Property]
        public virtual DateTime Data { get; set; }
        [Property]
        public virtual int WorkedHour { get; set; }
        [Property]
        [ManyToOne(Column = "TimesheetId" ,ForeignKey ="FK_Daysheet_Timesheet")]
        public virtual Timesheet Timesheet { get; set; }
        
    }
}