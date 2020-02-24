using MonumentPlay.Authentication;
using MonumentPlay.Models;
using MonumentPlay.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MonumentPlay.Controllers
{
    public class ManageController : Controller
    {
        IRepositoryMonument repo;
        public ManageController(IRepositoryMonument repo)
        {
            this.repo = repo;
        }
        // GET: Manage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(String nickname, String pass)
        {
            Usuario user = repo.GetUsuario(nickname,pass);
            if (user!=null)
            {
                //Creo un ticket
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                    (1,nickname,DateTime.Now,DateTime.Now.AddMinutes(15),true,"");

                //Encrypto el ticket 
                String dato = FormsAuthentication.Encrypt(ticket);

                //Creo la cookie
                HttpCookie cookie = new HttpCookie("COOKIE", dato);

                //Añado la cookie al response
                Response.Cookies.Add(cookie);

                String action = TempData["action"].ToString();
                String controller = TempData["controller"].ToString();

                return RedirectToAction(action,controller);
            }
            else {
                ViewBag.MensajeError = "Usuario/ contraseña incorrectos";
                return View();
            }
            
        }

        public ActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewUser(String nombreUs, String email, String nickName, String password)
        {
            repo.InsertarUsuario(nombreUs, nickName, email, password);
            //SweetAlert de Bienvenida, redirigir a la página de inicio
            return RedirectToAction("Index");
        }

        [Autorizacion]
        public ActionResult MiPerfil()
        {
            //Recuperar el último click
            String controller = TempData["controller"].ToString();
            String action = TempData["action"].ToString();

            return RedirectToAction(action,controller);
        }

        public ActionResult CerrarSesion()
        {
            //Limpiamos el usuario actual de sesión
            HttpContext.User = null;

            //Cerramos la sesión con el método SingOut()
            FormsAuthentication.SignOut();

            //Hacemos que la cookie expire (Quitando minutos)
            HttpCookie cookie = Response.Cookies["COOKIE"];
            cookie.Expires  = DateTime.Now.AddMinutes(-30);

            //Almacenamos la cookie 
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index");
        }


    }
}