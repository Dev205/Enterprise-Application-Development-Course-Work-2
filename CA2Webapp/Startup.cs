using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CA2Webapp.Startup))]
namespace CA2Webapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
