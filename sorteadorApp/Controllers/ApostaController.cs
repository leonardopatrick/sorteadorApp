using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using sorteadorApp.Models;
using sorteadorApp.Models.utils;

namespace sorteadorApp.Controllers
{

    [RoutePrefix("api/JogoLoterico")]
    public class ApostaController : ApiController
    {
       private static List<Aposta> apostas = new List<Aposta>();
       private List<Aposta> apostaSorteada = new List<Aposta>();
       private List<int> numerosSorteados;

        [Route("getApostas")]
        public List<Aposta> getApostas()
        {
            geraApostaSurpresinha(1, 2);
            //todasApostas();
            return apostas;
        }

        [Route("geraSuprersinha")]
        [HttpPost]
        public List<Aposta> geraSuprersinha([FromBody] Aposta aposta)
        {
            geraApostaSurpresinha(aposta.idConcurso, aposta.qtdNumeros);

            return apostas;
        }

        [Route("sorteio")]
        [HttpPost]
        public Dictionary<int, Aposta> sorteio([FromBody] Aposta aposta)
        {

           

            geraApostaSurpresinha(aposta.idConcurso, aposta.qtdNumeros);

          
            foreach (var aS in apostaSorteada)
            {
                numerosSorteados = aS.numeros;
             }

            var dicionario = new Dictionary<int, Aposta>();

            foreach (var aP in apostas)
            {
                //int i = 0;
                int j = 0;
                foreach (var n in aP.numeros)
                {
                    if (numerosSorteados.Contains(n)) {
                        j++;
                    };

                }

                
                dicionario.Add(j, aP);
            }



            return dicionario;
        }

        [Route("addAposta")]
        [HttpPost]
        public List<Aposta> addAposta([FromBody] Aposta aposta)
        {
            apostas.Add(aposta);
            return apostas;
        }

        [Route("sorteiaNumeros")]
        [HttpPost]
        public List<ApostaSorteada> sorteiaNumeros([FromBody] Aposta aposta)
        {
            List<ApostaSorteada> retornoSorteio = new List<ApostaSorteada>();
            geraSorteio(aposta.idConcurso, aposta.qtdNumeros);


            foreach (var aS in apostaSorteada)
            {
                numerosSorteados = aS.numeros;
            }

            var retorno = new Dictionary<List<int>, Dictionary<int,int>>();
            var dicionario = new Dictionary<Aposta, List<int>>();
            var apostasGanhadoresSena = new  List<int>();
            var apostasGanhadoresQuina = new List<int>();
            var apostasGanhadoresQuadra = new List<int>();
            var apostasGanhadoresTerno = new List<int>();

            foreach (var aP in apostas)
            {
                List<int> i = new List<int>() ;
                int j = 0;
                foreach (var n in aP.numeros)
                {
                    if (numerosSorteados.Contains(n))
                    {
                        j++;
                    };

                }
                if(!i.Contains(j))
                i.Add(j);

                if (j >= 6) { 
                    apostasGanhadoresSena.Add(aP.idAposta);
                }

                if (j == 5)
                {
                        apostasGanhadoresQuina.Add(aP.idAposta);
                }

                if (j == 4)
                {
                    apostasGanhadoresQuadra.Add(aP.idAposta);
                }

                if (j == 3)
                {
                    apostasGanhadoresTerno.Add(aP.idAposta);
                }
                dicionario.Add(aP, i );
             //  
                  
            }

            Concurso concurso = getConcurso(aposta.idConcurso);

            retornoSorteio.Add(new ApostaSorteada {
                idAposta = apostas.Count + 1,
                idConcurso = concurso.IdConcurso,
                numeros = numerosSorteados,
                dataHora = DateTime.Now,
                corConcurso = concurso.CorConcurso,
                apostasGanhadorasSena = apostasGanhadoresSena,
                apostasGanhadorasQuina = apostasGanhadoresQuina,
                apostasGanhadorasQuadra = apostasGanhadoresQuadra,
                apostasGanhadorasTerno = apostasGanhadoresTerno,
                dataHoraFormatada = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
            
            return retornoSorteio;
        }

        public Concurso getConcurso(int idConcurso)
        {

            Concurso novoConcurso = null;
            if (idConcurso == 1)
                novoConcurso = new Concurso
                {
                    Nome = "MegaSena",
                    IdConcurso = 1,
                    CorConcurso = "#0b8043",
                    QtdMinAposta = 1,
                    QtdMaxAposta = 60,
                    QtdNumerosSorteado = 6,
                    QtdMaximaAposta = 15,
                    Data = DateTime.Now
                };

            if (idConcurso == 2)
                novoConcurso = new Concurso
                {
                    IdConcurso = 2,
                    CorConcurso = "#ff5722",
                    Nome = "LotoMania",
                    QtdMinAposta = 1,
                    QtdMaxAposta = 100,
                    QtdNumerosSorteado = 20,
                    QtdMaximaAposta = 30,
                    Data = DateTime.Now
                };


            return novoConcurso;

        }

        public List<Aposta> todasApostas()
        {
            return apostas;
        }

        public void geraApostaSurpresinha(int idConcurso)
        {
            SorteioUtils.geraNrosSurpresinha(getConcurso(idConcurso), apostas);
        }

        public void geraApostaSurpresinha(int idConcurso, int qtdNumeros)
        {
           
            SorteioUtils.geraNrosSurpresinha(getConcurso(idConcurso), qtdNumeros, apostas);
        }

        public void geraSorteio(int idConcurso, int qtdNumeros)
        {

            SorteioUtils.geraNrosSurpresinha(getConcurso(idConcurso), qtdNumeros, apostaSorteada);
        }


    }
}