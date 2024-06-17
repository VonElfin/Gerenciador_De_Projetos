using Microsoft.AspNetCore.Mvc;
using Gerenciador_De_Projetos.MODEL.Models;
using Gerenciador_De_Projetos.MODEL.DTO;
using Gerenciador_De_Projetos.MODEL.Services;

namespace Gerenciador_De_Projetos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembrosController : ControllerBase
    {
        private Gerenciador_De_ProjetosContext _context;
        private ServiceMembros _Service;

        public MembrosController(Gerenciador_De_ProjetosContext context)
        {
            _context = context;
            _Service = new ServiceMembros(_context);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _Service.oRepositoryMembros.SelecionarTodosAsync());
        }
        [HttpGet("GetMembrosById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _Service.oRepositoryMembros.SelecionarChaveAsync(id));
        }

        [HttpPost("PostMembros")]
        public async Task<IActionResult> Post(MembrosDTO membros)
        {
            await _Service.IncluirMembroDTO(membros);
            return Ok("Membro Cadastro com sucesso");
        }

        [HttpPut("PutMembros")]
        public async Task<IActionResult> Put(MembrosDTO membro)
        {
            await _Service.AlterarMembroDTO(membro);
            return Ok("Membro Cadastrado com sucesso");
        }
    }
}
