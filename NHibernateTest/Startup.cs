using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NHibernateTest.Startup))]
namespace NHibernateTest
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
        }
    }
}
