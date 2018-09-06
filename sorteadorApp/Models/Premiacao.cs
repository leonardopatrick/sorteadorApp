using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sorteadorApp.Models
{
    public class Premiacao : Concurso
    {
        private float valor ;
        private float acumulado;

        public float Valor { get => valor; set => valor = value; }
        public float Acumulado { get => acumulado; set => acumulado = value; }
    }
}