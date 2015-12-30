﻿
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DentistClinic.Core.Models;
using DentistClinic.Core.Repositories;
using DentistClinic.Infrastructure;

namespace DentistClinic.Core.Services
{
    public interface IMaterialCategoryService : IDependency
    {
        IEnumerable<MaterialCategory> List();
        void Add(MaterialCategory mc);
        void Update(MaterialCategory mc);
        void Delete(int id);
        MaterialCategory Get(int id);
    }

    public class MaterialCategoryService : IMaterialCategoryService
    {
        private readonly AppDbContext _appDbContext;
        public MaterialCategoryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<MaterialCategory> List()
        {
            return _appDbContext.MaterialCategories.OrderByDescending(x => x.MaterialCategoryId).ToList();
        }

        public void Add(MaterialCategory mc)
        {
             _appDbContext.MaterialCategories.Add(mc);
            _appDbContext.SaveChanges();
        }

        public void Update(MaterialCategory mc)
        {
            _appDbContext.Entry(mc).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var article = _appDbContext.MaterialCategories.Find(id);

            if (article == null)
            {
                return;
            }

            _appDbContext.MaterialCategories.Remove(article);
            _appDbContext.SaveChanges();
        }

        public MaterialCategory Get(int id)
        {
            return _appDbContext.MaterialCategories.Find(id);
        }
    }
}
