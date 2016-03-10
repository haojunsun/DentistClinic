using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistClinic.Core.Models;
using DentistClinic.Core.Repositories;
using DentistClinic.Infrastructure;

namespace DentistClinic.Core.Services
{
    public interface IOutpatientCasesService : IDependency
    {
        IEnumerable<OutpatientCases> List();
        void Add(OutpatientCases oc);
        void Update(OutpatientCases oc);
        void Delete(int id);
        OutpatientCases Get(int id);

        IEnumerable<OutpatientCases> GetList(string Name, int pageIndex, int pageSize, ref int totalCount);
    }

   public class OutpatientCasesService:IOutpatientCasesService
    {
        private readonly AppDbContext _appDbContext;
        public OutpatientCasesService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

       public IEnumerable<OutpatientCases> List()
       {
           return _appDbContext.OutpatientCases.OrderByDescending(x => x.AddTime).ToList();
       }

       public void Add(OutpatientCases oc)
       {
           _appDbContext.OutpatientCases.Add(oc);
           _appDbContext.SaveChanges();
       }

       public void Update(OutpatientCases oc)
       {
           _appDbContext.Entry(oc).State = EntityState.Modified;
           _appDbContext.SaveChanges();
       }

       public void Delete(int id)
       {
           var article = _appDbContext.OutpatientCases.Find(id);

           if (article == null)
           {
               return;
           }

           _appDbContext.OutpatientCases.Remove(article);
           _appDbContext.SaveChanges();
       }

       public OutpatientCases Get(int id)
       {
           return _appDbContext.OutpatientCases.Find(id);
       }

       public IEnumerable<OutpatientCases> GetList(string Name, int pageIndex, int pageSize, ref int totalCount)
       {
           if (!string.IsNullOrEmpty(Name))
           {
               var list = (from p in _appDbContext.OutpatientCases
                   where p.Name.Contains(Name)
                   orderby p.AddTime descending
                   select p).Skip((pageIndex - 1)*pageSize).Take(pageSize);
               totalCount = _appDbContext.OutpatientCases.Count(x => x.Name.Contains(Name));
               return list.ToList();
           }
           else
           {
               var list = (from p in _appDbContext.OutpatientCases
                           orderby p.AddTime descending
                           select p).Skip((pageIndex - 1) * pageSize).Take(pageSize);
               totalCount = _appDbContext.OutpatientCases.Count();
               return list.ToList();
           }
       }
    }
}
