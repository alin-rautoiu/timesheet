using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateTest.Data.Vo
{
    public class Project:BaseVo<int>
    {
        public virtual string NameProject { get; set; }

    }
}