using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApplication1.Test
{
    public class TestEntrance
    {
        private readonly IGetTest _diTest;

        public TestEntrance(CastleDiTest diTest)
        {
            _diTest = diTest;
        }

        public void DotheTest()
        {
            var ab = new AbstractDo();
            ab.GetTheName();

            var vir = new VirtualTest();
            vir.GetName();
        }

        public void CastleDiTest()
        {
            _diTest.GetNothing();
        }
    }
}
