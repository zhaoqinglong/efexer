using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfConsole.Core.School
{
    public class Teacher : BaseEntity<int>
    {
        public string Name { set; get; }

        public int Age { set; get; }

        /// <summary>
        /// 教授班级
        /// </summary>
        public string TeachClass { set; get; }

    }
}