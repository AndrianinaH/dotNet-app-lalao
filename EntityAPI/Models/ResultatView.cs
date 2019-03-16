using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAPI.Models
{
    public class ResultatView
    {
        [Key]
        public int Id { get; set; }
        public int IdAuteur { get; set; }
        public String NomAuteur { get; set; }
        public int IdDestinataire { get; set; }
        public String NomDestinataire { get; set; }
        public int ScoreAuteur { get; set; }
        public int ScoreDestinataire { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}

//    CREATE VIEW ResultatViews as
//    SELECT
//    Resultats.Id,
//    IdAuteur,
//    Utilisateurs.nom as NomAuteur,
//    Resultats.DateCreation,
//    IdDestinataire,
//    u.nom as nom_destinataire,
//    ScoreAuteur,
//    ScoreDestinataire
//    FROM
//    Resultats
//    JOIN Utilisateurs ON Utilisateurs.Id = Resultats.IdAuteur
//    JOIN Utilisateurs as u ON u.id = Resultats.IdDestinataire