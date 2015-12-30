using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DentistClinic.Web.Startup))]
namespace DentistClinic.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
