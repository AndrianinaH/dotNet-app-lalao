﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetService.Services;

namespace AppliWeb.Controllers
{
    public class UtilisateurController : BaseController
    {
        // GET: Utilisateur
        public ActionResult AllUsers()
        {
            ViewBag.Title = "Gestion des utilisateurs";
            ViewBag.color = this.color;

            ViewBag.error = TempData["error"];

            dynamic myModel = new ExpandoObject();
            myModel.allUser = UtilisateurService.AllUser();

            return View(myModel);
        }
    }
}