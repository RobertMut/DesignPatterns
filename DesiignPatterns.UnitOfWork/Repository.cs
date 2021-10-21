using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DesignPatterns.UnitOfWork.Entities;
using DesignPatterns.UnitOfWork.Logic;

namespace DesignPatterns.UnitOfWork
{
    public class Repository<T> where T : class
    {
        private EntityContext _context;
        public Repository(EntityContext context)
        {
            _context = context;
        }
        public virtual void Add(T entity)
        {
            var value = (InternalSet<T>)_context.GetOrAddSet(typeof(T).Name, typeof(T));
            value.Add(entity);
            _context.SaveChanges<T>(value);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return (IEnumerable<T>) _context.GetOrAddSet(typeof(T).Name, typeof(T));
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return ((IEnumerable<T>)_context.GetOrAddSet(typeof(T).Name, typeof(T))).AsQueryable().Where(predicate).ToList();
        }

        public virtual ICollection<T> Return()
        {
            return (ICollection<T>)_context.GetOrAddSet(typeof(T).Name, typeof(T));
        }

    }
}
