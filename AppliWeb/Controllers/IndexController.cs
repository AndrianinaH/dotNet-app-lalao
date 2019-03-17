using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetService.Services;

namespace AppliWeb.Controllers
{
    public class IndexController : BaseController
    {
        // GET: Index
        public ActionResult Index()
        {
            ViewBag.Title = "Tableau de bord";
            ViewBag.color = this.color;

            dynamic myModel = new ExpandoObject();
            myModel.messages = MessageService.GetMessageById(1);
            myModel.resultats = ResultatService.GetResultatById(1);
            //allModel << ["messages" : messageService.getMessageById((int)session.grails_user.id)]
            //allModel << ["resultats" : resultatService.getResultatById(session.grails_user.id)]

            return View(myModel);
        }
    }
}