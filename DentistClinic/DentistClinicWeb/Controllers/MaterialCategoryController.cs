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
    /// <summary>
    /// 材料 管理
    /// </summary>
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
            var old = _material.Get(id);
            if (old == null)
                return JumpUrl("List", "id错误");
            _material.Delete(id);
            return JumpUrl("List", "删除成功");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string materialName)
        {
            if (string.IsNullOrEmpty(materialName))
            {
                return JumpUrl("List", "材料类别不能为空!");
            }
            
            var mn = new MaterialCategory();
            mn.MaterialName = materialName;
            _material.Add(mn);
            return JumpUrl("List", "系统设置-材料类别-创建成功！");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var article = _material.Get(id);
            if (article == null)
            {
                return JumpUrl("List", "id错误!");
            }
            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(MaterialCategory article)
        {
            var old = _material.Get(article.MaterialCategoryId);
            old.MaterialName = article.MaterialName;
            _material.Update(old);
            return JumpUrl("List", "系统设置-材料类别-编辑成功！");
        }
    }
}