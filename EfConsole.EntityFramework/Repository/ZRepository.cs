using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfConsole.Core.Entities;

namespace EfConsole.EntityFramework.Repository
{

    /// <summary>
    /// 不指定TEntity, TPrimaryKey的仓储基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class ZRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<EfConsoleContext, TEntity, TPrimaryKey>

        where TEntity : class, IEntity<TPrimaryKey>
    {
        public ZRepositoryBase(IDbContextProvider<EfConsoleContext> contextProvider) : base(contextProvider)
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ZRepositoryBase<TEntity> : ZRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        public ZRepositoryBase(IDbContextProvider<EfConsoleContext> contextProvider) : base(contextProvider)
        {

        }
    }

}
