using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(meet_up.Startup))]
namespace meet_up
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
