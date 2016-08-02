using System;

namespace NHibernateTest.Data.Vo
{
    public class Daysheet : BaseVo<int>
    {
        public virtual DateTime Date { get; set; }
        public virtual int WorkedHour { get; set; }
        public virtual Timesheet Timesheet { get; set; }
    }
}