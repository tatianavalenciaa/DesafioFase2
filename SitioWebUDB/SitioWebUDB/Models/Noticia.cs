using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioWebUDB.Models {
    public class Noticia {

        public Noticia() { }

        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public DateTime FechaCrea { get; set; }
    }
}