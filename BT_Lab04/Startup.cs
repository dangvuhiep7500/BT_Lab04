using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BT_Lab04.Startup))]
namespace BT_Lab04
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
