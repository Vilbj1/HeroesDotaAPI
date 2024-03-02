using HeroesDota.Data;
using HeroesDota.Models;
using HeroesDota.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HeroesDota.Repositorio
{
    public class HeroRepository : IHeroRepository
    {
        private readonly HeroDBContext _dbContext;
        public HeroRepository (HeroDBContext heroDBContext)
        {
            _dbContext = heroDBContext;
        }
        public async Task<HeroModel> BuscarPorId(int id)
        {
            return await _dbContext.Herois.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<HeroModel>> BuscarTodosHerois()
        {
            return await _dbContext.Herois.ToListAsync();
        }

        public async Task<HeroModel> Adicionar(HeroModel hero)
        {
            await _dbContext.Herois.AddAsync(hero);
            await _dbContext.SaveChangesAsync();
            return hero;
        }

        public async Task<HeroModel> Atualizar(HeroModel hero, int id)
        {
            HeroModel heroPorId = await BuscarPorId(id);
            
            if (heroPorId == null)
            {
                throw new Exception($"Herói com Id {id} não foi encontrado");
            }  
            heroPorId.Nome = hero.Nome;
            heroPorId.Atributo = hero.Atributo;
            heroPorId.Ataque = hero.Ataque;
            heroPorId.Armor = hero.Armor;
            heroPorId.Hp = hero.Hp;

            _dbContext.Herois.Update(heroPorId);
            await _dbContext.SaveChangesAsync();
            
            return heroPorId;
        }

        public async Task<bool> Deletar(int id)
        {
            HeroModel heroPorId = await BuscarPorId(id);

            if (heroPorId == null)
            {
                throw new Exception($"Herói com Id {id} não foi encontrado");
            }

            _dbContext.Herois.Remove(heroPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
