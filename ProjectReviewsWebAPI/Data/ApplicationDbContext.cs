using Microsoft.EntityFrameworkCore;

namespace ProjectReviewsWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
