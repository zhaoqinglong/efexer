using System;

namespace EfConsole.EntityFramework.SimpleRepository
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 启动
        /// </summary>
        void Start();

        /// <summary>
        /// 提交更新
        /// </summary>
        void Commit();
    }
}
