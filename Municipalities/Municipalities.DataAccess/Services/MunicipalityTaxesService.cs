using System;
using Municipalities.Data.Entities.Entities;
using Municipalities.DataAccess.Repositories.Interfaces;
using Municipalities.DataAccess.Services.Interfaces;
using System.Linq;
using Municipalities.Common.Helpers;
using Municipalities.Data.Entities.Enums;

namespace Municipalities.DataAccess.Services
{
    public class MunicipalityTaxesService : IMunicipalityTaxesService
    {
        private readonly IMunicipalityTaxesRepository _taxesRepository;
        private readonly IMunicipalitiesRepository _municipalitiesRepository;

        public MunicipalityTaxesService(IMunicipalityTaxesRepository taxesRepository, IMunicipalitiesRepository municipalitiesRepository)
        {
            _taxesRepository = taxesRepository;
            _municipalitiesRepository = municipalitiesRepository;
        }

        /// <summary>
        /// Gets all Municipality Taxes from database
        /// </summary>
        /// <returns>IQueryable Municipality Taxes list</returns>
        public IQueryable<MunicipalityTax> GetTaxes()
        {
            return _taxesRepository.GetAllItems();
        }

        /// <summary>
        /// Gets Municipality Taxes by Municipality name specified
        /// </summary>
        /// <param name="municipalityName">Municipality name to filter</param>
        /// <returns>Filtered IQueryable Municipality Taxes list</returns>
        public IQueryable<MunicipalityTax> GetTaxes(string municipalityName)
        {
            return GetTaxes().Where(tax => tax.Municipality.Name == municipalityName);
        }

        /// <summary>
        /// Gets Municipality Taxes by Municipality name and Date specified
        /// </summary>
        /// <param name="municipalityName">Municipality name to filter</param>
        /// <param name="date">Date to filter</param>
        /// <returns>Filtered IQueryable Municipality Taxes list</returns>
        public IQueryable<MunicipalityTax> GetTaxes(string municipalityName, DateTime date)
        {
            return GetTaxes(municipalityName).Where(tax =>
                tax.TaxPeriod.DateFrom >= date && tax.TaxPeriod.DateTo >= date);
        }


        /// <summary>
        /// Gets Municipality Taxes by Municipality name, Date and Period specified
        /// </summary>
        /// <param name="municipalityName"></param>
        /// <param name="date"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public IQueryable<MunicipalityTax> GetTaxes(string municipalityName, DateTime date, Period period)
        {
            return GetTaxes(municipalityName, date).Where(tax => tax.TaxPeriod.Period == period);
        }



        public MunicipalityTax AddOrUpdate(MunicipalityTax municipalityTax)
        {
            return _taxesRepository.AddOrUpdate(municipalityTax);
        }

        public MunicipalityTax Create(string name, DateTime date, Period period, decimal tax)
        {
            var municipality = _municipalitiesRepository.GetAllItems().FirstOrDefault(a => a.Name == name);
            if (municipality == default(Municipality))
            {
                municipality = new Municipality
                {
                    Name = name
                };
            }

            var municipalityTax = new MunicipalityTax
            {
                TaxPeriod = new TaxPeriod
                {
                    DateFrom = date.Date,
                    DateTo = date.AddPeriod(period),
                    Period = period
                },
                Municipality = municipality,
                Tax = tax
            };
            return _taxesRepository.AddOrUpdate(municipalityTax);
        }


        public MunicipalityTax GetOrCreate(string name, DateTime date, Period period, decimal tax)
        {
            throw new NotImplementedException();
        }
    }
}
