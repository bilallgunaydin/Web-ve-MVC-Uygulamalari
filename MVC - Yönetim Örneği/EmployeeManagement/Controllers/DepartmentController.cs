using EmployeeManagement.EF;
using EmployeeManagement.EF.Entities;
using EmployeeManagement.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    [LoginRequired]
    public class DepartmentController : Controller
    {
        DataContext _dbcontext = new DataContext();
        public ActionResult Index()
        {
            List<Department> model = _dbcontext.Departments.ToList();
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            Department model;
            if (id.HasValue)
            {
                model=_dbcontext.Departments.SingleOrDefault(d => d.Id == id); //Güncelleme
            }
            else
            
                model = new Department(); //Yeni Kayıt
            

            if (model != null)
            {


                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (department.Id != 0)
            {
                _dbcontext.Entry(department).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                _dbcontext.Entry(department).State = System.Data.Entity.EntityState.Added;
            }
            _dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult AddDepartment()
        {
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Department silinecekDep = _dbcontext.Departments.FirstOrDefault(x => x.Id == id);
                return View(silinecekDep);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
             Department silinecekDep = _dbcontext.Departments.FirstOrDefault(x => x.Id == id);
            if (silinecekDep!=null)
            {
               
                _dbcontext.Departments.Remove(silinecekDep);
                _dbcontext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

    
	}
}