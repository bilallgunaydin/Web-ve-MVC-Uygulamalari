using _02_WebForm_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_WebForm_Uygulama
{
    public partial class ProductListForm : System.Web.UI.Page
    {
        NorthwindEntities _dbcontext;
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbcontext = new NorthwindEntities();

            var allProducts = _dbcontext.Products.Select(x => new
            {
                x.ProductID,
                x.ProductName,
                x.Category.CategoryName,
                x.QuantityPerUnit,
                x.UnitPrice,
                x.UnitsInStock
            }).ToList();
            GridProducts.DataSource = allProducts;
            GridProducts.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string productIdStr = (sender as Button).Attributes["data-id"];
            int productId = int.Parse(productIdStr);

            Product product = _dbcontext.Products.Find(productId);
            _dbcontext.Products.Remove(product);
            _dbcontext.SaveChanges();


            //1. Sayfayı tekrardan yenilemek
            //gridCategories.DataSource = _dbContext.Categories.ToList();
            //gridCategories.DataBind();

            //2. Yada Aynı sayfaya yonlendiririz.
            Response.Redirect("ProductListForm.aspx");
            //Web.config e  <pages enableEventValidation="false"></pages> ekliyoruz.Calışmaz yoksa.
        }

        

    }
}