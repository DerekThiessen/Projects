using System;

namespace DucksOnThePond.Dal.Interfaces
{
    interface IRepository<T>
     where T : class
    {
        void Add(T entity);
        long Count();
        long Count(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition);
        void Delete(T entity);
        System.Collections.Generic.IList<T> GetAll();
        System.Collections.Generic.IList<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition);
        System.Linq.IQueryable<T> GetQueryable();
        T GetSingle(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition);
    }
}
