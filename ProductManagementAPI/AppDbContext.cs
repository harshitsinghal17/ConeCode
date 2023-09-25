using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Product;

namespace ProductManagementAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<ProductEntity> Products { get; set; }
    }
}
