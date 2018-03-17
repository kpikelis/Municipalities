using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Municipalities.Common.Logging;
using Municipalities.Data.Entities;
using Municipalities.Data.Entities.Entities;
using Municipalities.DataAccess.Repositories.Interfaces;

namespace Municipalities.DataAccess.Repositories
{
    public class MunicipalitiesRepository : IMunicipalitiesRepository
    {
        private readonly MunicipalitiesDbContext _dbContext;
        private readonly IDatabaseLogger _logger;

        public MunicipalitiesRepository(MunicipalitiesDbContext dbContext, IDatabaseLogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IQueryable<Municipality> GetAllItems()
        {
            return _dbContext.Municipalities;
        }

        public Municipality AddOrUpdate(Municipality municipality)
        {
            _dbContext.Entry(municipality).State = municipality.MunicipalityId > 0 ? EntityState.Modified : EntityState.Added;
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
            return municipality;
        }

        public Municipality GetById(long municipalityId)
        {
            return _dbContext.Municipalities.Find(municipalityId);
        }
    }
}

