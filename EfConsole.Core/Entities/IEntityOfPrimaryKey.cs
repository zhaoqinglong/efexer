using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsole.Core.Entities
{
    /// <summary>
    /// 定义所有实体的泛型接口
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
   public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        TPrimaryKey Id { set; get; }
    }
}
