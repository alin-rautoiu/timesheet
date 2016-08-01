using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateTest.Data.Vo
{
    public class Dog : BaseVo<int>
    {
        public virtual string Face { get; set; }
        public virtual string Name { get; set; }
        public virtual int Index { get; set; }
        public virtual bool Liked { get; set; }
    }
}