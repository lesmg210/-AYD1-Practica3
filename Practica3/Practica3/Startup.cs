using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practica3.Startup))]
namespace Practica3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
