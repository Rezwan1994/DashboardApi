using Autofac;

namespace DashboardAPI
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<TestClass>().As<ITestClass1>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<IndexModel>().AsSelf();

            base.Load(builder);
        }
    }
}
