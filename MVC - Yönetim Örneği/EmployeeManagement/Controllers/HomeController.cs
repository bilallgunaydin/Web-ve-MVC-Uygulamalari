    
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
    //Projede bize lazım olacak!!!!!!!!!Login olmadan sayfalara yönlendirmesin diye.//En üstte olması tüm action'ları etkilesin diye kullanılacak.
    public class HomeController : Controller
    {
        [LoginRequired]
        // GET: /Home/
        //Bu aslında filders klasöründeki LoginRequiredAttribute class'ıdır.
        public ActionResult Index()
        {
            //if (Session["PersonId"]==null)
            //{
            //    return RedirectToAction("Index", "Login");//İkinci view'e gider. //Request sadece Action'a gelir.
            //}
            int loginEmpId = Convert.ToInt32(Session["PersonId"]);
            Employee loginEmp = new DataContext().Employees.FirstOrDefault(x => x.Id == loginEmpId);

            object LoginEmpName = loginEmp.FirstName + " " + loginEmp.LastName;
            return View(LoginEmpName);//Giriş yaparken kullanıcının ismi görünecek.
        }
        public ActionResult LoginUser()
        {
            int loginEmpId = Convert.ToInt32(Session["PersonId"]);
            Employee loginEmp = new DataContext().Employees.FirstOrDefault(x => x.Id == loginEmpId);

            //object LoginEmpName = loginEmp.FirstName + " " + loginEmp.LastName;

            return PartialView(loginEmp);

        }
    }
}