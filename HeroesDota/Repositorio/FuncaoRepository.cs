using HeroesDota.Data;
using HeroesDota.Models;
using HeroesDota.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HeroesDota.Repositorio
{
    public class FuncaoRepository : IFuncaoRepository
    {
        private readonly HeroDBContext _dbContext;
        public FuncaoRepository (HeroDBContext FuncaoDBContext)
        {
            _dbContext = FuncaoDBContext;
        }
        public async Task<FuncaoModel> BuscarPorId(int id)
        {
            return await _dbContext.Funcao
                .Include(x => x.Hero)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<FuncaoModel>> BuscarTodasFuncoes()
        {
            return await _dbContext.Funcao
                .Include(x => x.Hero)
                .ToListAsync();
        }

        public async Task<FuncaoModel> Adicionar(FuncaoModel funcao)
        {
            await _dbContext.Funcao.AddAsync(funcao);
            await _dbContext.SaveChangesAsync();
            return funcao;
        }

        public async Task<FuncaoModel> Atualizar(FuncaoModel funcao, int id)
        {
            FuncaoModel funcaoPorId = await BuscarPorId(id);
            
            if (funcaoPorId == null)
            {
                throw new Exception($"Herói com Id {id} não foi encontrado");
            }  
            funcaoPorId.Funcao = funcao.Funcao;
            funcaoPorId.Descricao = funcao.Descricao;
            funcaoPorId.HeroId = funcaoPorId.HeroId;

            _dbContext.Funcao.Update(funcaoPorId);
            await _dbContext.SaveChangesAsync();
            
            return funcaoPorId;
        }

        public async Task<bool> Deletar(int id)
        {
            FuncaoModel funcaoPorId = await BuscarPorId(id);

            if (funcaoPorId == null)
            {
                throw new Exception($"Funcao com Id {id} não foi encontrado");
            }

            _dbContext.Funcao.Remove(funcaoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
