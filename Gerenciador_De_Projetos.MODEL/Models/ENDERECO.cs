﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Gerenciador_De_Projetos.MODEL.Models;

public partial class ENDERECO
{
    public int EndCodigo { get; set; }

    public int EndCodigoMembro { get; set; }

    public string EndCEP { get; set; }

    public string EndPais { get; set; }

    public string EndUF { get; set; }

    public string EndCidade { get; set; }

    public string EndBairro { get; set; }

    public string EndLogradouro { get; set; }

    public int EndNumero { get; set; }

    public string EndComplemento { get; set; }

    public virtual MEMBROS EndCodigoMembroNavigation { get; set; }
}