using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS_v1.MiddleWares;
using System.Data.SqlClient;
namespace LMS_v1.Views
{
    public partial class BookDetail : System.Web.UI.Page
    {
        private SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        private string title;
        private string description;
        private string author;
        private string category;
        private string image;
        private string BookFile;
        private string bookID;
        private void SearchBook(string bID)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select name,description,author,image,category_name from books,categories where books.id=@id and books.category_id=categories.id", conn);
                cmd.Parameters.AddWithValue("@id", bID);
                SqlDataReader rd= cmd.ExecuteReader();
                while (rd.Read())
                {
                    title = rd["name"].ToString();
                    description = rd["description"].ToString();
                    author = rd["author"].ToString();
                    category = rd["category_name"].ToString();
                    image = rd["image"].ToString();
                    lblTitle.Text = title;
                    lblDescription.Text = description;
                    lblAuthor.Text = author;
                    lblCategory.Text = category;
                    BookFile = "/uploads/bookFiles/" + rd["file"].ToString();
                    imgBookCover.ImageUrl = "/uploads/bookCovers/" + image;

                }
                rd.Close();
            }catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAuth checkAuth = new CheckAuth();
                checkAuth.Authicate();
            }
            bookID = Page.RouteData.Values["id"] as string;
            SearchBook(bookID);
        }

    }
}