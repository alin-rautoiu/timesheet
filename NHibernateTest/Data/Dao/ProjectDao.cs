using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernateTest.Data.Vo;
using System.Transactions;
using NHibernate.Linq;
using NHibernate.Mapping;
using NHibernate;
using System.Web.Providers.Entities;
using NHibernateTest.Nhibernate;

namespace NHibernateTest.Data.Dao
{
    public class ProjectDao : BaseDao<Project,int>
    {

    }
}