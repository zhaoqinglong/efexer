﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EfConsole.Core.Entities;

namespace EfConsole.Core.School
{
    public class Student : BaseEntity<int>
    {

        public string Name { set; get; }

        public string Des { set; get; }


    }
}