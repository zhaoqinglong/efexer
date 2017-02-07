using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApplication1.DataStore
{
    public class MemRepository<T,TKey> : EfRepositoryBase<T,TKey> where T: BaseEntity <TKey>
    {
        public MemRepository()
        {

        }
    }
}
