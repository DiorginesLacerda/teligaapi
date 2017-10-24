using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AquiVoto.Startup))]
namespace AquiVoto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
