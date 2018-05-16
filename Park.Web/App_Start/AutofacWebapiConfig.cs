using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Park.Data;
using Park.Data.Infrastructure;
using Park.Data.Repositories;
using Park.Services;
using Park.Services.Abstract; 
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Park.Web.App_Start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // EF ParkContext
            builder.RegisterType<ParkContext>()
                   .As<DbContext>()
                   .InstancePerRequest();

            builder.RegisterType<DbFactory>()
                .As<IDbFactory>()
                .InstancePerRequest();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();
           
            builder.RegisterGeneric(typeof(EntityBaseRepository<>))
                   .As(typeof(IEntityBaseRepository<>))
                   .InstancePerRequest();
             

            // Generic Data Repository Factory
            //builder.RegisterType<DataRepositoryFactory>()
            //    .As<IDataRepositoryFactory>().InstancePerRequest();
             
            builder.RegisterType<CommonService>()
               .As<ICommonService>()
               .InstancePerRequest();
             

            Container = builder.Build();

            return Container;
        }
    }
}