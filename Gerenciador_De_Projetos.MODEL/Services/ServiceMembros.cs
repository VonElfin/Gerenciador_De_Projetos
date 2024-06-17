using Gerenciador_De_Projetos.MODEL.DTO;
using Gerenciador_De_Projetos.MODEL.Models;
using Gerenciador_De_Projetos.MODEL.Repository;
using Gerenciador_De_Projetos.MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_De_Projetos.MODEL.Services
{
    public class ServiceMembros
    {
        public RepositoryMembros oRepositoryMembros {  get; set; }
        public RepositoryEndereco oRepositoryEndereco { get; set; }

        private Gerenciador_De_ProjetosContext _context;

        public ServiceMembros(Gerenciador_De_ProjetosContext context)
        {
            _context = context;
            oRepositoryMembros = new RepositoryMembros(context);
            oRepositoryEndereco = new RepositoryEndereco(context);
        }

        public async Task IncluirMembroDTO(MembrosDTO membroDTO)
        {
            var membro = new MEMBROS()
            {
                MemCodigo = membroDTO.memCodigo,
                MemCPF = membroDTO.memCPF,
                MemDataNascimento = membroDTO.memDataNascimento,
                MemEmail = membroDTO.memEmail,
                MemNome = membroDTO.memNome,
                MemSexo = membroDTO.memSexo,
                MemTelefone = membroDTO.memTelefone
            };
            await oRepositoryMembros.IncluirAsync(membro);
        }

        public async Task AlterarMembroDTO(MembrosDTO membrosDTO)
        {
            var membro = new MEMBROS()
            {
                MemCodigo = membrosDTO.memCodigo,
                MemCPF = membrosDTO.memCPF,
                MemNome = membrosDTO.memNome,
                MemEmail = membrosDTO.memEmail,
                MemSexo = membrosDTO.memSexo,
                MemTelefone = membrosDTO.memTelefone,
                MemDataNascimento = membrosDTO.memDataNascimento
            };
            await oRepositoryMembros.AlterarAsync(membro);
        }


        public async Task<MembrosVM> IncluirMembroAsync(MembrosVM membrosVM)
        {
            var membro = new MEMBROS()
            {
                MemCodigo = membrosVM.CodigoMembro,
                MemCPF = membrosVM.CPF,
                MemNome = membrosVM.NomeMembro,
                MemSexo = membrosVM.Sexo,
                MemEmail = membrosVM.Email,
                MemTelefone = membrosVM.Telefone,
                MemDataNascimento = membrosVM.DataNascimento
            };

            var endereco = new ENDERECO()
            {
                EndBairro = membrosVM.Bairro,
                EndCEP = membrosVM.CEP,
                EndCidade = membrosVM.Cidade,
                EndCodigo = membrosVM.CodigoEndereco,
                EndComplemento = membrosVM.Complemento,
                EndLogradouro = membrosVM.Logradouro,
                EndNumero = membrosVM.Numero,
                EndPais = membrosVM.Pais,
                EndUF = membrosVM.UF
            };

            membro.EndCodigoNavigation = endereco;

            await oRepositoryMembros.IncluirAsync(membro);

            return membrosVM;
        }
    }
}
