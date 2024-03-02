using HeroesDota.Models;

namespace HeroesDota.Repositorio.Interfaces
{
    public interface IHeroRepository
    {
        Task <List<HeroModel>> BuscarTodosHerois();
        Task <HeroModel> BuscarPorId(int id);
        Task <HeroModel> Adicionar(HeroModel hero);
        Task <HeroModel> Atualizar(HeroModel hero, int id);
        Task <bool> Deletar(int id);
    }
}
