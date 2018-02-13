using EmployeeManagement.EF;
using EmployeeManagement.EF.Entities;
using EmployeeManagement.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string userId, string password, string rememberMe)
        {
            LoginHelper helper = new LoginHelper();
            bool loginSuccess = helper.LoginUser(userId, password, rememberMe, System.Web.HttpContext.Current);
            //Employee emp = new DataContext().Employees.FirstOrDefault(x => x.UserId == userId && x.Password == password);

            if (loginSuccess)
            {
                //Session["PersonId"] = emp.Id;//Session araştır
                //if(!string.IsNullOrEmpty(rememberMe) && rememberMe=="on")
                //{
                //    Response.Cookies["UserId"].Value = userId;
                //    Response.Cookies["UserId"].Expires = DateTime.Now.AddYears(1);//Expires özelliği cookies süresini belirledik. Zaman olarak 1 yıl tutar. 
                //    Response.Cookies["Password"].Value = password;
                //    Response.Cookies["Password"].Expires = DateTime.Now.AddYears(1);
                //    //Response ve Request araştır.
                //}


                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı ve şifre kombinasyonu hatalı!";
                return View();
            }
        }
        public ActionResult LogOut()
        {
            Session["PersonId"] = null;
            return RedirectToAction("Index");
            //Emre Hoca Bilge: Yaptığımız uygulamada kullanıcı LogOut olduktan sonra Session temizliyoruz, aynı şekilde Response.Cookies içerisinden UserId ve Password değerlerinin de temizlenmesi lazım                        
            //Emre Hoca Bilge: Aksi takdirde çıkış yaptıktan sonra sayfa yenilendiğinde kullanıcı sürekli giriş yapmış olur :)
        }

    }
}