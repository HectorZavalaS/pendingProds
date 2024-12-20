using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pendingProds.Startup))]
namespace pendingProds
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
