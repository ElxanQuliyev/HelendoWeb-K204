using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelendoWebK204.Startup))]
namespace HelendoWebK204
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
