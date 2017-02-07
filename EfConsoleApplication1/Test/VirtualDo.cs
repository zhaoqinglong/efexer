using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApplication1.Test
{
    class VirtualDo : VirtualTest
    {
        public override void GetName()
        {
            Console.WriteLine("this is override virtual method");
        }
    }
}
