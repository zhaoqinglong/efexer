using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace EfConsoleApplication1.Core
{
    public class Context :DbContext
    {
        public Context():base("name=conn")
        {
            #region 
            #endregion
        }

        /// <summary>
        /// 当传递连接字符串时，调用此构造函数
        /// </summary>
        /// <param name="connstring"></param>
        public Context(string connstring) : base(connstring)
        {
            
        }

        public IDbSet<Student> Stus { set; get; }

        public IDbSet<Teacher> Teachers { set; get; }

        public IDbSet<Grade> Grades { set; get; }


    }

   

}
