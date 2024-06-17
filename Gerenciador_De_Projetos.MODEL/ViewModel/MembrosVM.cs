using Gerenciador_De_Projetos.MODEL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_De_Projetos.MODEL.ViewModel
{
    public class MembrosVM
    {
        // Membros

        public int CodigoMembro { get; set; }

        public string NomeMembro { get; set; }

        public string Sexo { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }

        // Endereco

        public int CodigoEndereco { get; set; }

        public string CEP { get; set; }

        public string Pais { get; set; }

        public string UF { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }


        public async static Task<List<MembrosVM>> GetMembrosVM()
        {
            var db = new Gerenciador_De_ProjetosContext();
            var listaMembros = await db.MEMBROS.ToListAsync();
            return await (from mem in db.MEMBROS
                          join end in db.ENDERECO on mem.MemCodigo equals end.EndCodigo
                          select new MembrosVM
                          {
                              CodigoEndereco = end.EndCodigo,
                              CEP = end.EndCEP,
                              Pais = end.EndPais,
                              UF = end.EndUF,
                              Cidade = end.EndCidade,
                              Bairro = end.EndBairro,
                              Logradouro = end.EndLogradouro,
                              Numero = end.EndNumero,
                              Complemento = end.EndComplemento,
                              CodigoMembro = mem.MemCodigo,
                              NomeMembro = mem.MemNome,
                              Sexo = mem.MemSexo,
                              CPF = mem.MemCPF,
                              Email = mem.MemEmail,
                              Telefone = mem.MemTelefone,
                              DataNascimento = mem.MemDataNascimento
                          }).ToListAsync();
        }
    }
}
