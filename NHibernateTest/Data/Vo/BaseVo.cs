using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateTest.Data.Vo
{
    public class BaseVo<TIdentifier>
        where TIdentifier : new()
    {
        public virtual TIdentifier Id { get; set; }
    }
}