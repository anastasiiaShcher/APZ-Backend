﻿using Autofac;
using Dvor.BLL.Infrastructure;
using Dvor.BLL.Services;
using Dvor.Common.Entities;
using Dvor.Common.Interfaces;
using Dvor.Common.Interfaces.Services;
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

            builder.RegisterType<DishService>().As<IDishService>().InstancePerLifetimeScope();


            // Repositories

            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<Repository<Dish>>().As<IRepository<Dish>>().InstancePerLifetimeScope();


            // Extra

            builder.RegisterType<MailService>().As<IMailService>().InstancePerLifetimeScope();
        }
    }
}