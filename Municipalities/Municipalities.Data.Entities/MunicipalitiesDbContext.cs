using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Municipalities.Data.Entities.Entities;

namespace Municipalities.Data.Entities
{
    public class MunicipalitiesDbContext : DbContext
    {
        public MunicipalitiesDbContext() : base("MunicipalitiesDbContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MunicipalitiesDbContext>());
            Database.CommandTimeout = 0;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public virtual IDbSet<Log> Logs { get; set; }
        public virtual IDbSet<MunicipalityTax> MunicipalityTaxes { get; set; }
        public virtual IDbSet<Municipality> Municipalities { get; set; }
        public virtual IDbSet<TaxPeriod> TaxPeriods { get; set; }
    }
}
