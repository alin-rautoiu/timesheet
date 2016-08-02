using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping;
using NHibernate.Mapping.Attributes;

namespace NHibernateTest.Data.Vo
{
    public class BaseVo<TIdentifier>
        where TIdentifier : new()
    {
        [Id(Name = "Id", Column = "Id", Type = "int", UnsavedValue = "0")]
        [Generator(1, Class = "identity")]
        public virtual TIdentifier Id { get; set; }
    }
}