using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sorteadorApp.Models
{
    public class Concurso: JogoLoterico
    {
        private int idConcurso;
        private DateTime data;
     
        public DateTime Data { get => data; set => data = value; }
        public int IdConcurso { get => idConcurso; set => idConcurso = value; }
    }
}