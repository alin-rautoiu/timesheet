using NHibernate.Transform;
using NHibernateTest.Data.Vo;
using NHibernateTest.Nhibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace NHibernateTest.Data.Dao
{
    public class PontajDao
    {
        public IList<Pontaj> getAllPontaje(int WeekNumber)
        {
            var SessionHelper = new SessionHelper();
            SessionHelper.OpenSession();
            var session = SessionHelper.Current;

            try
            {
                using (var transactionScope = new TransactionScope())
                {

                    var listPontaje = session.GetNamedQuery("Pontaj")
                       .SetInt32("nrOfWeek", WeekNumber)
                       .SetResultTransformer(Transformers.AliasToBean<Pontaj>())
                       .List<Pontaj>();

                    transactionScope.Complete();

                    return listPontaje;
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.Message);
                return null;
            }
        }
    }
}