using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sagem.DataAccess.SQL.DF.Data
{
    public partial class Departement
    {
        public Departement()
        {
            Employees = new HashSet<PeopleEmployee>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }

        public virtual ICollection<PeopleEmployee> Employees { get; set; }
    }
}
