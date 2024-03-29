﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityAPI.Config;
using EntityAPI.Models;

namespace ProjetService.Services
{
    public class UtilisateurService
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

        public static List<Utilisateur> AllUser()
        {
            using (var ctx = new ConfigContext())
            {
                List<Utilisateur> users = ctx.Utilisateurs.ToList();
                return users;
            }
        }

        public static void DeleteUtilisateur(Utilisateur user)
        {
            using (var ctx = new ConfigContext())
            {
                ctx.Utilisateurs.Attach(user);
                ctx.Utilisateurs.Remove(user);
                ctx.SaveChanges();
            }
        }

        public static Utilisateur GetUserById(int id)
        {
            using (var ctx = new ConfigContext())
            {
                return ctx.Utilisateurs.Single(u => u.Id == id);
            }
        }
    }
}
