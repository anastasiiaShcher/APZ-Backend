using Autofac;
using Dvor.Common.Interfaces;
using Dvor.DAL.Factories;
using Dvor.DAL.Repositories;
using Module = Autofac.Module;

namespace Dvor.Web.Infrastructure.Modules
{
    public class DIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Services




            // Repositories

            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();


            // Extra
        }
    }
}