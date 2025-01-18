using Microsoft.EntityFrameworkCore;
using myshop.DataAcess.Data;
using myshop.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace myshop.DataAcess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context=context;
            _dbSet=_context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity); 
        }

        //public T Get(int? id)
        //{
        //    return
        //        _dbSet.Find(id);
        //}

        public T Get(Expression<Func<T, bool>> ?criteria, string? include)
        {
            IQueryable<T> query = _dbSet;
            if (criteria != null)
            {
                query = query.Where(criteria);
            }
            if (include!=null)
            {
                foreach (var item in include.Split(new char[] { ',' }))
                {
                    query = query.Include(item);

                }
            }
            return query.SingleOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return
            _dbSet.ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> criteria, string? include)
        {
            IQueryable<T> query = _dbSet;
            if(criteria != null)
            {
                query = query.Where(criteria);
            }
            if(include!=null)
            {
                foreach (var item in include.Split(new char[] {','}))
                {
                    query = query.Include(item);

                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);  
        }

        public void RemoveAll(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);   
        }
    }

}
