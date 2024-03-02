using HeroesDota.Models;

namespace HeroesDota.Repositorio.Interfaces
{
    public interface IFuncaoRepository
    {
        Task <List<FuncaoModel>> BuscarTodasFuncoes();
        Task <FuncaoModel> BuscarPorId(int id);
        Task <FuncaoModel> Adicionar(FuncaoModel funcao);
        Task <FuncaoModel> Atualizar(FuncaoModel funcao, int id);
        Task <bool> Deletar(int id);
    }
}
