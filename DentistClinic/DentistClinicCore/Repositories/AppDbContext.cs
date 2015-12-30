using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistClinic.Infrastructure;

namespace DentistClinic.Core.Repositories
{
    public class AppDbContext : DbContext, IDependencyPerRequest
    {
        public AppDbContext()
            : base("DefaultConnection")
        {
        }

        // public DbSet<OutpatientCases> Articles { get; set; }
    }
}
