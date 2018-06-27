using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfConsoleApplication1.DI;
using EfConsole.EntityFramework.Repository;
using EfConsole.Core.School;
using EfConsole.EntityFramework.SimpleRepository;

namespace EfConsoleApplication1.BLL
{
    public class GrandeBll
    {
        /// <summary>
        /// 班级仓储
        /// </summary>
        private readonly IRepository<Grade, Guid> _gradeRepository;
      

        public GrandeBll()
        {
            var container = new Container();
            container.Register<MemRepository<Grade, Guid>, IRepository<Grade, Guid>>();
            _gradeRepository = container.Resolve<IRepository<Grade, Guid>>();
        }

        public void Add(Grade grade)
        {
            _gradeRepository.Add(grade);
        }


    }
}
