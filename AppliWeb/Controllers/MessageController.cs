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
    public class MessageController : BaseController
    {
        // GET: Message
        public ActionResult AllMessages()
        {
            ViewBag.Title = "Gestion des messages";
            ViewBag.color = this.color;

            ViewBag.error = TempData["error"];

            dynamic myModel = new ExpandoObject();
            myModel.allMessage = MessageService.AllMessage();
            myModel.allUser = UtilisateurService.AllUser();

            return View(myModel);
        }

        [HttpPost]
        public ActionResult Save(Message message)
        {
            MessageService.SaveMessage(message);
            return RedirectToAction("AllMessages", "Message");
        }

        [HttpPost]
        public ActionResult Delete(Message message)
        {
            MessageService.DeleteMessage(message);
            return RedirectToAction("AllMessages", "Message");
        }


    }
}