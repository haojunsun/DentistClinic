
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DentistClinic.Core.Models;
using DentistClinic.Core.Repositories;
using DentistClinic.Infrastructure;

namespace DentistClinic.Core.Services
{
    public interface IMedicalCategoryService : IDependency
    {
        IEnumerable<MedicalCategory> List();
        void Add(MedicalCategory mc);
        void Update(MedicalCategory mc);
        void Delete(int id);
        MedicalCategory Get(int id);
    }

    public class MedicalCategoryService : IMedicalCategoryService
    {
        private readonly AppDbContext _appDbContext;
        public MedicalCategoryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<MedicalCategory> List()
        {
            return _appDbContext.MedicalCategories.OrderByDescending(x => x.MedicalCategoryId).ToList();
        }

        public void Add(MedicalCategory mc)
        {
            _appDbContext.MedicalCategories.Add(mc);
            _appDbContext.SaveChanges();
        }

        public void Update(MedicalCategory mc)
        {
            _appDbContext.Entry(mc).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var article = _appDbContext.MedicalCategories.Find(id);

            if (article == null)
            {
                return;
            }

            _appDbContext.MedicalCategories.Remove(article);
            _appDbContext.SaveChanges();
        }

        public MedicalCategory Get(int id)
        {
            return _appDbContext.MedicalCategories.Find(id);
        }
    }
}
