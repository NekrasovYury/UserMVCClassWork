using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(ClassApp.App_Start.IdentityConfig))]
namespace ClassApp.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.CreatePerOwinContext(() => DependencyResolver.Current.GetService<UserManager<IdentityUser>>());
            appBuilder.CreatePerOwinContext(() => DependencyResolver.Current.GetService<RoleManager<IdentityRole>>());

            //appBuilder.CreatePerOwinContext<UserManager<IdentityUser>>((options, context) => new UserManager<IdentityUser>(context.Get<IUserStore<IdentityUser>>()));

            //appBuilder.CreatePerOwinContext<RoleManager<IdentityRole>>((options, context) =>
            //    new RoleManager<IdentityRole>(
            //        new RoleStore<IdentityRole>(context.Get<IdentityDbContext>())));

            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/home/login"),
            });

        }
    }
}