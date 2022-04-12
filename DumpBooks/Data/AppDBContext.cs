using DumpBooks.Models;
using Microsoft.EntityFrameworkCore;

namespace DumpBooks.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        // for each table need to create DB set 
        public DbSet<Category> Categories { get; set; }


    }
}
