using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Perfectial.Logging.Sample.Startup))]
namespace Perfectial.Logging.Sample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
