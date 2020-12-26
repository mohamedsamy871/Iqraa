using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Iqraa.Startup))]
namespace Iqraa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
