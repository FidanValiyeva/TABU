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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(b=>
            {
                
                b.HasKey(x=>x.Code);
                b.HasIndex(x=>x.Name)
                .IsUnique();
                b.Property(x => x.Code)
                .IsFixedLength(true)
                .HasMaxLength(2);
                b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
                b.Property(x=>x.Icon)
                .HasMaxLength(128);
                b.HasData(new Language
                {
                 Code="az",
                 Name="Azerbaycan",
                 Icon= "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Flag_of_Azerbaijan.svg/1200px-Flag_of_Azerbaijan.svg.png"


                });
                


            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
