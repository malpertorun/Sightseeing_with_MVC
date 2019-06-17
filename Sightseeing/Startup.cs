using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sightseeing.Startup))]
namespace Sightseeing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
