using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Doanweb1.Startup))]
namespace Doanweb1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
