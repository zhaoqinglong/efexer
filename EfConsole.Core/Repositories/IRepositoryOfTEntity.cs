using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfConsole.Core.Entities;

namespace EfConsole.Core.Repositories
{
    /// <summary>
    /// 主键为int的仓储接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity<int>
    {
    }
}
