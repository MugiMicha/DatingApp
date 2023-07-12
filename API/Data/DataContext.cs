using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        // Table: Users; Columns are properties from AppUser
        public DbSet<AppUser> Users { get; set; }
    }
}