using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        //This repository interface contains generic signatures for fundamental CRUD operations, which must be implemented by ORM repository bases
        //Entity specific methods must be implemented in their own Data Access Layer interfaces
        void Add(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        void Update(TEntity entity);
    }
}
