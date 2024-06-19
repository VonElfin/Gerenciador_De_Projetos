using Gerenciador_De_Projetos.MODEL.DTO;
using Gerenciador_De_Projetos.MODEL.Models;
using Gerenciador_De_Projetos.MODEL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador_De_Projetos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private Gerenciador_De_ProjetosContext _context;
        private ServiceEndereco _Service;

        public EnderecoController(Gerenciador_De_ProjetosContext context)
        {
            _context = context;
            _Service = new ServiceEndereco(context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _Service.oRepositoryEndereco.SelecionarTodosAsync());
        }

        [HttpGet("GetEnderecoById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _Service.oRepositoryEndereco.SelecionarChaveAsync(id));
        }

        [HttpPost("PostEndereco")]
        public async Task<IActionResult> Post(EnderecoDTO enderecoDTO)
        {
            await _Service.IncluirEnderecoDTO(enderecoDTO);
            return Ok("Endereco Cadastrado com sucesso");
        }
        


    }
}
