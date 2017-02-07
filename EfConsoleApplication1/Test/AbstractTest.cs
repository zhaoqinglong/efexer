using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApplication1.Test
{
    public abstract class AbstractTest
    {
        /// <summary>
        /// 抽象方法，不能有实现；子类必须实现
        /// </summary>
        public abstract void GetTheName();

        /// <summary>
        /// 普通方法
        /// </summary>
        public void GetAll()
        {

        }

        /// <summary>
        /// 虚方法，必须实现；子类可重写，可不重写
        /// </summary>
        public virtual void Getnothing()
        {
            Console.WriteLine("this is  a virtual method in Abstract base class");
        }
    }
}
