using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_De_Projetos.MODEL.DTO
{
    public class ProjetoDTO
    {

        public int proCodigo { get; set; }

        public string proNome { get; set; }

        public bool proStatus { get; set; }

        public DateTime proDataInicio { get; set; }

        public DateTime? proDataFinal { get; set; }
    }
}
