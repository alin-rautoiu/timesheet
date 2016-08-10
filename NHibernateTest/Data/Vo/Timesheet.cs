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
        [ManyToOne(Column = "TaskId")]
        public virtual Task Task { get; set; }

        [Set(0, Name = "Daysheets", Inverse = true)]
        [Key(1, Column = "Id", ForeignKey = "FK_Daysheet_Timesheet")]
        [OneToMany(2, ClassType = typeof(Daysheet))]
        public virtual ISet<Daysheet> Daysheets { get; set; }
    }
}