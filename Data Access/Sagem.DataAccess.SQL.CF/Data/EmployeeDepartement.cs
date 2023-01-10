using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagem.DataAccess.SQL.CF.Data
{
    public class EmployeeDepartement
    {
        public int EmpId { get; set; }
        public int DepId { get; set; }

        //Propriété de naviguation
        public Employee Employee { get; set; }
        public Departement Departement { get; set; }


    }
}
