namespace EmployeeManagement.Migrations
{
    using EmployeeManagement.EF.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeManagement.EF.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeManagement.EF.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            Department yazilimDepartment=new Department { Name = "Yazýlým", Description = "Yazýlým Proje Geliþtirme" };
            Department sistemDepartment= new Department() { Name = "Sistem", Description = "Sistem,Network,Güvenlik" };
            
            //TODO: Aþaðýdaki data gelmedi, neden gelmedi? Seet metodu ne zaman çalýþýr?
            Department muhasebeDepartment = new Department() { Name = "Muhasebe", Description = "Para-Alýþ-Veriþ" };
            context.Departments.AddOrUpdate(
                d => d.Name, 
                yazilimDepartment,
                sistemDepartment,
                muhasebeDepartment);

            context.Employees.AddOrUpdate(
                e => e.FirstName,
                new Employee()
                {
                    FirstName = "Tsubasa",
                    LastName = "Ozora",
                    Department = yazilimDepartment,
                    Salary = 1800,
                    Gender = Gender.Male,
                    EmailAddress = "tsubasa@ozora.com",
                }, new Employee()
                {
                    FirstName = "Misaki",
                    LastName = "Taro",
                    Department = sistemDepartment,
                    Salary = 1400,
                    Gender = Gender.Male,
                    EmailAddress = "misaki@taro.com"
                });
           
        }
    }
}
