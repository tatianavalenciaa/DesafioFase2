using SitioWebUDB.Daos;
using SitioWebUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitioWebUDB.Controllers {
    public class LoginController : Controller {

        private UsuarioDao usuarioDao;

        public LoginController() { 
            usuarioDao = new UsuarioDao();
        }

        // GET: Login
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(Login login) {

            try {

                Usuario usuario = usuarioDao.ObtenerUsuario(login.Usuario, login.Password);

                if (usuario == null) {
                    TempData["Msj"] = "Usuario o Password Incorrecto!";
                    return RedirectToAction("Index", "Login");
                }

                // Si llegamos hasta aqui, es porque si existe el usuario y esta activo
                Session["usuario"] = usuario.User;
                return RedirectToAction("Index", "Administracion");
            } catch {
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult CerrarSesion() {

            try {
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("Index", "Home");
            } catch {
                return View();
            }
        }
    }
}