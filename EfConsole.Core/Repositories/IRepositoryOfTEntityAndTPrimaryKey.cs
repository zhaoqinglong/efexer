using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EfConsole.Core.Entities;

namespace EfConsole.Core.Repositories
{
   public interface IRepository<TEntity,TPrimaryKey>:IRepository where TEntity:class ,IEntity<TPrimaryKey>
    {
        #region Select/Get/Query

        /// <summary>
        /// 查询所有实体
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// 查询所有实体列表
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetAllList();

        /// <summary>
        /// 查询所有实体列表异步方法
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllListAsync();

        /// <summary>
        /// 根据条件筛选出所有的实体列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据条件查询所有实体列表异步方法
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据条件查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryMethod"></param>
        /// <returns></returns>
        T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);


        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(TPrimaryKey id);

        /// <summary>
        /// 根据主键id查询实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity FirstOrDefault(TPrimaryKey id);

        /// <summary>
        /// 根据表达式查询符合条件的默认第一个实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region Insert

        /// <summary>
        /// 向数据库写入实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// 向数据库写入实体，并返回主键
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TPrimaryKey InsertAndGetId(TEntity entity);

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
        TEntity Update(TEntity entity);

        /// <summary>
        ///根据主键id更新实体
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <param name="updateAction">待更新的部分实体值</param>
        /// <returns>Updated entity</returns>
        TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);
        #endregion


        #region Delete

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        void Delete(TEntity entity);

        /// <summary>
        /// 根据id删除实体
        /// </summary>
        /// <param name="id">Primary key of the entity</param>
        void Delete(TPrimaryKey id);


        /// <summary>
        /// 根据查询条件删除实体
        /// </summary>
        /// <param name="predicate">A condition to filter entities</param>
        void Delete(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region 聚合(aggregate)

        /// <summary>
        /// 统计实体个数
        /// </summary>
        /// <returns>Count of entities</returns>
        int Count();


        /// <summary>
        /// 根据查询条件统计实体个数
        /// </summary>
        /// <param name="predicate">A method to filter count</param>
        /// <returns>Count of entities</returns>
        int Count(Expression<Func<TEntity, bool>> predicate);
        #endregion
    }
}
