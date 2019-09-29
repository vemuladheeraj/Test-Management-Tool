using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Defect_Tracker.Startup))]
namespace Defect_Tracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
