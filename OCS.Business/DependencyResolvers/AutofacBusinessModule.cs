using Autofac;
using OCS.DataAccess.Concrete.EntityFramework;
using System.Reflection;
using Module = Autofac.Module;

namespace OCS.Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(OCSDbContext).Assembly)
                    .Where(t => t.Name.EndsWith("Repository") || t.Name.EndsWith("Interceptor"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
