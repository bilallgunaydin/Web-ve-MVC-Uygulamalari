using EmployeeManagement.EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EmployeeManagement.EF.Mappings
{
    public class EmployeeMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Employee> entity = modelBuilder.Entity<Employee>();

            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50).HasColumnType("varchar");//IsRequired=Null geçilemez.
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.DateofBirth).HasColumnType("date").IsOptional();//İsOptional=Null geçilebilir.
            entity.Property(e => e.EmailAddress).HasMaxLength(100);
            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.HireDate).HasColumnType("date");


            entity.HasRequired(e => e.Department)
                //.WithRequiredDependent//
                .WithMany(d=> d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .WillCascadeOnDelete(false);//Bir kayıt silindiğine o for key ile bağlı ilişkili kayıtlar silinsin mi silinmesin mi Örn= Category silinince Product silinsin mi // False ise silinmicek


        }
    }
}