using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
     
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
    }
}
