using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sorteadorApp.Models
{
    public class ApostaSorteada:Aposta
    {
        public List<int> apostasGanhadorasSena { get; set; }
        public List<int> apostasGanhadorasQuina { get; set; }
        public List<int> apostasGanhadorasQuadra { get; set; }
        public List<int> apostasGanhadorasTerno { get; set; }

    }
}