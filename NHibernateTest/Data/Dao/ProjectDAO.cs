using NHibernate.Criterion;
using NHibernateTest.Data.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace NHibernateTest.Data.Dao
{
    public class ProjectDAO:BaseDao<Project,int>
    {
        public new int Create(Project Project)
        {
            using (var transaction = new TransactionScope())
            {
                Project.NameProject = "ZeroToHero";

                var Id = (int)CurrentSession.Save(Project);
                transaction.Complete();

                return Id;
            }
        }
    }
}