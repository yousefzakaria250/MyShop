using myshop.DataAcess.Data;
using myshop.Entities.Interfaces;
using myshop.Entities.Models;

namespace myshop.DataAcess.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) :base(context) 
        {
            _context=context;
        }

        public void Update(Category category)
        {
            var CategoryInDb = _context.Categories.FirstOrDefault(C=>C.Id ==category.Id);   
            if (CategoryInDb != null) { 
                CategoryInDb.Name = category.Name; 
                CategoryInDb.Description = category.Description;
                CategoryInDb.CreatedDate = DateTime.Now;   
            }
        }
    }
}
