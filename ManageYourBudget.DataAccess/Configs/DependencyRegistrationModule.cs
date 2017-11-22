using Autofac;

namespace ManageYourBudget.DataAccess.Configs
{
    public class DependencyRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IRepository).Assembly).AsImplementedInterfaces().InstancePerRequest();
            base.Load(builder);
        }
    }
}