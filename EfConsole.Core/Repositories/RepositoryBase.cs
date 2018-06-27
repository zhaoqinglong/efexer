using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using EfConsole.Core.Entities;

namespace EfConsole.Core.Repositories
{
    public abstract class RepositoryBase<TEntity, TPrimaryKey>:IRepository<TEntity,TPrimaryKey>
        where TEntity:class ,IEntity<TPrimaryKey>
    {
        #region Select/Get/Query

        /// <summary>
        /// 查询所有实体
        /// </summary>
        /// <returns></returns>
       public abstract IQueryable<TEntity> GetAll();

        /// <summary>
        /// 查询所有实体列表
        /// </summary>
        /// <returns></returns>
        public virtual List<TEntity> GetAllList()
        {
            return GetAll().ToList();
        }

        /// <summary>
        /// 查询所有实体列表异步方法
        /// </summary>
        /// <returns></returns>
        public virtual Task<List<TEntity>> GetAllListAsync()
        {
            return Task.FromResult(GetAllList());
        }

        /// <summary>
        /// 根据条件筛选出所有的实体列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        /// <summary>
        /// 根据条件查询所有实体列表异步方法
        /// </summary>
        /// <returns></returns>
        public virtual Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(GetAllList(predicate));
        }

        /// <summary>
        /// 根据条件查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryMethod"></param>
        /// <returns></returns>
        public virtual T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
        {
            return queryMethod(GetAll());
        }


        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity Get(TPrimaryKey id)
        {
            var entity = FirstOrDefault(id);
            if (entity==null)
            {
                throw new Exception("找不到相关实体");
            }
            return entity;
        }

        /// <summary>
        /// 根据主键id查询实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity FirstOrDefault(TPrimaryKey id)
        {
            return GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        /// <summary>
        /// 根据表达式查询符合条件的默认第一个实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }
        #endregion

        #region Insert

        /// <summary>
        /// 向数据库写入实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract TEntity Insert(TEntity entity);

        /// <summary>
        /// 向数据库写入实体，并返回主键
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual TPrimaryKey InsertAndGetId(TEntity entity)
        {
            return Insert(entity).Id;
        }

        /// <summary>
        /// 向数据库写入或更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        //TEntity InsertOrUpdate(TEntity entity);

        /// <summary>
        /// 向数据库写入或更新实体，并返回主键
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        //TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);


        #endregion

        #region Update

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">Entity</param>
        public abstract TEntity Update(TEntity entity);

        /// <summary>
        ///根据主键id更新实体
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <param name="updateAction">待更新的部分实体值</param>
        /// <returns>Updated entity</returns>
        public virtual TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
        {
            var entity = Get(id);
            updateAction(entity);
            return entity;
        }
        #endregion


        #region Delete

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        public abstract void Delete(TEntity entity);

        /// <summary>
        /// 根据id删除实体
        /// </summary>
        /// <param name="id">Primary key of the entity</param>
        public abstract void Delete(TPrimaryKey id);


        /// <summary>
        /// 根据查询条件删除实体
        /// </summary>
        /// <param name="predicate">A condition to filter entities</param>
        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var entity in GetAll().Where(predicate).ToList())
            {
                Delete(entity);
            }
        }
        #endregion

        #region 聚合(aggregate)

        /// <summary>
        /// 统计实体个数
        /// </summary>
        /// <returns>Count of entities</returns>
        public virtual int Count()
        {
            return GetAll().Count();
        }


        /// <summary>
        /// 根据查询条件统计实体个数
        /// </summary>
        /// <param name="predicate">A method to filter count</param>
        /// <returns>Count of entities</returns>
        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).Count();
        }
        #endregion

        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey)));
            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }
}