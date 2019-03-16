using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAPI.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public String Content { get; set; }
        public int IdAuteur { get; set; }
        public int IdDestinataire { get; set; }
        public String Etat { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}
