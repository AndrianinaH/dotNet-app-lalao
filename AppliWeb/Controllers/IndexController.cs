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
    [Authorize(Roles = "Joueur")]
    public class IndexController : BaseController
    {
        // GET: Index
        public ActionResult Index()
        {
            ViewBag.Title = "Tableau de bord";
            ViewBag.color = this.color;
            Utilisateur userCo =  this.GetConnectedUser();
            ViewBag.user = userCo;

            dynamic myModel = new ExpandoObject();
            myModel.messages = MessageService.GetMessageById(userCo.Id);
            myModel.resultats = ResultatService.GetResultatById(userCo.Id);

            return View(myModel);
        }
    }
}