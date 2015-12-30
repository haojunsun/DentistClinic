using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistClinic.Core.Models
{
    /// <summary>
    /// 材料
    /// </summary>
    public class MaterialCategory
    {
        /// <summary>
        /// id
        /// </summary>
        public int MaterialCategoryId { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        public string MaterialName { get; set; }
    }
}
