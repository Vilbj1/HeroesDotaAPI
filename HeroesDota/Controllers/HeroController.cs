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
    public class HeroController : ControllerBase
    {
        private readonly IHeroRepository _heroRepository;
        public HeroController(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<HeroModel>>> BuscarTodosHerois()
        {
            List<HeroModel> heroes = await _heroRepository.BuscarTodosHerois();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HeroModel>> BuscarPorId(int id)
        {
            HeroModel heroi = await _heroRepository.BuscarPorId(id);
            return Ok(heroi);
        }

        [HttpPost]
        public async Task<ActionResult<HeroModel>> Cadastrar([FromBody] HeroModel heroModel)
        {
            HeroModel hero = await _heroRepository.Adicionar(heroModel);
            return Ok(hero);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<HeroModel>> Atualizar([FromBody] HeroModel heroModel, int id)
        {
            heroModel.Id = id;
            HeroModel hero = await _heroRepository.Atualizar(heroModel, id);
            return Ok(hero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<HeroModel>> Deletar(int id)
        {
            bool apagado = await _heroRepository.Deletar(id);
            return Ok(apagado);
        }
    }
}
