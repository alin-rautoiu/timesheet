using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateTest.Data.Vo
{
    public class Timesheet : BaseVo<int>
    {
        public virtual int UserId { get; set; }
        public virtual string Comment { get; set; }
        public virtual int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}