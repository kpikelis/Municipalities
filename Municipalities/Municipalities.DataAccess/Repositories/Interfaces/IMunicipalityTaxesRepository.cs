using System.Linq;
using Municipalities.Data.Entities.Entities;

namespace Municipalities.DataAccess.Repositories.Interfaces
{
    public interface IMunicipalityTaxesRepository
    {
        IQueryable<MunicipalityTax> GetAllItems();
        MunicipalityTax AddOrUpdate(MunicipalityTax municipalityTax);
        MunicipalityTax GetById(long municipalityTaxId);
    }
}
