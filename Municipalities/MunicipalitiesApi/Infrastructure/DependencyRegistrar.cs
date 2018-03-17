using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Municipalities.DataAccess.Infrastructure;

namespace MunicipalitiesApi.Infrastructure
{
    public static class DependencyRegistrar
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            Configure(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }

        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterModule(new MunicipalitiesDataAccessModule());
        }
    }
}