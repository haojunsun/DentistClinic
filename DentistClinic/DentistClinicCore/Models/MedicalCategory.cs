using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistClinic.Core.Models
{
    public class MedicalCategory
    {
        public int MedicalCategoryId { get; set; }

        public string TeethUp { get; set; }

        public string TeethDown { get; set; }

        public string Diagnosis { get; set; }
    }
}
