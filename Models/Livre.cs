using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblio
{
    public class Livre
    {
        public Int32 LivreId { get; set; }
        [Required]
        public String titre { get; set; }
        public String description { get; set; }
        public double prix { get; set; }
        public Int32 quantite { get; set; }
        public double poids { get; set; }
        public String langue { get; set; }
        [DataType(DataType.Date)]
        public DateTime datepublication { get; set; }

        public Int32 AuteurId { get; set; }
        public Auteur auteur { get; set; }

        public Int32 ThemeId { get; set; }
        public Theme theme { get; set; }

    }
}
