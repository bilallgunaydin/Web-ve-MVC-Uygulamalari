using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _01_WebForms_Intro
{
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int random = new Random().Next(200);
            //result.InnerText = random.ToString();
            //for (int i = 10; i>-1; i--)
            //{
            //    result.InnerText = i.ToString();
            //}

            if (!Page.IsPostBack)
                FillCategories(categoryList);


        }

        private void FillCategories(HtmlSelect selectElement)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=BILALL\\SQLEXPRESS;database=Northwind; integrated security=sspi";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select categoryName from Categories";

            cmd.Connection.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                selectElement.Items.Add(rdr.GetString(0));
            }

            cmd.Connection.Close();
        }
        public int rndCount = 0;

        public string GetProductsHTML(int small, int large)
        {
            string htmlString = "";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=BILALL\\SQLEXPRESS;database=Northwind; integrated security=sspi";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"select ProductName, UnitsInStock from products where UnitsInStock between @p1 and @p2 ";

            cmd.Parameters.AddWithValue("@p1", small);
            cmd.Parameters.AddWithValue("@p2", large);


            cmd.Connection.Open();

            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                htmlString += string.Format("{0} ({1}) <br />", rd.GetString(0), rd.GetInt16(1).ToString());
            }
            cmd.Connection.Close();


            return htmlString;

        }

        private string GetProductsHTMLWithCategory(int small, int large, string categoryName)
        {
            string htmlstring = "";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=BILALL\\SQLEXPRESS;database=Northwind; integrated security=sspi";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"select productName, UnitsInStock, CategoryName from products p 
                            join categories c on p.CategoryId=c.CategoryId 
                            where categoryName=@categoryName and UnitsInStock BETWEEN @p1 AND @p2";

            cmd.Parameters.AddWithValue("@p1", small);
            cmd.Parameters.AddWithValue("@p2", large);
            cmd.Parameters.AddWithValue("@categoryName", categoryName);

            cmd.Connection.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                htmlstring += string.Format("{0} ({1}) ({2}) <br />"
                     , rdr.GetString(0)             
                    , rdr.GetInt16(1).ToString()    
                    , rdr.GetString(2));   
            }

            cmd.Connection.Close();

            return htmlstring;
        }
        public void btnRunClick(object sender, EventArgs e)
        {
            //int random = new Random().Next(10);
            //result.InnerText = random.ToString();

            //string firstNumberStr = firstNumber.Value;
            //string secondNumberStr = secondNumber.Value;

            //int fNum = int.Parse(firstNumberStr);
            //int sNum = int.Parse(secondNumberStr);

            //int random = new Random().Next(
            //    fNum > sNum ? sNum : fNum,
            //    fNum > sNum ? fNum : sNum
            //    );
            //result.InnerText = random.ToString();

            //string firstNumberStr = firstNumber.Value;
            //string secondNumberStr = secondNumber.Value;

            //int fNum = int.Parse(firstNumberStr);
            //int sNum = int.Parse(secondNumberStr);


            //int random = new Random().Next(
            // fNum > sNum ? sNum : fNum,
            //fNum > sNum ? fNum : sNum
            //);

            //newResult.InnerText = random.ToString();
            //rndCount++;
            //count.InnerText = rndCount.ToString();


            //int fNum = int.Parse(firstNumber.Value);
            //int sNum = int.Parse(secondNumber.Value);
            //string productListHTML = GetProductsHTML(
            //    fNum > sNum ? sNum : fNum,
            //    fNum > sNum ? fNum : sNum
            //    );

            //result.InnerHtml = productListHTML;



            int fNum = int.Parse(firstNumber.Value);
            int sNum = int.Parse(secondNumber.Value);
            string categoryname = categoryList.Items[categoryList.SelectedIndex].Value;

            string productListHtml = GetProductsHTMLWithCategory(
                fNum > sNum ? sNum : fNum,
                fNum > sNum ? fNum : sNum,
                categoryname);

            result.InnerText = productListHtml;

        }
    }
}