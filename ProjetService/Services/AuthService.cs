using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityAPI.Config;
using EntityAPI.Models;
using ProjetService.Utils;

namespace ProjetService.Services
{
    public class AuthService
    {
        public static Utilisateur Login(Utilisateur utilisateur)
        {
            using (var ctx = new ConfigContext())
            {
                utilisateur.Password = Util.Sha1(utilisateur.Password);
                List<Utilisateur> allUser = ctx.Utilisateurs.Where(b => b.Nom == utilisateur.Nom && b.Password == utilisateur.Password).ToList();
                if (allUser.Count != 0)
                {
                    var userConnecter = allUser[0];
                    userConnecter.Statut = 1;
                    ctx.Utilisateurs.AddOrUpdate(userConnecter);
                    ctx.SaveChanges();
                    return userConnecter;
                }
                else throw new Exception("Authentification echouer");
            }
        }

        public static void Logout(Utilisateur utilisateur)
        {
            using (var ctx = new ConfigContext())
            {
                utilisateur.Statut = 0;
                ctx.Utilisateurs.AddOrUpdate(utilisateur);
                ctx.SaveChanges();
            }
        }

        public static Utilisateur SaveUtilisateur(Utilisateur utilisateur)
        {
            using (var ctx = new ConfigContext())
            {
                if (utilisateur.Id == 0)
                {//------------- add
                    utilisateur.Password = Util.Sha1(utilisateur.Password);
                    List<Utilisateur> allUser = ctx.Utilisateurs.Where(g => g.Nom == utilisateur.Nom).ToList();
                    if (allUser.Count !=0) throw new Exception("Ce nom d'utilisateur existe déjà, réessayer avec un autre");
                }
                else
                {//------------- update
                    if (utilisateur.Password != "" && utilisateur.Password != null)
                    {
                        utilisateur.Password = Util.Sha1(utilisateur.Password);
                    }
                    else
                    {
                        var userInBdd = ctx.Utilisateurs.Find(utilisateur.Id);
                        utilisateur.Password = (String)userInBdd.Password;
                    }
                }
                ctx.Utilisateurs.AddOrUpdate(utilisateur);
                ctx.SaveChanges();
                return utilisateur;
            }
        }

        public static void DeleteUtilisateur(Utilisateur utilisateur)
        {
            using (var ctx = new ConfigContext())
            {
                List<Message> allMessage = ctx.Messages.Where(m => m.IdAuteur == utilisateur.Id && m.IdDestinataire == utilisateur.Id).ToList();
                if (allMessage.Count != 0) throw new Exception("Un message est encore assigné à cet utilisateur, supprimez ce message avant de supprimer cet utilisateur");
                ctx.Utilisateurs.Attach(utilisateur);
                ctx.Utilisateurs.Remove(utilisateur);
                ctx.SaveChanges();
            }
        }
    }
}
