using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lamweb.Startup))]
namespace Lamweb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
