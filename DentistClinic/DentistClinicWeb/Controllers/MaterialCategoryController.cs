using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentistClinic.Core.Models;
using DentistClinic.Core.Services;
using DentistClinic.Infrastructure.Services;
using DentistClinic.Web.Helpers;
using PagedList;

namespace DentistClinic.Web.Controllers
{
    public class MaterialCategoryController : ControllerHelper
    {
        private readonly IMaterialCategoryService _material;
        private readonly IHelperServices _helperServices;

        public MaterialCategoryController(IMaterialCategoryService material, IHelperServices helperServices)
        {
            _material = material;
            _helperServices = helperServices;
        }

        public ActionResult List(int page = 1, int size = 20)
        {
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;
            var list = _material.List(pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<MaterialCategory>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }

        public ActionResult Del(int id)
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }
    }
}