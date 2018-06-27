using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsole.EntityFramework
{
   public class DbContextProvider<TDbContext>:IDbContextProvider<TDbContext>
        where TDbContext:DbContext
    {
        public TDbContext DbContext { get; }

        public DbContextProvider(TDbContext dbContext)
        {
            DbContext = dbContext;
        }


        public TDbContext GetDbContext()
        {
            return DbContext;
        }
    }
}
