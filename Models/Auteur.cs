using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Biblio
{
    public class Auteur
    {
        public Int32 AuteurId { get; set; }
        [Required]
        public String nom { get; set; }
        public String prenom { get; set; }
        public String nationalite { get; set; }
       
        public ICollection<Livre> livres { get; set; }
    }
}
