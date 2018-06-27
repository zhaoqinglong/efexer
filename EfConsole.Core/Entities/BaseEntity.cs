using System;

namespace EfConsole.Core.Entities
{
    /// <summary>
    /// 基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public  class BaseEntity<T>
    {
        protected BaseEntity()
        {
            CreateDateTime = DateTime.Now;
        }

        /// <summary>
        /// 主键
        /// </summary>
        public T Id { set; get; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDateTime { get; set; }
     
    }
}