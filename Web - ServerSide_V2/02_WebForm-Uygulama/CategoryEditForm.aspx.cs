using _02_WebForm_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_WebForm_Uygulama
{
    public partial class CategoryEditForm : System.Web.UI.Page
    {
        NorthwindEntities _dbContext;
        Category _category;

        protected void Page_Load(object sender, EventArgs e)
        {

            //TODO: Görev ataması için todo kullanırız. TaskList'de görünür.
            _dbContext = new NorthwindEntities();

            string categoryIdStr = Request.QueryString["id"];

            //Özel Ternary if kullanımı (null check)
            categoryIdStr = categoryIdStr ?? "0";
            //string deger = categoryIdStr == null ? "0" : categoryIdStr ;

            int categoryId = int.Parse(categoryIdStr);

            if (categoryId == 0)
            {
                //YENİ KAYIT
                _category = new Category();
            }
            else
            {
                //GÜNCELLEME
                _category = _dbContext.Categories.Find(categoryId);

                //#if TEST
                if (!Page.IsPostBack)
                {
                    txtCategoryName.Text = _category.CategoryName;
                    txtDescription.Text = _category.Description;
                }
                //#endif

                btnSave.Text = "Güncelle";

            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Category category = new Category();

            _category.CategoryName = txtCategoryName.Text;
            _category.Description = txtDescription.Text;

            if (_category.CategoryID == 0)
            {
                //YENİ KAYIT
                _dbContext.Categories.Add(_category);
            }
            //else
            //{

            //}

            _dbContext.SaveChanges();

            Response.Redirect("CategoryListForm.aspx");
        }
    }
}