using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EfConsole.Core.Entities;

namespace EfConsole.Core.School
{
    /// <summary>
    /// 年级
    /// </summary>
    public class Grade : BaseEntity<Guid>
    {
        /// <summary>
        /// 班级名称
        /// </summary>
        public string GradeName { set; get; }

        /// <summary>
        /// 几年级
        /// </summary>
        public int StuGrade { set; get; }

        /// <summary>
        /// 班级
        /// </summary>
        public int StuClass { set; get; }

        /// <summary>
        /// 学生人数
        /// </summary>
        public string StuNum { set; get; }
    }
}