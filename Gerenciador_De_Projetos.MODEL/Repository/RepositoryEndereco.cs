﻿using Gerenciador_De_Projetos.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_De_Projetos.MODEL.Repository
{
    public class RepositoryEndereco : RepositoryBase<ENDERECO>
    {
        public RepositoryEndereco(Gerenciador_De_ProjetosContext context, bool saveChanges = true) : base(context, saveChanges)
        {
        }
    }
}
