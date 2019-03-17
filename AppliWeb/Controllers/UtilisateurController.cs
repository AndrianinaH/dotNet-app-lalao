using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityAPI.Models;
using ProjetService.Services;

namespace AppliWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UtilisateurController : BaseController
    {
        // GET: Utilisateur
        public ActionResult AllUsers()
        {
            ViewBag.Title = "Gestion des utilisateurs";
            ViewBag.color = this.color;
            ViewBag.user = this.GetConnectedUser();

            ViewBag.error = TempData["error"];

            dynamic myModel = new ExpandoObject();
            myModel.allUser = UtilisateurService.AllUser();

            return View(myModel);
        }

        [HttpPost]
        public ActionResult Save(Utilisateur user)
        {
            try
            {
                AuthService.SaveUtilisateur(user);
                return RedirectToAction("AllUsers", "Utilisateur");
            }
            catch(Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("AllUsers", "Utilisateur");
            }
           
        }

        [HttpPost]
        public ActionResult Delete(Utilisateur user)
        {
            try
            {
                AuthService.DeleteUtilisateur(user);
                return RedirectToAction("AllUsers", "Utilisateur");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("AllUsers", "Utilisateur");
            } 
        }
    }
}