using System;
using System.Linq;
using Municipalities.Data.Entities.Entities;
using Municipalities.Data.Entities.Enums;

namespace Municipalities.DataAccess.Services.Interfaces
{
    public interface IMunicipalityTaxesService
    {
        IQueryable<MunicipalityTax> GetTaxes();
        IQueryable<MunicipalityTax> GetTaxes(string municipalityName);
        IQueryable<MunicipalityTax> GetTaxes(string municipalityName, DateTime date);
        IQueryable<MunicipalityTax> GetTaxes(string municipalityName, DateTime date, Period period);

        MunicipalityTax AddOrUpdate(MunicipalityTax municipalityTax);
        MunicipalityTax Create(string name, DateTime date, Period period, decimal tax);
    }
}
