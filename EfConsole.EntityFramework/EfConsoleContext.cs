using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfConsole.Core.School;

namespace EfConsole.EntityFramework
{
    public class EfConsoleContext : DbContext
    {
        public EfConsoleContext() : base("name=conn")
        {
            #region

            #endregion
        }

        /// <summary>
        /// 当传递连接字符串时，调用此构造函数
        /// </summary>
        /// <param name="connstring"></param>
        public EfConsoleContext(string connstring) : base(connstring)
        {

        }

        public IDbSet<Student> Students { set; get; }

        public IDbSet<Teacher> Teachers { set; get; }

        public IDbSet<Grade> Grades { set; get; }

        public IDbSet<School> Schools { set; get; }


    }
}
