using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineRetailer.Startup))]
namespace OnlineRetailer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
