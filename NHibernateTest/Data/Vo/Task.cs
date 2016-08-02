using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateTest.Data.Vo
{
    public class Task:BaseVo<int>
    {
        public virtual string TaskName { get; set; }
        public virtual int ProjectId { get; set; }
        public virtual Project Project  { get; set; }


    }
}