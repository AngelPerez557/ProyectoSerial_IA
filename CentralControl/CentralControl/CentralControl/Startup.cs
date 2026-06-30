using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CentralControl.Startup))]
namespace CentralControl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
