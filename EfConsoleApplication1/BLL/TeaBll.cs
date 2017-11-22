using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfConsole.EntityFramework.Repository;
using EfConsole.Core.School;

namespace EfConsoleApplication1.BLL
{
    public class TeaBll
    {
        //获取仓储
      private  readonly IRepository<Teacher,int> _teacherRepository = new MemRepository<Teacher,int>();


        public void Insert(Teacher teacher)
        {
             _teacherRepository.Insert(teacher);
        }

        public void Add(Teacher teacher)
        {
            _teacherRepository.Add(teacher);
        }
    }
}
