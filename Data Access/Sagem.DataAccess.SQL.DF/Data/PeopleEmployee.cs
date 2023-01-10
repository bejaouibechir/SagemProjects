using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sagem.DataAccess.SQL.DF.Data
{
    public partial class PeopleEmployee
    {
        public PeopleEmployee()
        {
           
            Departements = new HashSet<Departement>();
        }


        [Key]
        public int Id { get; set; }

        public virtual Person IdNavigation { get; set; } = null!;

        //Propriété de naviguation
        public virtual ICollection<Departement> Departements { get; set; }
    }
}
