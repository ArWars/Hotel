using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hoteles.Startup))]
namespace Hoteles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
