using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace myshop.Entities.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //T Get(int? id);  
        T Get(Expression<Func<T, bool>> criteria = null, string? include =null);  
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T , bool>> criteria , string? include);
        void Add(T entity); 
        void Remove(T entity);    
        void RemoveAll(IEnumerable<T> entities);    
    }
}
