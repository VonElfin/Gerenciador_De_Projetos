﻿using Gerenciador_De_Projetos.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_De_Projetos.MODEL.Repository
{
    public class RepositoryMembros : RepositoryBase<MEMBROS>
    {
        public RepositoryMembros(Gerenciador_De_ProjetosContext context, bool saveChanges = true) : base(context, saveChanges)
        {
        }
    }
}
