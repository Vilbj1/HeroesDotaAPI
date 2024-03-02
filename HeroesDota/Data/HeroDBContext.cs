using HeroesDota.Data.Map;
using HeroesDota.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroesDota.Data
{
    public class HeroDBContext : DbContext
    {
        public HeroDBContext (DbContextOptions<HeroDBContext> options) : base(options)
        {

        }

        // Representação de tabelas que serão criadas após o migration (Tabela Herois e tabela Funcao serão criadas)
        public DbSet<HeroModel> Herois { get; set; }
        public DbSet<FuncaoModel> Funcao { get; set; }

        // Método utilizado para utilizar como cache os DbSets criados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HeroMap());
            modelBuilder.ApplyConfiguration(new FuncaoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
