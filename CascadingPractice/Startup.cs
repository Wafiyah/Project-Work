using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CascadingPractice.Startup))]
namespace CascadingPractice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
