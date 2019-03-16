using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAPI.Models
{
    public class Resultat
    {
        [Key]
        public int Id { get; set; }
        public int IdAuteur { get; set; }
        public int IdDestinataire { get; set; }
        public int ScoreAuteur { get; set; }
        public int ScoreDestinataire { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}
