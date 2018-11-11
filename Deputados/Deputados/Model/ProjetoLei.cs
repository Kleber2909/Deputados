using System;
using System.Collections.Generic;
using System.Text;

namespace Deputados.Model
{
    class ProjetoLei
    {
        public String Nome { get; set; }
        public String Ano { get; set; }
        public String IdParlamentarAutor { get; set; }
        public String NomeAutor { get; set; }
        public String DataApresentacao { get; set; }
        public String Sigla { get; set; }
        public String Ementa { get; set; }
    }
}
