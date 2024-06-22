using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineHub.Repositories.Interfaces;

namespace OnlineHub.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _appDbContext;
        public Repository(DbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Add(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Add(entity);
        }
        public void Delete(object id)
        {
            TEntity entity = _appDbContext.Set<TEntity>().Find(id);
            if (entity != null)
            {
                _appDbContext.Set<TEntity>().Remove(entity);
            }
        }
        public void Update(TEntity entity) 
        {
            _appDbContext.Set<TEntity>().Update(entity);
        }
        public TEntity Find(object id)
        {
            TEntity entity = _appDbContext.Set<TEntity>().Find(id);
            return entity;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _appDbContext.Set<TEntity>().ToList();
        }
        public int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }
    }
}
