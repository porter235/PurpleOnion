using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PurpleOnion.Startup))]
namespace PurpleOnion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
