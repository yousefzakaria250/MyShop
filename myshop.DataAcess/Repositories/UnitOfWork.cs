using myshop.DataAcess.Data;
using myshop.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myshop.DataAcess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICategoryRepository CategoryRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context=context;
            CategoryRepository = new CategoryRepository(_context);
            ProductRepository = new ProductRepository(_context);    
        }


        public int Complete()
        {
            return _context.SaveChanges();  
        }

        public void Dispose()
        {
             _context.Dispose(); 
        }
    }
}
