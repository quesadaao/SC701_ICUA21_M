using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCEFW7.Startup))]
namespace MVCEFW7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
