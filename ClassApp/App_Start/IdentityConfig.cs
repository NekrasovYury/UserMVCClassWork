using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ClassApp.App_Start.IdentityConfig))]
namespace ClassApp.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.CreatePerOwinContext(() => new IdentityDbContext());

            appBuilder.CreatePerOwinContext<UserManager<IdentityUser>>((o,c) => new UserManager<IdentityUser>(c.Get<IUserStore<IdentityUser>>()));

            appBuilder.CreatePerOwinContext<RoleManager<IdentityRole>>((options, context))
            
        }
    }
}