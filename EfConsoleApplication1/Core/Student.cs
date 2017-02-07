using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfConsoleApplication1.DataStore;

namespace EfConsoleApplication1.Core
{
    public class Student : BaseEntity<int>
    {

        public string Name { set; get; }

        public string Des { set; get; }


    }

    public class Teacher : BaseEntity<int>
    {
        public string Name { set; get; }

        public int Age { set; get; }

        /// <summary>
        /// 教授班级
        /// </summary>
        public string TeachClass { set; get; }

    }

    /// <summary>
    /// 年纪
    /// </summary>
    public class Grade : BaseEntity<Guid>
    {
        /// <summary>
        /// 班级名称
        /// </summary>
        public  string GradeName { set; get; }

        /// <summary>
        /// 几年级
        /// </summary>
        public int StuGrade { set; get; }

        /// <summary>
        /// 班级
        /// </summary>
        public  int StuClass { set; get; }

        /// <summary>
        /// 学生人数
        /// </summary>
        public string StuNum { set; get; }
    }
}
