using Gerenciador_De_Projetos.MODEL.DTO;
using Gerenciador_De_Projetos.MODEL.Interfaces;
using Gerenciador_De_Projetos.MODEL.Models;
using Gerenciador_De_Projetos.MODEL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_De_Projetos.MODEL.Services
{
    public class ServiceEndereco
    {
        public RepositoryEndereco oRepositoryEndereco {  get; set; }

        private Gerenciador_De_ProjetosContext _context;

        public ServiceEndereco(Gerenciador_De_ProjetosContext context)
        {
            _context = context;
            oRepositoryEndereco = new RepositoryEndereco(context);
        }

        public async Task IncluirEnderecoDTO(EnderecoDTO enderecoDTO)
        {
            var endereco = new ENDERECO()
            {
                EndBairro = enderecoDTO.endBairro,
                EndCEP = enderecoDTO.endCEP,
                EndCidade = enderecoDTO.endCidade,
                EndComplemento = enderecoDTO.endComplemento,
                EndLogradouro = enderecoDTO.endLogradouro,
                EndNumero = enderecoDTO.endNumero,
                EndPais = enderecoDTO.endPais,
                EndUF = enderecoDTO.endUF
            };
            await oRepositoryEndereco.IncluirAsync(endereco);
        }
    }
}
