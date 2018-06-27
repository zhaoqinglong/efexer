using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfConsole.Core.Entities;
using EfConsole.Core.Repositories;

namespace EfConsole.EntityFramework.Repository
{
    public class EfRepositoryBase<TDbContext, TEntity, TPrimaryKey>:RepositoryBase<TEntity,TPrimaryKey>,IRepositoryWithDbContext
        where TEntity:class ,IEntity<TPrimaryKey>
        where TDbContext:DbContext
    {
        public virtual TDbContext Context => _dbContextProvider.GetDbContext();

        private readonly IDbContextProvider<TDbContext> _dbContextProvider;

        public virtual DbSet<TEntity> Table => Context.Set<TEntity>();

        public EfRepositoryBase(IDbContextProvider<TDbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        


        public override IQueryable<TEntity> GetAll()
        {
            return Table;
        }

        public override TEntity Insert(TEntity entity)
        {
            return Table.Add(entity);
        }

        public override TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public override void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            Table.Remove(entity);
        }

        public override void Delete(TPrimaryKey id)
        {
            var entity = Table.Local.FirstOrDefault(x => EqualityComparer<TPrimaryKey>.Default.Equals(x.Id, id));
            if (entity == null)
            {
                entity = FirstOrDefault(id);
                if (entity == null)
                {
                    return;
                }
            }

            Delete(entity);
        }

        public DbContext GetDbContext()
        {
            return Context;
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            if (!Table.Local.Contains(entity))
            {
                Table.Attach(entity);
            }
        }
    }
}
