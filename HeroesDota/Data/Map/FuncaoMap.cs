using HeroesDota.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeroesDota.Data.Map
{
    public class FuncaoMap : IEntityTypeConfiguration<FuncaoModel>
    {
        public void Configure(EntityTypeBuilder<FuncaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Funcao).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.HeroId).IsRequired();

            builder.HasOne(x => x.Hero);
        }
    }
}
