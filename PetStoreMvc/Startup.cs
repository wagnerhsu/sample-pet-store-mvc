using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetStoreMvc.Startup))]
namespace PetStoreMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
