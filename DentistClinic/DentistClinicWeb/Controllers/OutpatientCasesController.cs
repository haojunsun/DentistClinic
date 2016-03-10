﻿using System;
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
    public class OutpatientCasesController : ControllerHelper
    {
        private readonly IOutpatientCasesService _outpatientCases;
        private readonly IHelperServices _helperServices;
        private readonly IMaterialCategoryService _material;
        public OutpatientCasesController(IOutpatientCasesService outpatientCases, IHelperServices helperServices, IMaterialCategoryService material)
        {
            _outpatientCases = outpatientCases;
            _helperServices = helperServices;
            _material = material;
        }

        public ActionResult Index(int id)
        {
            var oc = _outpatientCases.Get(id);
            return View(oc);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public ActionResult List(string key, int page = 1, int size = 20)
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
            TreeBind(0);
            return View();
        }

        [HttpPost]
        public ActionResult Add(string name, string Sex, string age, string phone, string address, string Complaint, string MedicalHistory, string Checkup, string Treatment
            , int MaterialCategory, string Cost, string IsWear)
        {
            var cases = new OutpatientCases();
            cases.AddTime = DateTime.Now;
            cases.VisitingTime = cases.AddTime.Value.ToShortDateString();
            cases.Name = name;
            cases.age = age;
            cases.Phone = phone;
            cases.Address = address;
            cases.Complaint = Complaint;
            cases.MedicalHistory = MedicalHistory;

            cases.TeethUpLeft = Request.Form["TeethUpLeft"];
            cases.TeethUpRight = Request.Form["TeethUpRight"];
            cases.TeethDownLeft = Request.Form["TeethDownLeft"];
            cases.TeethDownRight = Request.Form["TeethDownRight"];
            cases.Sex = "男";
            if (Sex=="1")
                cases.Sex = "女";

            cases.Checkup = Checkup;
            cases.Treatment = Treatment;
            cases.Cost = decimal.Parse(Cost);
            cases.IsWear = false || IsWear == "0";
            cases.MaterialCategory = _material.Get(MaterialCategory);
            _outpatientCases.Add(cases);
            return JumpUrl("List", "系统设置-材料类别-创建成功！");
        }

        public ActionResult Edit(int id)
        {
            var oc = _outpatientCases.Get(id);
            TreeBind(oc.MaterialCategory.MaterialCategoryId);
            return View(oc);
        }
        [HttpPost]
        public ActionResult Edit(OutpatientCases oc)
        {
            var old = _outpatientCases.Get(oc.OutpatientCasesId);
            //old.Title = article.Title;
            //old.Body = article.Body.Replace(" ", "&nbsp").Replace("\r\n", "<br />"); ;
            //old.ManagerName = _simpleAccount.GetUserElement().Name;
            //old.IsDraft = article.IsDraft;
            //old.IsRelease = old.IsDraft == 0 ? 1 : 0;

            _outpatientCases.Update(old);
            return JumpUrl("List", "编辑成功！");
        }

        public ActionResult Del(int id)
        {
            var old = _outpatientCases.Get(id);
            if (old == null)
                return JumpUrl("List", "id错误");
            _material.Delete(id);
            return JumpUrl("List", "删除成功");
        }

        /// <summary>
        /// 绑定类别
        /// </summary>
        /// <param name="_pid"></param>
        private void TreeBind(int _pid)
        {
            List<MaterialCategory> list = _material.List().ToList();
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (MaterialCategory contry in list)
            {
                string Title = contry.MaterialName;

                if (contry.MaterialCategoryId == _pid)
                {
                    selectList.Add(new SelectListItem()
                    {
                        Value = contry.MaterialCategoryId.ToString(),
                        Text = Title,
                        Selected = true
                    });
                }
                else
                {
                    selectList.Add(new SelectListItem()
                    {
                        Value = contry.MaterialCategoryId.ToString(),
                        Text = Title
                    });
                }
            }
            ViewBag.MaterialCategory = selectList;
        }
    }
}