using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JBVideoRental.Startup))]
namespace JBVideoRental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
