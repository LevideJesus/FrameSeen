using Microsoft.EntityFrameworkCore;
using FrameSeen.Models;

namespace FrameSeen.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Series> Series => Set<Series>();

        public DbSet<Users> Users => Set<Users>();
    }

    
}