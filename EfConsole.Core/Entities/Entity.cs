using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfConsole.Core.Entities
{
    /// <summary>
    /// 实体基类
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract  class Entity<TPrimaryKey> :IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }

    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class Entity : Entity<int>, IEntity
    {
        
    }
}