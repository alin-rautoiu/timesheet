using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateTest.Data.Vo
{
    public class Pontaj
    {
        public virtual Guid Guid { get; set; }
        public virtual string  Project { get; set; }
        public virtual string  Task { get; set; }
        public virtual string Comment { get; set; }
        public virtual int Sun { get; set; }
        public virtual int Mon { get; set; }
        public virtual int Tue { get; set; }
        public virtual int Wed { get; set; }
        public virtual int Thu { get; set; }
        public virtual int Fri { get; set; }
        public virtual int Sat { get; set; }

    }
}