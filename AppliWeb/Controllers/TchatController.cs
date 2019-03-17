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
    public class TchatController : BaseController
    {
        // GET: Tchat
        public ActionResult Index(int id)
        {
            ViewBag.Title = "Gestion des messages";
            ViewBag.color = this.color;
            Utilisateur userCo = this.GetConnectedUser();
            ViewBag.user = userCo;

            ViewBag.error = TempData["error"];

            dynamic myModel = new ExpandoObject();
            myModel.destinataire = UtilisateurService.GetUserById(id);
            myModel.messages = MessageService.GetMessage(userCo.Id, id);

            MessageService.AddViewMessage(userCo.Id, id);

            return View(myModel);
        }

        //------------ Ajax calling
        [AllowAnonymous]
        public JsonResult SendMessage(Message message)
        {
            message.DateCreation = DateTime.Now;
            MessageService.SaveMessage(message);
            return Json(message);
        }

        [AllowAnonymous]
        public JsonResult GetMessage(Message mess)
        {
            // Using Json.NET serializer
            //string _dateFormat = "yyyy-MM-dd HH:mm:ss";
            //var isoConvert = new IsoDateTimeConverter();
            //isoConvert.DateTimeFormat = _dateFormat;
            //response.Write(JsonConvert.SerializeObject(Data, isoConvert));
            return Json(MessageService.GetMessage(mess.IdAuteur, mess.IdDestinataire),JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult GetLastMessage(int idAuteur, int idDestinataire, int idLastMessage)
        {
            return Json(MessageService.GetLastMessage(idAuteur, idDestinataire, idLastMessage), JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult UserDisponible()
        {
            if(this.GetSessionUser() != null) return Json(UtilisateurService.UserConnected(this.GetSessionUser().Id), JsonRequestBehavior.AllowGet);
            return null;
        }

        [AllowAnonymous]
        public JsonResult CreateResultat(Resultat res)
        {
            Random rand = new Random();
            res.DateCreation = DateTime.Now;
            res.ScoreAuteur = rand.Next(100);
            res.ScoreDestinataire = rand.Next(100);
            ResultatService.SaveResultat(res);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public String IsMessageVu(int idLastMessage,int idAuteur, int idDestinataire)
        {
            bool res = MessageService.IsMessageVu(idLastMessage, idAuteur, idDestinataire);
            String result = "non-lu";
            if (res){
                result = "lu";
            }
            return result;
        }


    }
}