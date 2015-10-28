using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FireWarden.Startup))]
namespace FireWarden
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
