using EfConsole.Core;

namespace EfConsole.EntityFramework.Repository
{
    public class MemRepository<T,TKey> : EfRepositoryBase<T,TKey> where T: BaseEntity <TKey>
    {
        public MemRepository()
        {

        }
    }
}
