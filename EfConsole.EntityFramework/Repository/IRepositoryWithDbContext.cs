using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsole.EntityFramework.Repository
{
  public  interface IRepositoryWithDbContext
  {
      DbContext GetDbContext();
  }
}
