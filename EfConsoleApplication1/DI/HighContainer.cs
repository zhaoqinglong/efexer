using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApplication1.DI
{
    /// <summary>
    /// 依赖注入的容器
    /// </summary>
    public class HighContainer
    {
        private IDictionary<Tuple<Type, string>, IList<Func<object>>> Factories { get; set; }

        public HighContainer()
        {
            Factories = new Dictionary<Tuple<Type, string>, IList<Func<object>>>();
        }

        private Func<object> WrapFactory(Func<object> originalFactory, bool singleton)
        {
            if (!singleton)
                return originalFactory;
            object value = null;
            return () =>
            {
                if (value == null)
                    value = originalFactory();
                return value;
            };
        }

        private Func<object> BuildFactory(Type type)
        {
            var constructor = type.GetConstructors().FirstOrDefault();

            // 生成构造函数中的每个参数的表达式
            var argumentExpressions = new List<Expression>();
            foreach (var parameter in constructor.GetParameters())
            {
                var parameterType = parameter.ParameterType;
                if (parameterType.IsGenericType &&
                    parameterType.GetGenericTypeDefinition() == typeof (IEnumerable<>))
                {
                    // 等于调用this.ResolveMany<TParameter>();
                    argumentExpressions.Add(Expression.Call(
                        Expression.Constant(this), "ResolveMany",
                        parameterType.GetGenericArguments(),
                        Expression.Constant(null, typeof (string))));
                }
                else
                {
                    // 等于调用this.Resolve<TParameter>();
                    argumentExpressions.Add(Expression.Call(
                        Expression.Constant(this), "Resolve",
                        new[] {parameterType},
                        Expression.Constant(null, typeof (string))));
                }
            }
            // 构建new表达式并编译到委托
            var newExpression = Expression.New(constructor, argumentExpressions);
            return Expression.Lambda<Func<object>>(newExpression).Compile();
        }


        public void Register<TImplementation, TService>(string serviceKey = null, bool singleton = false)
            where TImplementation : TService
        {
            var key = Tuple.Create(typeof (TService), serviceKey);
            IList<Func<object>> factories;
            if (!Factories.TryGetValue(key, out factories))
            {
                factories = new List<Func<object>>();
                Factories[key] = factories;
            }
            var factory = BuildFactory(typeof (TImplementation));
            WrapFactory(factory, singleton);
            factories.Add(factory);
        }

        public TService Resolve<TService>(string serviceKey = null)
        {
            var key = Tuple.Create(typeof (TService), serviceKey);
            var factory = Factories[key].Single();
            return (TService) factory();
        }

        public IEnumerable<TService> ResolveMany<TService>(string serviceKey = null)
        {
            var key = Tuple.Create(typeof (TService), serviceKey);
            IList<Func<object>> factories;
            if (!Factories.TryGetValue(key, out factories))
            {
                yield break;
            }
            foreach (var factory in factories)
            {
                yield return (TService) factory();
            }
        }
    }
}
