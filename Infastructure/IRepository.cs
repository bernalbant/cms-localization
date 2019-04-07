using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CmsLocalization.Infastructure
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        T Get(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        IQueryable<T> GetMany(Expression<Func<T, bool>> expression);
        void Insert(T entity);
        int InsertAndGetId(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Save();
    }
}