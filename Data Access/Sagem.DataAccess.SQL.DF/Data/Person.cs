using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sagem.DataAccess.SQL.DF.Data
{
    public partial class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        //Propriété de naviguation
        public virtual PeopleEmployee? PeopleEmployee { get; set; }
    }
}
