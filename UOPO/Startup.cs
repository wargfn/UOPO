using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UOPO.Startup))]
namespace UOPO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
