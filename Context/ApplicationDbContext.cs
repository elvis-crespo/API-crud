using ApiSuperHero_DotNet8.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiSuperHero_DotNet8.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
