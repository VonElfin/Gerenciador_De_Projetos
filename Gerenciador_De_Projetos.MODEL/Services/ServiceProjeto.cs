using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerenciador_De_Projetos.MODEL.DTO;
using Gerenciador_De_Projetos.MODEL.Interfaces;
using Gerenciador_De_Projetos.MODEL.Models;
using Gerenciador_De_Projetos.MODEL.Repository;

namespace Gerenciador_De_Projetos.MODEL.Services
{
    public class ServiceProjeto
    {
        public RepositoryProjeto oRepositoryProjeto {  get; set; }
        private Gerenciador_De_ProjetosContext _context;

        public ServiceProjeto(Gerenciador_De_ProjetosContext context)
        {
            _context = context;
            oRepositoryProjeto = new RepositoryProjeto(context);
        }

        public async Task IncluirProjetoDTO(ProjetoDTO projetoDTO)
        {
            var projeto = new PROJETO()
            {
                ProCodigo = projetoDTO.proCodigo,
                ProNome = projetoDTO.proNome,
                ProStatus = projetoDTO.proStatus,
                ProDataInicio = projetoDTO.proDataInicio,
                ProDataFinal = projetoDTO.proDataFinal
            };
            await oRepositoryProjeto.IncluirAsync(projeto);
        }

        public async Task AlterarProjetoDTO(ProjetoDTO projetoDTO)
        {
            var projeto = new PROJETO()
            {
                ProCodigo = projetoDTO.proCodigo,
                ProNome = projetoDTO.proNome,
                ProStatus = projetoDTO.proStatus,
                ProDataInicio = projetoDTO.proDataInicio,
                ProDataFinal = projetoDTO.proDataFinal
            };
            await oRepositoryProjeto.AlterarAsync(projeto);
        }
    }
}
