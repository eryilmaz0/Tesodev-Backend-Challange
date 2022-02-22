using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TesodevMicroservices.Core.Entity.Base;
using TesodevMicroservices.Core.Repository;
using TesodevMicroservices.CustomerService.Entities.Context;

namespace TesodevMicroservices.CustomerService.DataAccess.Implementation
{
    public class GenericRepository<TEntity, TPrimaryKey> : IGenericRepository<TEntity, TPrimaryKey> where TEntity : EntityBase<TPrimaryKey>
    {
        private readonly ApplicationDbContext _context;
        private IQueryable<TEntity> _entities;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }


        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _entities;

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }


        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = _entities;
            return query.FirstOrDefault(filter);
        }


        public TPrimaryKey Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }



        public bool Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
            return true;
        }



        public bool Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            return true;
        }
    }
}