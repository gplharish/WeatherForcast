using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeatherForcast.Startup))]
namespace WeatherForcast
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
