using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblio
{
    public class Theme
    {
        public Int32 ThemeId { get; set; }
        [Required]
        public String titre{ get; set; }
        public String Description { get; set; }
        public ICollection<Livre> livres { get; set; }
    }
}
