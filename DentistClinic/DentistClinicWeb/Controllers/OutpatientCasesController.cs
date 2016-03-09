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
    public class OutpatientCasesController : Controller
    {
        private readonly IOutpatientCasesService _outpatientCases;
        private readonly IHelperServices _helperServices;

        public OutpatientCasesController(IOutpatientCasesService outpatientCases, IHelperServices helperServices)
        {
            _outpatientCases = outpatientCases;
            _helperServices = helperServices;
        }

        // GET: OutpatientCases
        public ActionResult Index(int id)
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public ActionResult List(string key,int page = 1, int size = 20)
        {
            ViewBag.key = key;
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;
            var list = _outpatientCases.GetList(key, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<OutpatientCases>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Del(int id)
        {
            return View();
        }
    }
}