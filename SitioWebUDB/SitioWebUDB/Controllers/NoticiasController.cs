using SitioWebUDB.Daos;
using SitioWebUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitioWebUDB.Controllers {
    public class NoticiasController : Controller {

        private NoticiaDao noticiaDao;
        public NoticiasController() { 
            this.noticiaDao = new NoticiaDao();
        }

        // GET: Noticias
        public ActionResult Index() {
            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Home");
                }
                List<Noticia> noticias = noticiaDao.ObtenerNoticiasDesc();
                return View(noticias);
            } catch (Exception) {
                return View();
            }
        }

        // GET: Noticias/RegistrarForm
        [HttpGet]
        public ActionResult RegistrarForm() {

            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Home");
                }
            } catch (Exception) {
                return View();
            }

            return View();

        }

        // POST: Noticias/Registrar
        [HttpPost]
        public ActionResult Registrar(Noticia noticia) {

            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Login");
                }
                if (!ModelState.IsValid) {
                    return View("RegistrarForm", noticia);
                }
                noticiaDao.RegistrarNoticia(noticia);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Noticias/ModificarForm
        [HttpGet]
        public ActionResult ModificarForm(int id) {

            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Login");
                }
                Noticia noticia = new Noticia();
                noticia = noticiaDao.ObtenerNoticia(id);
                return View(noticia);
            } catch {
                return View();
            }

        }

        // POST: Noticias/Modificar
        [HttpPost]
        public ActionResult Modificar(Noticia noticia) {

            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Login");
                }
                if (!ModelState.IsValid) {
                    return View("ModificarForm", noticia);
                }
                noticiaDao.ModificarNoticia(noticia);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Noticias/ActIna
        [HttpGet]
        public ActionResult ActIna(int id) {

            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Login");
                }
                noticiaDao.ActInaNoticia(id);
                return RedirectToAction("Index");
            } catch {
                return View();
            }

        }
    }
}