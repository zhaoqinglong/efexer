using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EfConsole.Core.School;
using EfConsole.EntityFramework;
using EfConsoleApplication1.BLL;
using EfConsoleApplication1.DI;
using EfConsoleApplication1.Test;

namespace EfConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var context=new EfConsoleContext("conn");
            bool flag1 = context.Database.CreateIfNotExists();
            Console.WriteLine("数据库被创建:{0}", flag1);

          

            context.Schools.Add(new School() {Name = "nschool", Address = "北京海淀"});
            context.SaveChanges();

            var man= new SchoolManager(context);
            var li= man.GetSchoolList();
            foreach (var item in li)
            {
                Console.WriteLine("Name is {0},Address is {1}" ,item.Name,item.Address);
            }
            //添加数据
            //List<Student> stulist = new List<Student>();
            //stulist.Add(new Student() { date = DateTime.Now, des = "", id = 1, name = "jimmy" });
            //context.Stus.AddRange(stulist);


            //context.Teachers.Add(new Teacher() {Name = "张三",Id = 2});



            //var tea = new Teacher() {Name = "tom", Age = 23, TeachClass = "三年二班"};

            //var tea1 = context.Teachers.ToList();

            //var otea = new Teacher() { Name = "张三1", Id = 1 };
            //var tea2 = new Teacher() { Name = "张三2", Id = 2 };
            ////先detach
            //context.DetachOther(otea);

            ////加载实体
            //var teaAttach = context.Teachers.Attach(otea);
            //context.Entry(otea).State = EntityState.Modified;


            //context.DetachOther(tea2);
            //var teaAttach2 = context.Teachers.Attach(tea2);


            ////context.Teachers.Attach(tea);
            //int res = context.SaveChanges();
            //var t = context.Teachers.Where(x => x.Id == 1).ToList();

            //new TeaBll().Add(tea);

            //new GrandeBll().Add(new Grade()
            //{
            //    Id = Guid.NewGuid(),
            //    GradeName = "一年级二班",
            //    StuClass = 1,
            //    StuGrade = 2,
            //    StuNum = "32"
            //});

            //using (var context = new Context())
            //{
            //    foreach (var item in context.Stus)
            //    {
            //        Console.WriteLine("Id：" + item.Id + ",Name：" + item.Name + ",时间：" + item.CreateDateTime);
            //    }
            //    foreach (var item in context.Teachers)
            //    {
            //        Console.WriteLine("Id：" + item.Id + ",Name：" + item.Name + ",时间：" + item.CreateDateTime + ",教授班级：" +
            //                          item.TeachClass);
            //    }

            //    foreach (var item in context.Grades)
            //    {
            //        Console.WriteLine("Id：" + item.Id + ",班级：" + item.GradeName + "，班级人数：" + item.StuNum + "，创建时间：" +
            //                          item.CreateDateTime);
            //    }
            //}


            #region DI 

            //Console.WriteLine("DI:");

            //var container = new Container();
            //container.Register<DiTest, IGetTest>();
            //var diTestService = container.Resolve<IGetTest>();
            //diTestService.GetNothing();

            //var highContainer = new HighContainer();
            //highContainer.Register<MyLogger, ILogger>();
            //highContainer.Register<MyLogWriter, ILogWriter>();

            //var logger = highContainer.Resolve<ILogger>();
            //logger.Log("asdasdas");

            #endregion

            #region Castle Windsor DI

            //Console.WriteLine("Castle Windsor DI:");
            //var castleContainer = new WindsorContainer();
            ////castleContainer.Installer();
            //castleContainer.Register(
            //    Castle.MicroKernel.Registration.Component.For<IGetTest>()
            //        .ImplementedBy<OtherDiTest>()
            //        .LifestyleTransient());
            //var cas = castleContainer.Resolve<IGetTest>();
            //cas.GetNothing();

            ////TestEntrance在构造函数中，初始化了CastleDiTest类，此处CastleDiTest被自动注入
            //castleContainer.Register(Castle.MicroKernel.Registration.Component.For<TestEntrance>(),
            //    Component.For<CastleDiTest>());

            //var castleEntrance = castleContainer.Resolve<TestEntrance>();
            //castleEntrance.CastleDiTest();



            #endregion

            #region Async测试


            //var id1 = AsyncTest.CountCharacters(1, "http://www.cnblogs.com/");
            //var id2 = AsyncTest.CountCharactersAsync(2, "http://www.cnblogs.com/").Result;

            //var addRes1 = AsyncTest.AddAsync(2, 3);

            //Task addRes2 = AsyncTest.AddAsyncTask(1, 2);
            //addRes2.Wait();
            //var status = addRes2.Status;

            //AsyncTest.AddAsyncVoidTask(3, 3);
            //var guidTask = AsyncTest.GetGuidAsync();

            #endregion

            Console.WriteLine("this is end!");

            Console.ReadLine();


        }

    }
}
