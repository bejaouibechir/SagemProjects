using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagem.DataAccess.SQL.CF.Data
{
    public class Departement
    {

        public Departement()
        {
            EmployeeDepartements = new HashSet<EmployeeDepartement>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Region { get; set; }

        //Propriété de naviguation
        public ICollection<EmployeeDepartement> EmployeeDepartements
        { get; set; }
    }
}
