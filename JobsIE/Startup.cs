using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobsIE.Startup))]
namespace JobsIE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
