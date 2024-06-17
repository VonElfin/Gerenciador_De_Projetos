using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_De_Projetos.MODEL.DTO
{
    public class MembrosDTO
    {
        public int memCodigo { get; set; }

        public string memNome { get; set; }

        public string memSexo { get; set; }

        public string memCPF { get; set; }

        public string memEmail { get; set; }

        public string memTelefone { get; set; }

        public DateTime memDataNascimento { get; set; }
    }
}
