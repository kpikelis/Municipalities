using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using Municipalities.Common.Logging;
using Municipalities.Data.Entities;
using Municipalities.Data.Entities.Entities;
using Municipalities.DataAccess.Repositories.Interfaces;

namespace Municipalities.DataAccess.Repositories
{
    public class MunicipalityTaxesRepository : IMunicipalityTaxesRepository
    {
        private readonly MunicipalitiesDbContext _dbContext;
        private readonly IDatabaseLogger _logger;

        public MunicipalityTaxesRepository(MunicipalitiesDbContext dbContext, IDatabaseLogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IQueryable<MunicipalityTax> GetAllItems()
        {
            return _dbContext.MunicipalityTaxes
                .Include(a=>a.TaxPeriod)
                .Include(a => a.Municipality);
        }

        public MunicipalityTax AddOrUpdate(MunicipalityTax municipalityTax)
        {
            _dbContext.Entry(municipalityTax).State = municipalityTax.MunicipalityId > 0 ? EntityState.Modified : EntityState.Added;
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                _logger.Error(dbEx, $"Failed to execute Entity Add Or Update: {typeof(MunicipalityTax).Name}.");
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                        throw new Exception(validationError.ErrorMessage, dbEx);
                    }
                }
            }
            return municipalityTax;
        }

        public MunicipalityTax GetById(long municipalityTaxId)
        {
            return _dbContext.MunicipalityTaxes.Find(municipalityTaxId);
        }
    }
}
