using Babu.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Babu.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Code);
            builder.HasIndex(x => x.Name)
            .IsUnique();
            builder.Property(x => x.Code)
            .IsFixedLength(true)
            .HasMaxLength(2);
            builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(32);
            builder.Property(x => x.Icon)
            .HasMaxLength(128);
            builder.HasData(new Language
            {
                Code = "az",
                Name = "Azerbaycan",
                Icon = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Flag_of_Azerbaijan.svg/1200px-Flag_of_Azerbaijan.svg.png"


            });
        }
    }
}
