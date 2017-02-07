using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApplication1.DataStore
{
    public abstract class BaseEntity<T>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public T Id { set; get; }

        public DateTime CreateDateTime { get; set; }

        protected BaseEntity()
        {
            CreateDateTime = DateTime.Now;
        }
    }
}
