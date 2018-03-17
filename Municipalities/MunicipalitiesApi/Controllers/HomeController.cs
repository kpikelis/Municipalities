using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Municipalities.Common.Helpers;
using Municipalities.Common.Logging;
using Municipalities.Data.Entities.Entities;
using Municipalities.DataAccess.Repositories.Interfaces;
using MunicipalitiesApi.Models;

namespace MunicipalitiesApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMunicipalitiesRepository _repository;
        private readonly IDatabaseLogger _logger;
        public HomeController(IMunicipalitiesRepository repository, IDatabaseLogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase uploadFile)
        {
            if (uploadFile != null && uploadFile.ContentLength > 0)
            {
                _logger.Info("Deserializing file object");
                var municipalitityList = FileReader.DeserializeXmlFileToObject<MunicipalitityList>(uploadFile.InputStream);
                foreach (var municipalitity in municipalitityList.Municipalities)
                {
                    _logger.Info($"Managing Municipalitity { municipalitity.Name }");
                    //check for unique
                    var existingItem = _repository.GetAllItems().FirstOrDefault(a => a.Name == municipalitity.Name);
                    if (existingItem != default(Municipality))
                    {
                        _logger.Info("Municipalitity already exists on database");
                        continue;
                    }

                    _logger.Info("Adding new Municipalitity");
                    _repository.AddOrUpdate(municipalitity);
                }
            }

            return RedirectToAction("Index");
        }
    }
}