using System;
using System.Collections.Generic;
using System.Text;

namespace Deputados.Model
{
    class GastosCNPJ
    {
        public String Cnpj { get; set; }
        public String Descricao { get; set; }
        public String Detalhe { get; set; }
        public Double TotalGasto { get; set; }

        public GastosCNPJ(String descricao, Double totalGasto)
        {
            this.Descricao = descricao;
            this.TotalGasto = totalGasto;
        }
    }
}
