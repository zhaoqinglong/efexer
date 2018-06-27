using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfConsole.Core.School;
using EfConsole.EntityFramework;
using EfConsole.EntityFramework.Repository;

namespace EfConsoleApplication1.BLL
{
   public class SchoolManager
    {

        private readonly EfConsole.Core.Repositories.IRepository<School,int> _schoolRepository;

        public SchoolManager(EfConsoleContext context)
        {
            var a= new DbContextProvider<EfConsoleContext>(context);
            _schoolRepository = new ZRepositoryBase<School>(a) ;
        }


        public List<School> GetSchoolList()
        {
            return _schoolRepository.GetAllList();
        }
    }
}
