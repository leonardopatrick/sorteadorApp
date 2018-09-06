using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sorteadorApp.Models
{
    public class Aposta
    {
        public int idAposta { get; set; }
        public int idConcurso { get; set; }
        public List<int> numeros { get; set; }
        public int qtdNumeros { get; set; }
        public String tipo { get; set; }
        public DateTime dataHora { get; set; }
        public String  corConcurso { get; set; }
        public String dataHoraFormatada { get; set; }
        // public abstract Apostar();
    }
}