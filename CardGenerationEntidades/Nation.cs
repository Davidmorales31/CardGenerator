using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGenerationEntidades
{
    public class Nation
    {
        public int IdNation { get; set; }
        public string Nations { get; set; }
        public string NationUrl { get; set; }

        public string DescripcionConImagen { get; set; }
        // Constructor Vacio
        public Nation() { }
    }
}
