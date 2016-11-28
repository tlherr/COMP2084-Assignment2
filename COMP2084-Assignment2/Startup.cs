using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(COMP2084_Assignment2.Startup))]
namespace COMP2084_Assignment2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
