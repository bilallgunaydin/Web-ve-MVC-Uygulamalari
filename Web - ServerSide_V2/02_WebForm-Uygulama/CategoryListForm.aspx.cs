using _02_WebForm_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_WebForm_Uygulama
{
    public partial class CategoryListForm : System.Web.UI.Page
    {
        NorthwindEntities _dbContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new NorthwindEntities();

            var allCategories = (from c in _dbContext.Categories
                                 select new
                                 {
                                     c.CategoryID,
                                     c.CategoryName,
                                     c.Description
                                 }).ToList();

            gridCategories.DataSource = allCategories;
            gridCategories.DataBind();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string categoryIdStr = (sender as Button).Attributes["data-id"];
            int categoryId = int.Parse(categoryIdStr);

            Category category = _dbContext.Categories.Find(categoryId);
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();

            //gridCategories.DataSource = _dbContext.Categories.ToList();
            //gridCategories.DataBind();

            Response.Redirect("CategoryListForm.aspx");
        }

        
    }
}