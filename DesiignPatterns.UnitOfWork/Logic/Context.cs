using System;
using System.Collections.Generic;

namespace DesignPatterns.UnitOfWork.Logic
{
    public class Context : ISetCache
    {
        private IDictionary<(Type type, string? name), object>? _sets;
        private readonly ISetSource source;
        public Context()
        {
            source = new SetSource();


        }


        public object GetOrAddSet(Type type)
        {

            _sets ??= new Dictionary<(Type type, string? name), object>();

            if (!_sets.TryGetValue((type, null), out var set))
            {
                set = source.Create(this, type);
                _sets[(type, null)] = set;
            }
            return set;
        }

        public object GetOrAddSet(string entityTypeName, Type type)
        {
            _sets ??= new Dictionary<(Type type, string? name), object>();

            if (!_sets.TryGetValue((type, entityTypeName), out var set))
            {
                set = source.Create(this, entityTypeName, type);
                _sets[(type, entityTypeName)] = set;
            }

            return set;
        }


        public bool SaveChanges<T>(object set)
        {
            try
            {
                _sets[(typeof(T), typeof(T).Name)] = set;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
            
        }
    }
}
