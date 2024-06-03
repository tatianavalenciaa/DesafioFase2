using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioWebUDB.Models {
    public class Carrera {

        public Carrera() { }

        public int IdCarrera { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Facultad { get; set; }
    }
}