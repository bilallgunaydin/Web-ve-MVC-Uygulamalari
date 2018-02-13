using _02_WebForm_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_WebForm_Uygulama
{
    public partial class EmployeeListForm : System.Web.UI.Page
    {
        NorthwindEntities _dbContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new NorthwindEntities();
            EmployeeList();
               
        }

        private void EmployeeList()
        {
            if (!Page.IsPostBack)
            {
                rptEmployee.DataSource = _dbContext.Employees.Select(x => new
                {
                    x.EmployeeID,
                    x.FirstName,
                    x.LastName
                }).ToList();
                rptEmployee.DataBind();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string employeeIdstr = (sender as Button).Attributes["data-id"];
            int employeeId = int.Parse(employeeIdstr);


            Employee _employee = _dbContext.Employees.Find(employeeId);
            _dbContext.Employees.Remove(_employee);
            _dbContext.SaveChanges();

            Response.Redirect("EmployeeListForm.aspx");

        }
    }
}