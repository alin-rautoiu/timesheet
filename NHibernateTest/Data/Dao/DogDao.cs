using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate.Util;
using NHibernateTest.Data.Vo;

namespace NHibernateTest.Data.Dao
{
    public class DogDao : BaseDao<Dog, int>
    {
        /// <summary>
        ///     Creates a dog object
        /// </summary>
        /// <param name="dog"></param>
        /// <returns></returns>
        public new int Create(Dog dog)
        {
            using (var transaction = new TransactionScope())
            {
                dog.Index = CurrentSession.CreateCriteria<Dog>()
                    .SetProjection(Projections.ProjectionList()
                        .Add(Projections.Max("Index")))
                    .UniqueResult<int>() + 1;

                var id = (int)CurrentSession.Save(dog);
                transaction.Complete();

                return id;
            }
        }
    }
}