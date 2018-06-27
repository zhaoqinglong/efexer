using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EfConsole.Core.Entities;

namespace EfConsole.Core.School
{
    public class School:Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { set; get; }


    }
}