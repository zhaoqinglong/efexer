using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsole.Core.Entities
{
    /// <summary>
    /// 常用的接口类型
    /// </summary>
    public interface IEntity : IEntity<int>
    {
    }
}
