using myshop.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myshop.Entities.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
       void Update(Product product);
    }
}
