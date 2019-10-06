using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RealTimeChessAlphaSevenFrontEnd.Startup))]
namespace RealTimeChessAlphaSevenFrontEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
