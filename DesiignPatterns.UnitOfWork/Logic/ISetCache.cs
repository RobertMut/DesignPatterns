using System;

namespace DesignPatterns.UnitOfWork.Logic
{
    public interface ISetCache
    {
        object GetOrAddSet(Type type);
        object GetOrAddSet(string entityTypeName, Type type);
    }
}
