using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(escuela.webapp.Startup))]
namespace escuela.webapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
