using SitioWebUDB.Daos;
using SitioWebUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitioWebUDB.Controllers {
    public class CarrerasController : Controller {

        private CarreraDao carreraDao;
        public CarrerasController() { 
            this.carreraDao = new CarreraDao();
        }

        // GET: Carreras
        public ActionResult Index() {
            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Home");
                }
                List<Carrera> carreras = carreraDao.ObtenerCarreras();
                return View(carreras);
            } catch (Exception) {
                return View();
            }
        }

        // GET: Carreras/RegistrarForm
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

        // POST: Carreras/Registrar
        [HttpPost]
        public ActionResult Registrar(Carrera carrera) {

            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Login");
                }
                if (!ModelState.IsValid) {
                    return View("RegistrarForm", carrera);
                }
                carreraDao.RegistrarCarrera(carrera);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Carreras/ModificarForm
        [HttpGet]
        public ActionResult ModificarForm(int id) {

            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Login");
                }
                Carrera carrera = new Carrera();
                carrera = carreraDao.ObtenerCarrera(id);
                return View(carrera);
            } catch {
                return View();
            }

        }

        // POST: Carreras/Modificar
        [HttpPost]
        public ActionResult Modificar(Carrera carrera) {

            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Login");
                }
                if (!ModelState.IsValid) {
                    return View("ModificarForm", carrera);
                }
                carreraDao.ModificarCarrera(carrera);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Carreras/ActIna
        [HttpGet]
        public ActionResult ActIna(int id) {

            try {
                if (Session["usuario"] == null) {
                    return RedirectToAction("Index", "Login");
                }
                carreraDao.ActInaCarrera(id);
                return RedirectToAction("Index");
            } catch {
                return View();
            }

        }
        
    }
}