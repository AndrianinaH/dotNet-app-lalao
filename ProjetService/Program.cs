using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityAPI.Config;
using EntityAPI.Models;
using ProjetService.Services;
using ProjetService.Utils;

namespace ProjetService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new ConfigContext())
            {
                //-- truncate
                //ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE Utilisateurs");

                //var obj = new Utilisateur
                //{
                //    Nom = "admin",
                //    Password = Util.Sha1("root"),
                //    Statut = 1,
                //    Type = 1,
                //    DateCreation = DateTime.Now
                //};

                //var obj1 = new Utilisateur
                //{
                //    Nom = "paul",
                //    Password = Util.Sha1("root"),
                //    Statut = 1,
                //    Type = 2,
                //    DateCreation = DateTime.Now
                //};

                //ctx.Utilisateurs.Add(obj);
                //ctx.Utilisateurs.Add(obj1);

                //var obj2 = ctx.Utilisateurs.Find(2);
                //obj2.Nom = "Paul";
                //ctx.Utilisateurs.AddOrUpdate(obj2);

                //var mess = new Message
                //{
                //    Id = 4,
                //    Content = "Hello world Groovy",
                //    IdAuteur = 1,
                //    IdDestinataire = 2,
                //    Etat = "non lu",
                //    DateCreation = DateTime.Now
                //};
                //ctx.Messages.AddOrUpdate(mess);

                //var mess2 = new Message
                //{
                //    Id = 3,
                //    Content = "Hello world Kotlin",
                //    IdAuteur = 1,
                //    IdDestinataire = 2,
                //    Etat = "non lu",
                //    DateCreation = DateTime.Now
                //};
                //ctx.Messages.AddOrUpdate(mess2);

                //ctx.SaveChanges();

                //AuthService.SaveUtilisateur(new Utilisateur
                //{
                //    Id = 4,  
                //    Nom = "simple utilisateur",
                //    Statut = 1,
                //    Type = 2,
                //    DateCreation = DateTime.Now
                //});

                //foreach (Message mess in MessageService.GetMessage(1, 2))
                //{
                //    Debug.WriteLine(mess.Content);
                //}
                foreach (MessageView mess in MessageService.GetMessageById(1))
                {
                    Debug.WriteLine(mess.Content);
                }

            }
        }
    }
}
