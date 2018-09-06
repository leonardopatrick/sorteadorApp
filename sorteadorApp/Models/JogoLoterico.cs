using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sorteadorApp.Models
{
    public class JogoLoterico
    {
        private String nome;
        private int qtdNumerosSorteado;
        private int qtdMaximaAposta;
        private int qtdMinAposta;
        private int qtdMaxAposta;
        private String corConcurso;

        public string CorConcurso { get => corConcurso; set => corConcurso = value; }
        public string Nome { get => nome; set => nome = value; }
        public int QtdMinAposta { get => qtdMinAposta; set => qtdMinAposta = value; }
        public int QtdMaxAposta { get => qtdMaxAposta; set => qtdMaxAposta = value; }
        public int QtdNumerosSorteado { get => qtdNumerosSorteado; set => qtdNumerosSorteado = value; }
        public int QtdMaximaAposta { get => qtdMaximaAposta; set => qtdMaximaAposta = value; }
    }
}