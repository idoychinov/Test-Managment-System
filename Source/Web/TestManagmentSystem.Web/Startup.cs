using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestManagmentSystem.Web.Startup))]
namespace TestManagmentSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
