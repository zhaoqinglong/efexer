using EfConsole.Core.Entities;

namespace EfConsole.EntityFramework.SimpleRepository
{
    public class MemRepository<T,TKey> : EfRepositoryBase<T,TKey> where T: BaseEntity <TKey>
    {
        public MemRepository()
        {

        }
    }
}
