using Microsoft.EntityFrameworkCore;
using TASK2.Models;

namespace TASK2.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
