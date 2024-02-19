using Microsoft.EntityFrameworkCore;

namespace LoginForm.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<User_tbl> Users { get; set; }
    }
}
