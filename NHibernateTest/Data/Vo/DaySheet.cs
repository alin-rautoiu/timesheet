using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateTest.Data.Vo
{
    public class DaySheet:BaseVo<int>
    {
        public virtual  DateTime  Data { get; set; }
        public virtual int  WorkedHour { get; set; }
        public virtual int  TaskNameId { get; set; }
        public Task Task { get; set; }
        public virtual int TimeSheetId  { get; set; }
        public virtual TimeSheet  TimeSheet { get; set; }
    }
}