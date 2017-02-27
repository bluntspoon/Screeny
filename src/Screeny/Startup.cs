using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Screeny.Startup))]
namespace Screeny
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
