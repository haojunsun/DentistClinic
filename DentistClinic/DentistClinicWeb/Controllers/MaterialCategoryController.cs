using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentistClinic.Core.Services;
using DentistClinic.Infrastructure.Services;
using DentistClinic.Web.Helpers;

namespace DentistClinic.Web.Controllers
{
    public class MaterialCategoryController : ControllerHelper
    {
        private readonly IMaterialCategoryService _material;
        private readonly IHelperServices _helperServices;

        public MaterialCategoryController(IMaterialCategoryService material,  IHelperServices helperServices)
        {
            _material = material;
            _helperServices = helperServices;
        }

        // GET: MaterialCategory
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Del()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
    }
}