using Microsoft.EntityFrameworkCore;
using ecommapp.Models;

namespace ecommapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }


        public DbSet<products> products { get; set; }

        public DbSet<Category> categories { get; set; }

    }
}
