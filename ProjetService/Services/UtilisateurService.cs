using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityAPI.Config;
using EntityAPI.Models;

namespace ProjetService.Services
{
    class UtilisateurService
    {
        public static List<Utilisateur> UserConnected(int idUser)
        {
            using (var ctx = new ConfigContext())
            {
                List<Utilisateur> users = ctx.Utilisateurs.Where(u => u.Id != idUser && u.Statut == 1 && u.Type != 1).ToList();
                return users;
            }
        }

        public static List<Utilisateur> AllJoueur()
        {
            using (var ctx = new ConfigContext())
            {
                List<Utilisateur> users = ctx.Utilisateurs.Where(u => u.Type == 2).ToList();
                return users;
            }
        }
    }
}
