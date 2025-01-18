using Microsoft.EntityFrameworkCore;
using myshop.Entities.Models;


namespace myshop.DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {   }
        public DbSet<Category> Categories { get; set; }
    }
}
