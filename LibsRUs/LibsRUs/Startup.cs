using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibsRUs.Startup))]
namespace LibsRUs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
