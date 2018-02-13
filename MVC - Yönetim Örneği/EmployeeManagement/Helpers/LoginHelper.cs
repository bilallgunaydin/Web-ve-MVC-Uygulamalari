using EmployeeManagement.EF;
using EmployeeManagement.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Helpers
{
    public class LoginHelper
    {
        internal bool LoginUser(string userId, string password, string rememberMe, HttpContext httpContext)
        {
            Employee emp = new DataContext().Employees.FirstOrDefault(x => x.UserId == userId && x.Password == password);

            if (emp != null)
            {
               httpContext.Session["PersonId"] = emp.Id;//Session araştır
                if (!string.IsNullOrEmpty(rememberMe) && rememberMe == "on")
                {
                    httpContext.Response.Cookies["UserId"].Value = userId;
                    httpContext.Response.Cookies["UserId"].Expires = DateTime.Now.AddYears(1);//Expires özelliği cookies süresini belirledik. Zaman olarak 1 yıl tutar. 
                    httpContext.Response.Cookies["Password"].Value = password;
                    httpContext.Response.Cookies["Password"].Expires = DateTime.Now.AddYears(1);
                    //Response ve Request araştır.
                }
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}