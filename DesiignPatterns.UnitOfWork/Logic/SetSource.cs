using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace DesignPatterns.UnitOfWork.Logic
{
    public class SetSource : ISetSource
    {
        private static readonly MethodInfo _genericCreateSet =
            typeof(SetSource).GetTypeInfo().GetDeclaredMethod(nameof(CreateSetFactory));
        private static Dictionary<(Context context, string? name), object> _cachedAccessors = new Dictionary<(Context context, string? name), object>();
        private readonly ConcurrentDictionary<(Type type, string? name), Func<Context, string?, object>>? _cache = new();
        private object CreateCore(Context context, Type type, string? name, MethodInfo createMethod)
        {
            return _cache.GetOrAdd(
                (type, name),
                t => (Func<Context, string?, object>)createMethod
                    .MakeGenericMethod(t.type)
                    .Invoke(null, null)!)(context, name);
        }
        private static Func<Context, string?, object> CreateSetFactory<TEntity>() where TEntity : class
            => (c, name) =>
            {
                _cachedAccessors.TryGetValue((c, name), out object value);
                if (value is null)
                {
                    value = new InternalSet<TEntity>();
                    _cachedAccessors.Add((c, name), value);
                }


                return (InternalSet<TEntity>)value;
            };
            

        public virtual object Create(Context context, Type type)
        {
            return CreateCore(context, type, nameof(type), _genericCreateSet);
        }

        public virtual object Create(Context context, string name, Type type)
        {
            return CreateCore(context, type, name, _genericCreateSet);
        }

        public object Add<TEntity>(Context context, string name, Type type, TEntity entity) where TEntity : class
        {
            _cachedAccessors.TryGetValue((context, name), out object value);
            if (value is not null)
            {
                ((InternalSet<TEntity>) value).Add(entity);
                _cachedAccessors[(context, name)] = value;
            }

            return value;
        }
    }
}