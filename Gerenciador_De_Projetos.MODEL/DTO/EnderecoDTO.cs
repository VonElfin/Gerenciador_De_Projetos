using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_De_Projetos.MODEL.DTO
{
    public class EnderecoDTO
    {
        public int endCodigo { get; set; }

        public string endCEP { get; set; }

        public string endPais { get; set; }

        public string endUF { get; set; }

        public string endCidade { get; set; }

        public string endBairro { get; set; }

        public string endLogradouro { get; set; }

        public int endNumero { get; set; }

        public string endComplemento { get; set; }
    }
}
