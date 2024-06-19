using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gerenciador_De_Projetos.MODEL.Models;
using Gerenciador_De_Projetos.MODEL.DTO;
using Gerenciador_De_Projetos.MODEL.Services;

namespace Gerenciador_De_Projetos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private Gerenciador_De_ProjetosContext _context;
        private ServiceProjeto _Service;

        public ProjetoController(Gerenciador_De_ProjetosContext context)
        {
            _context = context;
            _Service = new ServiceProjeto(_context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _Service.oRepositoryProjeto.SelecionarTodosAsync());
        }

        [HttpGet("GetProjetoById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _Service.oRepositoryProjeto.SelecionarChaveAsync(id));
        }

        [HttpPost("PostProjeto")]
        public async Task<IActionResult> Post(ProjetoDTO projetoDTO)
        {
            await _Service.IncluirProjetoDTO(projetoDTO);
            return Ok("Membro Cadastrado com sucesso");
        }

        [HttpPut("PutProjeto")]
        public async Task<IActionResult> Put(ProjetoDTO projetoDTO)
        {
            await _Service.AlterarProjetoDTO(projetoDTO);
            return Ok("Membro altera com sucesso");
        }

        [HttpDelete("DeleteProjeto/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _Service.oRepositoryProjeto.ExcluirAsync(id);
                return Ok("Projeto excluido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
