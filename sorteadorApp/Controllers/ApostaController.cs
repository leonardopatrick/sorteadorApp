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

        [Route("getApostas")]
        public List<Aposta> getApostas()
        {
            geraApostaSurpresinha(1, 2);
            todasApostas();
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
        public List<Aposta> sorteio([FromBody] Aposta aposta)
        {
            geraApostaSurpresinha(aposta.idConcurso, aposta.qtdNumeros);
            return apostas;
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
        public List<Aposta> sorteiaNumeros([FromBody] Aposta aposta)
        {
            geraSorteio(aposta.idConcurso, aposta.qtdNumeros);
            return apostaSorteada;
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