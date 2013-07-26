using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Linq.Expressions;
using DucksOnThePond.Dal.Infrastructure;
using DucksOnThePond.Dal.Interfaces;

namespace DucksOnThePond.Dal
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T: class
    {
        private IObjectSet<T> _objectSet;

        public RepositoryBase() : this(new DmsRepositoryContext())
        { }

        public RepositoryBase(IRepositoryContext repositoryContext)
        {
            repositoryContext = repositoryContext ?? new DmsRepositoryContext();
            _objectSet = repositoryContext.GetObjectSet<T>();
        }

        public void Add(T entity)
        {
            _objectSet.AddObject(entity);
        }

        public void Delete(T entity)
        {
            _objectSet.DeleteObject(entity);
        }

        public IList<T> GetAll()
        {
            return _objectSet.ToList<T>();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            return _objectSet.Where(whereCondition).ToList<T>();
        }

        public T GetSingle(Expression<Func<T, bool>> whereCondition)
        {
            return _objectSet.Where(whereCondition).FirstOrDefault<T>();
        }

        public IQueryable<T> GetQueryable()
        {
            return _objectSet.AsQueryable<T>();
        }

        public long Count()
        {
            return _objectSet.LongCount<T>();
        }

        public long Count(Expression<Func<T, bool>> whereCondition)
        {
            return _objectSet.Where(whereCondition).LongCount<T>();
        }
    }
}