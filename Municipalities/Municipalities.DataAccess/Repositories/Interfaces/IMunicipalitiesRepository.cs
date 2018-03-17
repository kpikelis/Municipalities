using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Municipalities.Data.Entities.Entities;

namespace Municipalities.DataAccess.Repositories.Interfaces
{
    public interface IMunicipalitiesRepository
    {
        IQueryable<Municipality> GetAllItems();
        Municipality AddOrUpdate(Municipality municipality);
        Municipality GetById(long municipalityId);
    }
}
