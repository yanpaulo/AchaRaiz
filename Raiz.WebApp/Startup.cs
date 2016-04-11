using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Raiz.WebApp.Startup))]
namespace Raiz.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
