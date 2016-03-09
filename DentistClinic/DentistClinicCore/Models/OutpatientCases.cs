using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistClinic.Core.Models
{
    public class OutpatientCases
    {
        public int OutpatientCasesId { get; set; }

        /// <summary>
        /// 就诊时间
        /// </summary>
        public DateTime? VisitingTime { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int age { get; set; }

        /// <summary>
        /// 主诉
        /// </summary>
        public string Complaint { get; set; }

        /// <summary>
        /// 病史
        /// </summary>
        public string MedicalHistory { get; set; }


        /// <summary>
        /// 查体
        /// </summary>
        public virtual MedicalCategory Checkup { get; set; }

        /// <summary>
        /// 治疗
        /// </summary>
        public virtual MedicalCategory Treatment { get; set; }

        /// <summary>
        /// 牙位 上
        /// </summary>
        public string TeethUp { get; set; }

        /// <summary>
        /// 牙位 下
        /// </summary>
        public string TeethDown { get; set; }

        /// <summary>
        /// 完成日期
        /// </summary>
        public DateTime? CompleteTime { get; set; }

        /// <summary>
        /// 戴入
        /// </summary>
        public bool IsWear { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public virtual MaterialCategory MaterialCategory { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 费用
        /// </summary>
        public decimal Cost { get; set; }

        public DateTime? AddTime { get; set; }

        public string Phone { get; set; }
    }
}
