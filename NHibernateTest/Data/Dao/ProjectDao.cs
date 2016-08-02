using NHibernate.Criterion;
using NHibernateTest.Data.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace NHibernateTest.Data.Dao
{
    public class ProjectDao : BaseDao<Project, int>
    {
        public new int Create(Project project)
        {
            using (var transaction = new TransactionScope())
            {
                project.Id = CurrentSession.CreateCriteria<Project>()
                    .SetProjection(Projections.ProjectionList()
                        .Add(Projections.Max("Id")))
                    .UniqueResult<int>() + 1;

                var id = (int)CurrentSession.Save(project);
                transaction.Complete();

                return id;
            }
        }
    }
}