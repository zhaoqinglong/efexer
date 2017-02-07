using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApplication1.Test
{
    public interface ILogWriter
    {
        void Write(string text);
    }

    public class MyLogWriter : ILogWriter
    {
        public void Write(string str)
        {
            Console.WriteLine(str);
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class MyLogger : ILogger
    {
        ILogWriter _writer;

        public MyLogger(ILogWriter writer)
        {
            _writer = writer;
        }

        public void Log(string message)
        {
            _writer.Write("[ Log ] " + message);
        }
    }
}
