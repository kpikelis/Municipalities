using Autofac;
using Municipalities.Common.Logging;
using Municipalities.Data.Entities;
using Municipalities.DataAccess.Repositories;
using Municipalities.DataAccess.Repositories.Interfaces;
using Municipalities.DataAccess.Services;
using Municipalities.DataAccess.Services.Interfaces;

namespace Municipalities.DataAccess.Infrastructure
{
    public class MunicipalitiesDataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //db
            builder.RegisterType<MunicipalitiesDbContext>().InstancePerLifetimeScope();
            //configs
            builder.RegisterType<DatabaseLogger>().As<IDatabaseLogger>();
            //repositories
            builder.RegisterType<MunicipalityTaxesRepository>().As<IMunicipalityTaxesRepository>();
            builder.RegisterType<MunicipalitiesRepository>().As<IMunicipalitiesRepository>();

            //services
            builder.RegisterType<MunicipalityTaxesService>().As<IMunicipalityTaxesService>();
        }
    }
}
