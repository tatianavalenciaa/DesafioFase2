using SitioWebUDB.Daos;
using SitioWebUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitioWebUDB.Controllers {
    public class FacultadesController : Controller {

        private FacultadDao facultadDao;
        public FacultadesController() { 
            this.facultadDao = new FacultadDao();
        }

        // GET: Facultades
        public ActionResult Index() {
            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Home");
                }
                List<Facultad> facultades = facultadDao.ObtenerFacultades();
                return View(facultades);
            } catch (Exception) {
                return View();
            }
        }

        // GET: Facultades/RegistrarForm
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

        // POST: Facultades/Registrar
        [HttpPost]
        public ActionResult Registrar(Facultad facultad) {

            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Login");
                }
                if (!ModelState.IsValid) {
                    return View("RegistrarForm", facultad);
                }
                facultadDao.RegistrarFacultad(facultad);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Facultades/ModificarForm
        [HttpGet]
        public ActionResult ModificarForm(int id) {

            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Login");
                }
                Facultad facultad = new Facultad();
                facultad = facultadDao.ObtenerFacultad(id);
                return View(facultad);
            } catch {
                return View();
            }

        }

        // POST: Facultades/Modificar
        [HttpPost]
        public ActionResult Modificar(Facultad facultad) {

            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Login");
                }
                if (!ModelState.IsValid) {
                    return View("ModificarForm", facultad);
                }
                facultadDao.ModificarFacultad(facultad);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Facultades/ActIna
        [HttpGet]
        public ActionResult ActIna(int id) {

            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Login");
                }
                facultadDao.ActInaFacultad(id);
                return RedirectToAction("Index");
            } catch {
                return View();
            }

        }
        
    }
}