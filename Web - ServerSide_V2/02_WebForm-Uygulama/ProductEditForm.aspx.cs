using _02_WebForm_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_WebForm_Uygulama
{
    public partial class ProductEditForm : System.Web.UI.Page
    {
        NorthwindEntities _dbContext;
        Product _product;
        protected void Page_Load(object sender, EventArgs e)
        {

            //TODO: Görev ataması için todo kullanırız. TaskList'de görünür.
            _dbContext = new NorthwindEntities();
            if (!Page.IsPostBack)
            {
                CategoryList();
            }


            string productIdStr = Request.QueryString["id"];

            //Özel Ternary if kullanımı (null check)
            productIdStr = productIdStr ?? "0";
            //string deger = categoryIdStr == null ? "0" : categoryIdStr ;

            int productId = int.Parse(productIdStr);

            if (productId == 0)
            {
                //YENİ KAYIT
                _product = new Product();
            }
            else
            {
                //GÜNCELLEME
                _product = _dbContext.Products.Find(productId);

                //#if TEST
                if (!Page.IsPostBack)
                {
                    txtProductName.Text = _product.ProductName;
                    txtQuantityPerUnit.Text = _product.QuantityPerUnit;
                    txtUnitPrice.Text = _product.UnitPrice.ToString();
                    txtUnitsInStock.Text = _product.UnitsInStock.ToString();
                    DropListCategoryName.DataSource = _product.Category.CategoryName;
                    DropListCategoryName.DataValueField =_product.CategoryID.ToString();
                    DropListCategoryName.DataTextField =_product.Category.CategoryName;
                    

                }
                //#endif

                btnSave.Text = "Güncelle";
            }


        }

        private void CategoryList()
        {
            DropListCategoryName.DataSource = _dbContext.Categories.Select(x => new
            {
                x.CategoryID,
                x.CategoryName
            }).ToList();
            DropListCategoryName.DataValueField = "CategoryID";
            DropListCategoryName.DataTextField = "CategoryName";
            DropListCategoryName.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            _product.ProductName = txtProductName.Text;
            _product.QuantityPerUnit = txtQuantityPerUnit.Text;
            _product.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            _product.UnitsInStock = Int16.Parse(txtUnitsInStock.Text);
            _product.CategoryID = int.Parse(DropListCategoryName.SelectedValue);


            if (_product.ProductID == 0)
            {
                //YENİ KAYIT
                _dbContext.Products.Add(_product);
            }
            //else
            //{

            //}

            _dbContext.SaveChanges();

            Response.Redirect("ProductListForm.aspx");
        }
    }
}