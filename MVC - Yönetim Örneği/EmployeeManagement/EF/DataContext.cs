using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EmployeeManagement.EF.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using EmployeeManagement.Migrations;


namespace EmployeeManagement.EF
{
    public class DataContext:DbContext
    {
        public DataContext()
            : base("EmployeeManagementConnection")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Mappings.DepartmentMapping.Map(modelBuilder);
            Mappings.EmployeeMapping.Map(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();// tablo sonlarındaki "s" takılarını siler.
        }
    }
}