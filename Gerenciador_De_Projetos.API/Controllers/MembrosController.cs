using Microsoft.AspNetCore.Mvc;
using Gerenciador_De_Projetos.MODEL.Models;
using Gerenciador_De_Projetos.MODEL.DTO;
using Gerenciador_De_Projetos.MODEL.Services;
using System;

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
        public async Task<IActionResult> Post(MembrosDTO membro)
        {
            await _Service.IncluirMembroDTO(membro);
            return Ok("Membro cadastrado com sucesso");
        }

        [HttpPut("PutMembros")]
        public async Task<IActionResult> Put(MembrosDTO membro)
        {
            await _Service.AlterarMembroDTO(membro);
            return Ok("Membro alterado com sucesso");
        }

        [HttpDelete("DeleteMembro/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _Service.oRepositoryMembros.ExcluirAsync(id);
                return Ok("Membro excluido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
