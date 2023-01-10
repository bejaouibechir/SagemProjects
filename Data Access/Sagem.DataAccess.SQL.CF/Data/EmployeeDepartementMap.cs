using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

//Many to many relation deuxième technique de configuration
namespace Sagem.DataAccess.SQL.CF.Data
{
    internal class EmployeeDepartementMap : IEntityTypeConfiguration<EmployeeDepartement>
    {
        public void Configure(EntityTypeBuilder<EmployeeDepartement> mbuilder)
        {
            //Pour créer une table association EmployeeDepartements  
            mbuilder.ToTable("EmployeeDepartements");

            //Pour créer une clé composée
            mbuilder.HasKey(r => new { r.DepId, r.EmpId });


            // Créer 1 Employee avec plusieur EmployeeDepartements
            mbuilder
                .HasOne(e => e.Employee)
                .WithMany(r => r.EmployeeDepartements)
                .HasForeignKey(r => r.EmpId);

            // Créer 1 Departement avec plusieur EmployeeDepartements
            mbuilder
                .HasOne(c => c.Departement)
                .WithMany(r => r.EmployeeDepartements)
                .HasForeignKey(r => r.DepId);
        }
    }
}