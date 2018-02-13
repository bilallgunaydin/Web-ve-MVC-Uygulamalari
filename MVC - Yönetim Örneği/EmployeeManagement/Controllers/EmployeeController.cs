using EmployeeManagement.EF;
using EmployeeManagement.EF.Entities;
using EmployeeManagement.Filters;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    [LoginRequired]
    public class EmployeeController : Controller
    {
        DataContext _dbContext = new DataContext();
        //public ActionResult Index()
        //{
        //    List<Employee> model = _dbContext.Employees.ToList();
        //    return View(model);
        //}
        public ActionResult Index()
        {
            List<EmployeeListModel> model = _dbContext.Employees
                .Select(x => new EmployeeListModel()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.EmailAddress,
                    DepartmentName = x.Department.Name,
                    Id = x.Id
                }).ToList();

            //Yukardakinin açık hali : Ya select method olmasaydı!!!
            //List<Employee> model2 = _dbContext.Employees.ToList();
            //List<EmployeeListModel> liste = new List<EmployeeListModel>();
            //foreach (var mdl in model2)
            //{
            //    EmployeeListModel elm = new EmployeeListModel();
            //    elm.FirstName = mdl.FirstName;
            //    elm.LastName = mdl.LastName;
            //    elm.Email = mdl.EmailAddress;
            //    elm.DepartmentName = mdl.Department.Name;
            //    elm.Id = mdl.Id;

            //    liste.Add(elm);
            //}

            return View(model);
        }
        public ActionResult Edit(int? id)
        {
            Employee employee = null;

            if (id.HasValue)
            {
                employee = _dbContext.Employees.SingleOrDefault(e => e.Id == id); ;
            }
            else
            {
                employee = new Employee();
            }
            if (employee != null)
            {

                List<Department> allDepartments = _dbContext.Departments.ToList();
                //ViewBag=Dinamic nesnelerde .nokta deyip string, tarih oluşturulur. Anlık Olarak property oluşturur.View'a yardımcı verileri taşımak için kullanılan bir çanta olarak düşünülebilir.
                SelectList departmentsSelectList = new SelectList(allDepartments, "Id", "Name");

                //ViewBag.Departments = departmentsSelectList;
                ViewData["Departments"] = departmentsSelectList;
                ViewData["Test"] = "Tsubasa";

                return View(employee);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (employee.Id > 0)
            {
                _dbContext.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                _dbContext.Entry(employee).State = System.Data.Entity.EntityState.Added;
            }
            try
            {

                _dbContext.SaveChanges();
                //ViewBag.ResultMessage = "Kaydetme işlemi başarılı";
                //ViewBag veya ViewData'nın ömrü action kadardır. Aşağıda RedirectToAction deyince ikinci action olduğundan ikinci kullanımda çalışmaz. 
                TempData["ResultMessage"] = "İşlem başarılı";
                //Session["Test"] = "Test";
                //TempData["Test"] = "Hala Burada mısın?";
                //Tempdata 1 kere kullanılınca ömrü biter.
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Employee silinecekEmp = _dbContext.Employees.FirstOrDefault(x => x.Id == id);
                return View(silinecekEmp);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Employee silinecekEmp = _dbContext.Employees.FirstOrDefault(x => x.Id == id);
            if(silinecekEmp!=null)
               {
                _dbContext.Employees.Remove(silinecekEmp);
                _dbContext.SaveChanges();
                
                return RedirectToAction("Index");
            }
            else{
                return HttpNotFound();
            }
        }
    }
}