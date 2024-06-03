using SitioWebUDB.Daos;
using SitioWebUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitioWebUDB.Controllers {
    public class HomeController : Controller {

        private NoticiaDao noticiaDao;
        private FacultadDao facultadDao;
        private CarreraDao carreraDao;

        public HomeController() {
            noticiaDao = new NoticiaDao();
            facultadDao = new FacultadDao();
            carreraDao = new CarreraDao();
        }

        // GET: Noticias
        public ActionResult Index() {
            try {
                List<Noticia> noticias = new List<Noticia>();
                noticias = noticiaDao.ObtenerNoticias();
                return View(noticias);
            } catch (Exception) {
                return View();
            }
        }

        // GET: Facultades
        public ActionResult Facultades() {
            try {
                List<Facultad> facultades = new List<Facultad>();
                facultades = facultadDao.ObtenerFacultades();
                return View(facultades);
            } catch (Exception) {
                return View();
            }
        }

        // GET: Carreras
        public ActionResult Carreras(int idFacultad) {
            try {
                List<Carrera> carreras = new List<Carrera>();
                carreras = carreraDao.ObtenerCarrerasXIdFac(idFacultad);
                return View(carreras);
            } catch (Exception) {
                return View();
            }
        }
    }
}