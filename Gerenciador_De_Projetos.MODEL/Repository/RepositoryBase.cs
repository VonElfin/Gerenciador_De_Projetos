using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gerenciador_De_Projetos.MODEL.Models;
using Gerenciador_De_Projetos.MODEL.Interfaces;

namespace Gerenciador_De_Projetos.MODEL.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {
        public Gerenciador_De_ProjetosContext _context;
        public bool _saveChanges = true;

        public RepositoryBase(Gerenciador_De_ProjetosContext context, bool saveChanges)
        {
            _context = context;
            _saveChanges = saveChanges;
        }



        public T Alterar(T obj)
        {
            throw new NotImplementedException();
        }

        public Task<T> AlterarAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(T obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(params object[] var)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirAsync(params object[] var)
        {
            throw new NotImplementedException();
        }

        public T Incluir(T obj)
        {
            throw new NotImplementedException();
        }

        public Task<T> IncluirAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public T SelecionarChave(params object[] var)
        {
            throw new NotImplementedException();
        }

        public Task<T> SelecionarChaveAsync(params object[] var)
        {
            throw new NotImplementedException();
        }

        public List<T> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> SelecionarTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
