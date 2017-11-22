using EfConsole.Core.School;
using EfConsole.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EfConsoleApplication1.BLL
{
    public class StudentBll
    {
        /// <summary>
        /// 学生的仓储
        /// </summary>
        private readonly IRepository<Student,int> _studentRepository = new MemRepository<Student,int>();
        public void Insert(Student stu)
        {
             _studentRepository.Insert(stu);
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            return students;
        }

    }
}
