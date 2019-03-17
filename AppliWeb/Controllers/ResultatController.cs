using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetService.Services;

namespace AppliWeb.Controllers
{
    public class ResultatController : BaseController
    {
        // GET: Resultat
        public ActionResult AllResultats()
        {
            ViewBag.Title = "Gestion des résultats";
            ViewBag.color = this.color;
        
            dynamic myModel = new ExpandoObject();
            myModel.allResultat = ResultatService.AllResultat();

            return View(myModel);
        }
    }
}