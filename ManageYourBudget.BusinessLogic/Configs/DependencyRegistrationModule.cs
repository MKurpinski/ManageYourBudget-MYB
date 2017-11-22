using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace ManageYourBudget.BusinessLogic.Configs
{
    public class DependencyRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IService).Assembly).AsImplementedInterfaces().InstancePerRequest();
            base.Load(builder);
        }
    }
}