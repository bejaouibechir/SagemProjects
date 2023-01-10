using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sagem.DataAccess.SQL.CF.Data
{
    public class Employee
    {
        public Employee()
        {
            EmployeeDepartements = new HashSet<EmployeeDepartement>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string HireDate { get; set; }


        public int ManagerId { get; set; }

        //Propriété de naviguation
        public ICollection<EmployeeDepartement> EmployeeDepartements
        { get; set; }
    }
}
