﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Gerenciador_De_Projetos.MODEL.Models;

public partial class TAREFA
{
    public int TarCodigo { get; set; }

    public string TarNome { get; set; }

    public string TarDescricao { get; set; }

    public bool TarStatus { get; set; }

    public DateTime TarDataInicio { get; set; }

    public DateTime? TarDataFinal { get; set; }

    public virtual ICollection<PROJETO> PROJETO { get; set; } = new List<PROJETO>();
}