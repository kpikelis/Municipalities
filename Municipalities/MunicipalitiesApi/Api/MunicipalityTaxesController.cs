using System;
using System.Collections.Generic;
using System.Web.Http;
using Municipalities.DataAccess.Services.Interfaces;
using Municipalities.Data.Entities.Entities;
using Municipalities.Common.Logging;
using Municipalities.Data.Entities.Enums;

namespace MunicipalitiesApi.Api
{
    [RoutePrefix("taxes")]
    public class MunicipalityTaxesController : ApiController
    {
        private readonly IMunicipalityTaxesService _municipalityTaxesService;
        private readonly IDatabaseLogger _logger;

        public MunicipalityTaxesController(IMunicipalityTaxesService municipalityTaxesService, IDatabaseLogger logger)
        {
            _municipalityTaxesService = municipalityTaxesService;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<MunicipalityTax> Get()
        {
            return _municipalityTaxesService.GetTaxes();
        }

        [HttpGet]
        [Route("{name}")]
        public IEnumerable<MunicipalityTax> Get(string name)
        {
            _logger.Info($"Getting Municipality Taxes by name: {name}.");
            return _municipalityTaxesService.GetTaxes(name);
        }

        [HttpGet]
        [Route("{name}/{date}")]
        public IEnumerable<MunicipalityTax> Get(string name, DateTime date)
        {
            _logger.Info($"Getting Municipality Taxes by name: '{name}' and date: '{date}'.");
            return _municipalityTaxesService.GetTaxes(name, date);
        }

        [HttpGet]
        [Route("{name}/{date}/{period}")]
        public IEnumerable<MunicipalityTax> Get(string name, DateTime date, Period period)
        {
            return _municipalityTaxesService.GetTaxes(name, date, period);
        }

        [HttpGet]
        [Route("create/{name}/{date:DateTime}/{period:int}/{tax:decimal}/")]
        public MunicipalityTax GetOrCreate(string name, DateTime date, Period period, decimal tax)
        {
            return _municipalityTaxesService.Create(name, date, period, tax);
        }

        [HttpPost]
        [Route("")]
        public MunicipalityTax Post(MunicipalityTax municipalityTax)
        {
            return _municipalityTaxesService.AddOrUpdate(municipalityTax);
        }
    }
}

