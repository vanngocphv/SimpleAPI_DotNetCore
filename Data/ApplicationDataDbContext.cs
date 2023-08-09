using Microsoft.EntityFrameworkCore;

namespace SimpleApi_DotNetCoreWebApi.Data
{
    public class ApplicationDataDbContext: DbContext
    {
        public ApplicationDataDbContext(DbContextOptions<ApplicationDataDbContext> options) : base(options)
        {
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
