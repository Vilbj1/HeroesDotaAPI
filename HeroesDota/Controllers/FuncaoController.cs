using HeroesDota.Models;
using HeroesDota.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Runtime.CompilerServices;

namespace HeroesDota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncaoController : ControllerBase
    {
        private readonly IFuncaoRepository _funcaoRepository;
        public FuncaoController(IFuncaoRepository funcaoRepository)
        {
            _funcaoRepository = funcaoRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<FuncaoModel>>> BuscarTodasFuncoes()
        {
            List<FuncaoModel> funcoes = await _funcaoRepository.BuscarTodasFuncoes();
            return Ok(funcoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuncaoModel>> BuscarPorId(int id)
        {
            FuncaoModel funcao = await _funcaoRepository.BuscarPorId(id);
            return Ok(funcao);
        }

        [HttpPost]
        public async Task<ActionResult<FuncaoModel>> Cadastrar([FromBody] FuncaoModel funcaoModel)
        {
            FuncaoModel funcao = await _funcaoRepository.Adicionar(funcaoModel);
            return Ok(funcao);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<FuncaoModel>> Atualizar([FromBody] FuncaoModel funcaoModel, int id)
        {
            funcaoModel.Id = id;
            FuncaoModel funcao = await _funcaoRepository.Atualizar(funcaoModel, id);
            return Ok(funcao);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FuncaoModel>> Deletar(int id)
        {
            bool apagado = await _funcaoRepository.Deletar(id);
            return Ok(apagado);
        }
    }
}
