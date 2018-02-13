using _02_WebForm_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_WebForm_Uygulama
{
    public partial class EmployeeListForm_image_ : System.Web.UI.Page
    {
        public List<Employee> _employeeList;
        protected void Page_Load(object sender, EventArgs e)
        {
            _employeeList = new NorthwindEntities().Employees.ToList();
        }
    }
}