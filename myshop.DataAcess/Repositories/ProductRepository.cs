using myshop.DataAcess.Data;
using myshop.Entities.Interfaces;
using myshop.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace myshop.DataAcess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) :base(context) 
        {
            _context=context;
        }
        public void Update(Product product)
        {
            var productInDb = _context.Products.FirstOrDefault(p=> p.Id == product.Id); 
            if (productInDb != null) 
            {
                productInDb.Name = product.Name;
                productInDb.Description = product.Description;
                productInDb.Price = product.Price;
                productInDb.Image = product.Image;
            }
        }
    }
}
