using EmployeeManagement.EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EmployeeManagement.EF.Mappings
{
    public class DepartmentMapping
    {

        //public DepartmentMapping(DbModelBuilder  modelBuilder)
        //{
        //    modelBuilder.Entity<Departman>.HasKey();
        //}
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Department> entity = modelBuilder.Entity<Department>();
            
            //modelBuilder.Entity<Department>().HasKey(d => d.Id);
            //modelBuilder.Entity<Department>().Property(d => d.Name).IsRequired();

            entity.HasKey(d => d.Id);
            //departmentConfig.Property(d => d.Name).IsRequired();
            //departmentConfig.Property(d => d.Name).HasMaxLength(50);

            entity.Property(d => d.Name).IsRequired().HasMaxLength(50);

            entity.Property(d => d.Description).HasMaxLength(500);

            //entity.HasMany(d => d.Employees)
            //    .WithRequired(e => e.Department)
            //    .HasForeignKey(e => e.DepartmentId)
            //    .WillCascadeOnDelete(false);
        }
    }
}