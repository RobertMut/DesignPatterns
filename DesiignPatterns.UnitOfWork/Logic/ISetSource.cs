using System;

namespace DesignPatterns.UnitOfWork.Logic
{
    public interface ISetSource
    {
        object Create(Context context, Type type);
        object Create(Context context, string name, Type type);
        object Add<TEntity>(Context context, string name, Type type, TEntity entity) where TEntity : class;
    }
}
