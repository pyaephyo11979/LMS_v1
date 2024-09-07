using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS_v1.MiddleWares;
namespace LMS_v1.Views.Admin
{
    public partial class StaticsPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        public int totalBooks = 0;
        public int totalUsers = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CheckAuth checkAuth = new CheckAuth();
                checkAuth.AuthicatorAdmin();
                GetStatics();
                DisplayBooks();
            }

        }
        protected void GetStatics()
        {
            try
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Books";
                SqlCommand cmd = new SqlCommand(query, con);
                totalBooks = (int)cmd.ExecuteScalar();
                query = "Select count(*) from users where role_id=1 and status=1";
                cmd = new SqlCommand(query, con);
                totalUsers = (int)cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        protected void DisplayBooks()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select books.id,name,author,image,category_name from books,categories where books.category_id=categories.id order by books.created_at desc", con);
                SqlDataReader reader = cmd.ExecuteReader();
                StringBuilder bookCard = new StringBuilder();
                bookDisplay.InnerHtml = "";
                while (reader.Read())
                {
                    string id = reader["id"].ToString();
                    string name = reader["name"].ToString();
                    string imageurl = reader["image"].ToString();
                    string author = reader["author"].ToString();
                    string categoryName = reader["category_name"].ToString();
                    bookCard.Append($@"
                         <div class='card col-3 m-2' style='max-length:200px;'>
                         <img src='/uploads/bookCovers/{imageurl}' class='card-img-top'  alt='{name}' />
                         <div class='card-body'>
                         <h5 class='card-title'>{name}</h5>
                            <p class='card-text'>{author}</p>
                            <p class='card-text'>{categoryName}</p>
                            <a href='editbook\{id}' class='d-inline btn btn-info'>Edit Book</a>
                         </div>
                        </div>
                        ");
                    bookDisplay.InnerHtml = bookCard.ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}