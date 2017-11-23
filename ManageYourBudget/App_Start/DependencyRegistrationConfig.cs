using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using ManageYourBudget.BusinessLogicLayer.IdentityWrappers;
using ManageYourBudget.BusinessLogicLayer.Interfaces;
using ManageYourBudget.DataAccessLayer;
using ManageYourBudget.DataAccessLayer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace ManageYourBudget
{
    public static class DependencyRegistrationConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            RegisterIdentityThings(builder);

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            RegisterRepositories(builder);
            RegisterServices(builder);

            var mapper = MappingConfiguration.InitializeAutoMapper().CreateMapper();
            builder.RegisterInstance<IMapper>(mapper);
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterIdentityThings(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<User>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication)
                .InstancePerRequest();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IService).Assembly).AsImplementedInterfaces().InstancePerRequest();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IRepository).Assembly).AsImplementedInterfaces().InstancePerRequest();
        }
    }
}