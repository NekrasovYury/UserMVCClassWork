using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace ClassApp.App_Start
{
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterType(container);
            return container;
        });

        public static IUnityContainer GetConfiguresContainer()
        {
            return container.Value;
        }

        public static void RegisterType(IUnityContainer container)
        {
            container.RegisterType<IdentityDbContext>(new HierarchicalLifetimeManager());

            // user manager
            container.RegisterType<IUserStore<IdentityUser>, UserStore<IdentityUser>>(
                new HierarchicalLifetimeManager(),
                new InjectionConstructor(
                    new ResolvedParameter<IdentityDbContext>()
                    ));

            container.RegisterType<UserManager<IdentityUser>>(
                new HierarchicalLifetimeManager());

            //role manager
            //
            container.RegisterType<IRoleStore<IdentityRole, string>, RoleStore<IdentityRole>>(
                new HierarchicalLifetimeManager(),
                new InjectionConstructor(
                    new ResolvedParameter<IdentityDbContext>()
                ));

            container.RegisterType<RoleManager<IdentityRole>>(
                new HierarchicalLifetimeManager());
        }
    }
}