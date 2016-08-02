using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping.Attributes;

namespace NHibernateTest.Data.Vo
{
    [Class(NameType = typeof(Project), SchemaAction = "none", Table = "Project", Mutable = false)]
    [Serializable]
    public class Project : BaseVo<int>
    {
        [Property]
        public virtual string Nume { get; set; }

        [Set (0, Name = "Tasks", Inverse = true)]
        [Key(1, Column = "ProjectId", ForeignKey = "FK_Task_Project")]
        [OneToMany(2, ClassType = typeof(Task))]
        public virtual ISet<Task> Tasks { get; set; }
    }
}