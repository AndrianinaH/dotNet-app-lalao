using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityAPI.Models;
using Newtonsoft.Json;

namespace AppliWeb.Controllers
{
    public class BaseController : Controller
    {
        protected String color ="amber";

        //----------- for FormsAuthentication (role manager)
        protected Utilisateur GetConnectedUser()
        {
            if (HttpContext.User.Identity.IsAuthenticated){
                return JsonConvert.DeserializeObject<Utilisateur>(HttpContext.User.Identity.Name);
            }
            else{
                return null;
            }
        }

        //----------- for rest service (session du navigateur web)
        protected Utilisateur GetSessionUser()
        {  
            return (Utilisateur)Session["app_lalao_user"]; 
        }
    }
}