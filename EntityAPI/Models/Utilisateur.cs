using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAPI.Models
{
    public class Utilisateur
    {
        [Key]
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Password { get; set; }
        public int Type { get; set; }
        public int Statut { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}
