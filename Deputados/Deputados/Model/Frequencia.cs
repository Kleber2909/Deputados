using System;
using System.Collections.Generic;
using System.Text;

namespace Deputados.Model
{
    class Frequencia
    {
        public String IdParlamentar { get; set; }
        public String Ano { get; set; }
        public String PresencasDias { get; set; }
        public String PresencasSessoes { get; set; }
        public String AusenciasDias { get; set; }
        public String AusenciasSessoes { get; set; }
        public Double IndicePresenca { get; set; }

    }
}
