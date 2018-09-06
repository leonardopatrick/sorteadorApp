using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sorteadorApp.Models.utils
{
    public static class SorteioUtils
    {
        public static List<int> sorteiaNumerosSemRepetir(int quantidade, int minimo, int maximo)
        {
            // Validações dos argumentos.
            if (quantidade < 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");
            else if (quantidade > maximo + 1 - minimo)
                throw new ArgumentException("Quantidade deve ser menor do que a diferença entre máximo e mínimo.");
            else if (maximo <= minimo)
                throw new ArgumentException("Máximo deve ser maior do que mínimo.");

            List<int> numerosSorteados = new List<int>();
            numerosSorteados.Clear();
            Random rnd = new Random();

            while (numerosSorteados.Count < quantidade)
            {
                int numeroSorteado = rnd.Next(minimo, maximo + 1);

                // Número já foi sorteado? Então sorteamos novamente até o número não ter sido sorteado ainda.
                while (numerosSorteados.Contains(numeroSorteado))
                    numeroSorteado = rnd.Next(minimo, maximo + 1);

                numerosSorteados.Add(numeroSorteado);
            }

            return numerosSorteados;
        }

        public static List<int> novoSorteio(Concurso concurso)
        {

           List<int> numerosAposta = new List<int>();
            numerosAposta.Clear();
            numerosAposta = sorteiaNumerosSemRepetir(
                concurso.QtdNumerosSorteado, 
                concurso.QtdMinAposta, 
                concurso.QtdMaxAposta);
           numerosAposta.Sort();

           return numerosAposta;

        }

        public static List<int> novoSorteio(Concurso concurso, int qtdNumeros)
        {

            List<int> numerosAposta = new List<int>();
            numerosAposta.Clear();
            numerosAposta = sorteiaNumerosSemRepetir(
                            qtdNumeros,
                 concurso.QtdMinAposta,
                 concurso.QtdMaxAposta);
            /*Organiza Numeros*/
            numerosAposta.Sort();

            return numerosAposta;

        }

        public static List<Aposta> geraNrosSurpresinha(Concurso concurso, List<Aposta> apostas)
        {
            List<int> numerosAposta = new List<int>();
            numerosAposta.Clear();
            numerosAposta = novoSorteio(concurso);

            return registraNros(concurso, numerosAposta, apostas);
        }

        public static List<Aposta> geraNrosSurpresinha(Concurso concurso, int qtdNumeros, List<Aposta> apostas)
        {
            //Permite somente o nro maximo de apostas cadastradas no JogoLoterico
            if (concurso.QtdMaximaAposta < qtdNumeros)
                qtdNumeros = concurso.QtdMaximaAposta;

            if (concurso.QtdNumerosSorteado > qtdNumeros)
                qtdNumeros = concurso.QtdNumerosSorteado;

            List<int> numerosAposta = new List<int>();
            numerosAposta.Clear();
            numerosAposta = novoSorteio(concurso, qtdNumeros);

            return registraNros(concurso, numerosAposta, apostas);
        }

        public static List<Aposta> registraNros(Concurso concurso, List<int> numerosAposta, List<Aposta> apostas)
        {

            apostas.Add(new Aposta
            {
                idAposta = apostas.Count + 1,
                idConcurso = concurso.IdConcurso,
                numeros = numerosAposta,
                tipo = concurso.Nome,
                qtdNumeros = numerosAposta.Count,
                corConcurso = concurso.CorConcurso,
                dataHora = DateTime.Now,
                dataHoraFormatada = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });

            return apostas;

        }


    }
}