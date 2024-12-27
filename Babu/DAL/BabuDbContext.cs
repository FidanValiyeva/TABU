using Babu.Entities;
using Microsoft.EntityFrameworkCore;

namespace Babu.DAL
{
    public class BabuDbContext : DbContext
    {      
        public BabuDbContext(DbContextOptions options) : base(options) 
        {
        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<BannedWord> BannedWords { get; set; }
        public DbSet<Game> Games { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(
                BabuDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
