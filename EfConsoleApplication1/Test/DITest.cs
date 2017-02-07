using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApplication1.Test
{
    public class DiTest : IGetTest
    {
        public void GetNothing()
        {
            Console.WriteLine("this is DI test");
        }
    }

    public class CastleDiTest : IGetTest
    {
        public void GetNothing()
        {
            Console.WriteLine("this is Castle  DI test");
        }
    }

    public class OtherDiTest : IGetTest
    {
        public void GetNothing()
        {
           Console.WriteLine("this is other Castle DI Test!");
        }
    }
}
