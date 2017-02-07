using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfConsoleApplication1.Core;

namespace EfConsoleApplication1.DataStore
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public  class EfUnitOfWork : Context, IUnitOfWork
    {
        /// <summary>
        /// 初始化Entity Framework工作单元
        /// </summary>
        /// <param name="connectionName">连接字符串的名称</param>
        public EfUnitOfWork(string connectionName)
            : base(connectionName)
        {
            TraceId = Guid.NewGuid().ToString();
        }

        public EfUnitOfWork()
        {
            TraceId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 启动标识
        /// </summary>
        private bool IsStart { get; set; }

        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId { get; private set; }


        public void Commit()
        {
            try
            {
                SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                IsStart = false;
            }
        }   

        public void Start()
        {
            IsStart = true;
        }

        internal void CommitByStart()
        {
            if(IsStart)
                return;
            Commit();
        }
    }
}
