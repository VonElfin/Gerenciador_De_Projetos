using Gerenciador_De_Projetos.MODEL.DTO;
using Gerenciador_De_Projetos.MODEL.Models;
using Gerenciador_De_Projetos.MODEL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador_De_Projetos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private Gerenciador_De_ProjetosContext _context;
        private ServiceTarefa _Service;

        public TarefaController(Gerenciador_De_ProjetosContext context)
        {
            _context = context;
            _Service = new ServiceTarefa(_context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _Service.oRepositoryTarefa.SelecionarTodosAsync());
        }

        [HttpGet("GetTarefaById/${id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _Service.oRepositoryTarefa.SelecionarChaveAsync(id));
        }

        [HttpPost("PostTarefa")]
        public async Task<IActionResult> Post(TarefaDTO tarefa)
        {
            await _Service.IncluirTarefaDTO(tarefa);
            return Ok("Tarefa cadastrada com sucesso");
        }

        [HttpPut("PutTarefa")]
        public async Task<IActionResult> Put(TarefaDTO tarefa)
        {
            await _Service.AlterarTarefaDTO(tarefa);
            return Ok("Tarefa cadastrado com sucesso");
        }

        [HttpDelete("DeleteMembro/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _Service.oRepositoryTarefa.ExcluirAsync(id);
                return Ok("Membro excluido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
