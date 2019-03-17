using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EntityAPI.Models;
using Newtonsoft.Json;
using ProjetService.Services;

namespace AppliWeb.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        public object UtilsateurService { get; private set; }

        // GET: Auth
        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            ViewBag.color = this.color;
            ViewBag.loginError = TempData["loginError"];
            return View();
        }

        [HttpPost]
        public ActionResult Connexion(Utilisateur user)
        {
            try
            {
                Utilisateur userCo =  AuthService.Login(user);
                FormsAuthentication.SetAuthCookie(JsonConvert.SerializeObject(userCo), false);
                //-------- set session for rest service
                Session["app_lalao_user"] = userCo;
                if (userCo.Type == 1){
                    return RedirectToAction("AllResultats", "Resultat");
                }
                return RedirectToAction("Index", "Index");
            }
            catch(Exception ex)
            {
                TempData["loginError"] = ex.Message;
                return RedirectToAction("Login","Auth");
            }
           
        }

        public ActionResult Logout()
        {
            Session.Clear();
            AuthService.Logout(this.GetConnectedUser());
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Auth");
        }

        // GET: Auth
        public ActionResult Signup()
        {
            ViewBag.Title = "Signup";
            ViewBag.color = this.color;
            ViewBag.loginError = TempData["loginError"];
            return View();
        }

        public ActionResult Inscription(Utilisateur user)
        {
            try
            {
                Utilisateur userCo = AuthService.SaveUtilisateur(user);
                return RedirectToAction("Login", "Auth");
            }
            catch (Exception ex)
            {
                TempData["loginError"] = ex.Message;
                return RedirectToAction("Signup", "Auth");
            }
        }


    }
}