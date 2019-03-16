using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAPI.Models
{
    public class MessageView
    {
        [Key]
        public int Id { get; set; }
        public String Content { get; set; }
        public int IdAuteur { get; set; }
        public String NomAuteur { get; set; }
        public int IdDestinataire { get; set; }
        public String NomDestinataire { get; set; }
        public String Etat { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}

//    CREATE VIEW MessageViews as
//    SELECT
//    Messages.Id, IdAuteur,
//    Utilisateurs.Nom as nomAuteur,
//    Content,
//    Messages.DateCreation,
//    IdDestinataire,
//    u.Nom as NomDestinataire,
//    Etat
//    FROM Messages
//    JOIN Utilisateurs ON Utilisateurs.Id = Messages.IdAuteur
//    JOIN Utilisateurs as u ON u.Id = Messages.IdDestinataire
