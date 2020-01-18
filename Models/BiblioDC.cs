using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Biblio
{
    class BiblioDC : DbContext
    {
        public BiblioDC():base("Data Source=.;Initial Catalog=biblio1;Integrated Security=True")
        {

        }

        public DbSet<Auteur> auteurs { get; set; }
        public DbSet<Theme> themes { get; set; }
        public DbSet<Livre> livres { get; set; }
    }
}
