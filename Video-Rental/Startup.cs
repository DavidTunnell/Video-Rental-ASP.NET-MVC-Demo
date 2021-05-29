using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Video_Rental.Startup))]
namespace Video_Rental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
