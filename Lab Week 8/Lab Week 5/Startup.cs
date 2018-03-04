using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab_Week_5.Startup))]
namespace Lab_Week_5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
