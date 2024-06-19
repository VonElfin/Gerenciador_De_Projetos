using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerenciador_De_Projetos.MODEL.DTO;
using Gerenciador_De_Projetos.MODEL.Models;
using Gerenciador_De_Projetos.MODEL.Repository;

namespace Gerenciador_De_Projetos.MODEL.Services
{
    public class ServiceTarefa
    {
        public RepositoryTarefa oRepositoryTarefa {  get; set; }
        private Gerenciador_De_ProjetosContext _context;

        public ServiceTarefa(Gerenciador_De_ProjetosContext context)
        {
            _context = context;
            oRepositoryTarefa = new RepositoryTarefa(context);
        }

        public async Task IncluirTarefaDTO(TarefaDTO tarefaDTO)
        {
            var tarefa = new TAREFA()
            {
                TarCodigo = tarefaDTO.tarCodigo,
                TarCodigoProjeto = tarefaDTO.tarCodigoProjeto,
                TarNome = tarefaDTO.tarNome,
                TarDescricao = tarefaDTO.tarDescricao,
                TarStatus = tarefaDTO.tarStatus,
                TarDataInicio = tarefaDTO.tarDataInicio,
                TarDataFinal = tarefaDTO.tarDataFinal
            };
            await oRepositoryTarefa.IncluirAsync(tarefa);
        }
        
        public async Task AlterarTarefaDTO(TarefaDTO tarefaDTO)
        {
            var tarefa = new TAREFA()
            {
                TarCodigo = tarefaDTO.tarCodigo,
                TarCodigoProjeto = tarefaDTO.tarCodigoProjeto,
                TarNome = tarefaDTO.tarNome,
                TarDescricao = tarefaDTO.tarDescricao,
                TarStatus = tarefaDTO.tarStatus,
                TarDataInicio = tarefaDTO.tarDataInicio,
                TarDataFinal = tarefaDTO.tarDataFinal
            };
            await oRepositoryTarefa.AlterarAsync(tarefa);
        }
    }
}
