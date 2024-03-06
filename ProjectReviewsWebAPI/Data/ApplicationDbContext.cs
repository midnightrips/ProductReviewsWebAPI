using Microsoft.EntityFrameworkCore;
using ProjectReviewsWebAPI.Models;

namespace ProjectReviewsWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
