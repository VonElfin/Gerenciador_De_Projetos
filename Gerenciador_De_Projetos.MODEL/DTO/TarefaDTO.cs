using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_De_Projetos.MODEL.DTO
{
    public class TarefaDTO
    {
        public int tarCodigo { get; set; }

        public int tarCodigoProjeto { get; set; }

        public string tarNome { get; set; }

        public string tarDescricao { get; set; }

        public bool tarStatus { get; set; }

        public DateTime tarDataInicio { get; set; }

        public DateTime? tarDataFinal { get; set; }
    }
}
