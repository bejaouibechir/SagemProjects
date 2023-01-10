#define permiere
//#define deuxieme
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagem.DataAccess.SQL.CF.Data
{
    public class BusinessDbContext :DbContext
    {
        public BusinessDbContext()
        {

        }

        public BusinessDbContext(DbContextOptions<BusinessDbContext> options)
            :base(options)
        {

        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<EmployeeDepartement> EmployeeDepartements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=PC2022;Initial Catalog=FirmDB;Integrated Security=True;TrustServerCertificate=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder mbuilder)
        {
#if permiere
                mbuilder.ApplyConfiguration<EmployeeDepartement>
                (new EmployeeDepartementMap());
#endif


#if deuxieme
//Many to many relation permière technique de configuration 
            mbuilder.Entity<EmployeeDepartement>().ToTable("EmployeeDepartement");

            mbuilder.Entity<EmployeeDepartement>()
             .HasKey(r => new { r.DepId, r.EmpId});

            mbuilder.Entity<EmployeeDepartement>()
                .HasOne(d => d.Departement)
                .WithMany(r => r.EmployeeDepartements)
                .HasForeignKey(r=>r.DepId);


            mbuilder.Entity<EmployeeDepartement>()
                .HasOne(e=>e.Employee)
                .WithMany(r => r.EmployeeDepartements)
                .HasForeignKey(r => r.EmpId);
#endif
            

           
            

          
            
            base.OnModelCreating(mbuilder);
        }



    }
}
