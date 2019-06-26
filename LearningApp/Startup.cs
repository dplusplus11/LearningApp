using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningApp.Startup))]
namespace LearningApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
