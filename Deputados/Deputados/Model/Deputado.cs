using System;
using System.Collections.Generic;
using System.Text;

namespace Deputados.Model
{
    public class Deputado
    {
        public Int32 Id { get; set; }
        public String NomeParlamentar { get; set; }
        public String NomeCompleto { get; set; }
        public String Cargo { get; set; }
        public String Partido { get; set; }
        public String Mandato { get; set; }
        public String Sexo { get; set; }
        public String Uf { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }
        public String Nascimento { get; set; }
        public String FotoURL { get; set; }
        public byte[] Foto { get; set; }
        public Double GastoTotal { get; set; }
        public Double GastoPorDia { get; set; }

    }
}
