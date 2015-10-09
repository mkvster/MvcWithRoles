using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcWithRoles.Web.Startup))]
namespace MvcWithRoles.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
