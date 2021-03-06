﻿using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Destinatarios.Modelos
{
    public class DestinatarioModelo
    {
        public long Id { get; set; }

        public string NomeRazaoSocial { get; set; }

        public string Documento { get; set; }

        public string TipoDeDocumento { get; set; }

        public string InscricaoEstadual { get; set; }

        public string EnderecoLogradouro { get; set; }

        public int EnderecoNumero { get; set; }

        public string EnderecoBairro { get; set; }

        public string EnderecoMunicipio { get; set; }

        public string EnderecoEstado { get; set; }

        public string EnderecoPais { get; set; }
    }
}
