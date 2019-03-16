using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityAPI.Models;

namespace EntityAPI.Config
{
    public class ConfigContext : DbContext
    {
        public ConfigContext() : base("AppLalao")
        {
          
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Resultat> Resultats { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        public DbSet<MessageView> MessagesView { get; set; }
        public DbSet<ResultatView> ResultatsView { get; set; }

    }
}
