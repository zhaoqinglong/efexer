using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApplication1.Test
{
    /// <summary>
    /// 异步方法的学习
    /// </summary>
    public class AsyncTest
    {

        /// <summary>
        /// 下载网址的字符串
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static int CountCharacters(int id, string address)
        {
            var wc = new WebClient();
            Console.WriteLine($"开始调用 id = {id},当前时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");

            var result = wc.DownloadString(address);
            Console.WriteLine($"调用完成 id = {id},当前时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");

            return result.Length;
        }

        /// <summary>
        /// 异步下载网址的字符串
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static async Task<int> CountCharactersAsync(int id, string address)
        {
            var wc = new WebClient();
            Console.WriteLine($"开始调用 id = {id},当前时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");

            //await关键字表明需要异步执行的任务
            var result = await wc.DownloadStringTaskAsync(address);
            Console.WriteLine($"调用完成 id = {id},当前时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");

            return result.Length;
        }

#region add test

        public static int Add(int m, int n)
        {
            return m + n;
        }

        /// <summary>
        /// Task任务，希望有返回值
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static async Task<int> AddAsync(int m, int n)
        {
            int val = await Task.Run(() => Add(m, n));
            return val;
        }

        /// <summary>
        ///  Task任务，不需要从异步方法中取得返回值，但希望检查异步方法的状态
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static async Task AddAsyncTask(int m, int n)
        {
            int val = await Task.Run(() => Add(m, n));
            Console.WriteLine($"AddAsyncTask Result：{val}");
        }

        public static async void AddAsyncVoidTask(int m, int n)
        {
            await  Task.Delay(5000);
            int val = await Task.Run(() => Add(m, n));
            Console.WriteLine($"void task result:{val}");
        }


        #endregion

        #region GUID

        /// <summary>
        /// 创建新giud
        /// </summary>
        /// <returns></returns>
        public static Guid GetGuid()
        {
            return Guid.NewGuid();
        }


        public static async Task GetGuidAsync()
        {
            var myFunc = new Func<Guid>(GetGuid);

            //Action、Func<TResult>、Func<Task> 和 Func<Task<TResult>>
            var t1 = await Task.Run(myFunc);
            var t2 = await Task.Run(new Func<Guid>(GetGuid));
            var t3 = await Task.Run(() => GetGuid());
            var t4 = await Task.Run(() => Guid.NewGuid());

            Console.WriteLine($"t1: {t1}");
            Console.WriteLine($"t2: {t2}");
            Console.WriteLine($"t3: {t3}");
            Console.WriteLine($"t4: {t4}");
        }

        #endregion
    }

   
}
