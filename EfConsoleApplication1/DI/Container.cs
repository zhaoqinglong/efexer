using System;
using System.Collections.Generic;

namespace EfConsoleApplication1.DI
{
    public class Container
    {
        private IDictionary<Type, Type> TypeMapping { set; get; }

        public Container()
        {
            TypeMapping = new Dictionary<Type, Type>();
        }

        /// <summary>
        /// 关联接口和实现
        /// </summary>
        /// <typeparam name="TImplementation">接口的实现</typeparam>
        /// <typeparam name="TService">接口的定义</typeparam>
        public void Register<TImplementation, TService>()
            where TImplementation : TService
        {
            TypeMapping[(typeof (TService))] = typeof (TImplementation);
        }

        /// <summary>
        /// 创建类
        /// </summary>
        /// <typeparam name="TService">接口</typeparam>
        /// <returns></returns>
        public TService Resolve<TService>()
        {
            var implementation = TypeMapping[(typeof (TService))];
            return (TService) Activator.CreateInstance(implementation);
        }
    }
}