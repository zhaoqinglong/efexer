using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApplication1.DataStore
{
    public abstract class EfRepositoryBase<T, TKey> : IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        
        //todo 此处应该调整为依赖注入
        protected EfRepositoryBase()
        {
            UnitOfWork =new  EfUnitOfWork();
        } 
       

        /// <summary>
        /// Ef工作单元
        /// </summary>
        protected EfUnitOfWork UnitOfWork { get; private set; }

        public T this[TKey id]
        {
            get { return Find(id); }
        }

        /// <summary>
        /// 添加新的实体
        /// </summary>
        /// <param name="t"></param>
        public void Insert(T t)
        {
            UnitOfWork.Set<T>().Add(t);
            UnitOfWork.CommitByStart();
        }
 
        /// <summary>
        /// 添加新的实体
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            UnitOfWork.Set<T>().Add(entity);
            UnitOfWork.CommitByStart();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities"></param>
        public void Add(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                return;
            }
            UnitOfWork.Set<T>().AddRange(entities);
            UnitOfWork.CommitByStart();

        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        void IRepository<T, TKey>.Update(T entity)
        {
            UnitOfWork.Entry(entity).State=EntityState.Modified;
            UnitOfWork.CommitByStart();          
        }

        /// <summary>
        /// 通过主键移除
        /// </summary>
        /// <param name="id"></param>
        public void Remove(TKey id)
        {
            var entity = Find(id);
            if(entity==null)
                return;
            Remove(entity);
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            UnitOfWork.Set<T>().Remove(entity);
            UnitOfWork.CommitByStart();           
        }

        /// <summary>
        /// 返回所有
        /// </summary>
        /// <returns></returns>
        public List<T> FindAll()
        {
            return Find().ToList();           
        }

        /// <summary>
        /// 返回可查询结果集
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> Find()
        {
            return UnitOfWork.Set<T>();          
        }

        /// <summary>
        /// 通过主键查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find(params object[] id)
        {
            return UnitOfWork.Set<T>().Find(id);           
        }

        /// <summary>
        /// 通过主键集合查找
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<T> Find(IEnumerable<TKey> ids)
        {
            if (ids == null)
            {
                return null;
            }
            return Find().Where(x => ids.Contains(x.Id)).ToList();
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return Find().Any(predicate);
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
           UnitOfWork.Commit();
        }

        /// <summary>
        /// 获取工作单元
        /// </summary>
        /// <returns></returns>
        public IUnitOfWork GetUnitOfWork()
        {
            return UnitOfWork;
        }
    }
}
