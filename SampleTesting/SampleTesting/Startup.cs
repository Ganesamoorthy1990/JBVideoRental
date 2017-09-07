using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleTesting.Startup))]
namespace SampleTesting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
