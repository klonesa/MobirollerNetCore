using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Mobiroller.Core.Entities;

namespace Mobiroller.Core.Data
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
