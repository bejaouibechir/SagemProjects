using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Sagem.DataAccess.SQL.DF.Data
{
    public partial class BusinessDBContext : DbContext
    {
        public BusinessDBContext()
        {
        }

        public BusinessDBContext(DbContextOptions<BusinessDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departement> Departements { get; set; } = null!;
        public virtual DbSet<PeopleEmployee> PeopleEmployees { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //A remplacer par une méthode d'extension voir la
            //classe ServiceCollectionExtensions
            
            //if (!optionsBuilder.IsConfigured)
            //{

            //    optionsBuilder.UseSqlServer("Data Source=PC2022;Initial Catalog=BusinessDB;Integrated Security=True;TrustServerCertificate=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departement>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.HasMany(d => d.Employees)
                    .WithMany(p => p.Departements)
                    .UsingEntity<Dictionary<string, object>>(
                        "DepartementEmployee",
                        l => l.HasOne<PeopleEmployee>().WithMany().HasForeignKey("EmployeesId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_DepartementEmployee_Employee"),
                        r => r.HasOne<Departement>().WithMany().HasForeignKey("DepartementsId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_DepartementEmployee_Departement"),
                        j =>
                        {
                            j.HasKey("DepartementsId", "EmployeesId");

                            j.ToTable("DepartementEmployee");

                            j.HasIndex(new[] { "EmployeesId" }, "IX_FK_DepartementEmployee_Employee");

                            j.IndexerProperty<int>("DepartementsId").HasColumnName("Departements_Id");

                            j.IndexerProperty<int>("EmployeesId").HasColumnName("Employees_Id");
                        });
            });

            modelBuilder.Entity<PeopleEmployee>(entity =>
            {
                entity.ToTable("People_Employee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PeopleEmployee)
                    .HasForeignKey<PeopleEmployee>(d => d.Id)
                    .HasConstraintName("FK_Employee_inherits_Person");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
