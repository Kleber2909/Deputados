using System;
using System.Collections.Generic;
using System.Text;

namespace Deputados.Model
{
    class Evolucao
    {
        public String CnpjCpf { get; set; }
        public String TipoGasto { get; set; }
        public String DescricaoGasto { get; set; }
        public String DataEmissao { get; set; }
        public Double Valor { get; set; }

        public Evolucao (String dataEmissao, Double valor)
        {
            this.DataEmissao = dataEmissao;
            this.Valor = valor;
        }
    }
}
