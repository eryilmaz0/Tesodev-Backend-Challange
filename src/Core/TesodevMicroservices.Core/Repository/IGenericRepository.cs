using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TesodevMicroservices.Core.Entity.Base;

namespace TesodevMicroservices.Core.Repository
{
    public interface IGenericRepository<TEntity, TPrimaryKey> where TEntity : EntityBase<TPrimaryKey>
    {
        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        TPrimaryKey Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
    }
}