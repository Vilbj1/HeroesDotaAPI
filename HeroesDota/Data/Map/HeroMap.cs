using HeroesDota.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeroesDota.Data.Map
{
    public class HeroMap : IEntityTypeConfiguration<HeroModel>
    {
        public void Configure(EntityTypeBuilder<HeroModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Atributo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Ataque).IsRequired();
            builder.Property(x => x.Armor).IsRequired();
            builder.Property(x => x.Hp).IsRequired();
        }
    }
}
