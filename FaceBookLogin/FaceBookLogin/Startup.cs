using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FaceBookLogin.Startup))]
namespace FaceBookLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
