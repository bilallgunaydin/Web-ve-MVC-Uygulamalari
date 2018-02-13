using _02_WebForm_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_WebForm_Uygulama
{
    
    public partial class EmployeeEditForm : System.Web.UI.Page
    {
        NorthwindEntities _dbcontext;
        Employee _employee;
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbcontext = new NorthwindEntities();

            string employeeIdStr = Request.QueryString["id"];

            employeeIdStr = employeeIdStr ?? "0";
           

            int employeeId = int.Parse(employeeIdStr);

            if (employeeId == 0)
            {
              
                _employee = new Employee();
            }
            else
            {
                
                _employee = _dbcontext.Employees.Find(employeeId);

               
                if (!Page.IsPostBack)
                {
                   txtFirstName.Text = _employee.FirstName;
                   txtLastName.Text = _employee.LastName;
                }
             

                btnSave.Text = "Güncelle";

            }

           

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            _employee.FirstName = txtFirstName.Text;
            _employee.LastName = txtLastName.Text;

            if (_employee.EmployeeID == 0)
            {
                _dbcontext.Employees.Add(_employee);
            }

            _dbcontext.SaveChanges();

            Response.Redirect("EmployeeListForm.aspx");
        }

        
    }
}