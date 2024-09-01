using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS_v1.MiddleWares;
using System.Data.SqlClient;
using System.IO;
using System.Text;
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
                SqlCommand cmd = new SqlCommand("select name,description,author,books.[file],image,category_name from books,categories where books.id=@id and books.category_id=categories.id", conn);
                cmd.Parameters.AddWithValue("@id", bID);
                SqlDataReader rd= cmd.ExecuteReader();
                while (rd.Read())
                {
                    title = rd["name"].ToString();
                    description = rd["description"].ToString();
                    author = rd["author"].ToString();
                    category = rd["category_name"].ToString();
                    image = rd["image"].ToString();
                    BookFile = rd["file"].ToString();
                    lblTitle.Text = title;
                    lblDescription.Text = description;
                    lblAuthor.Text = author;
                    lblCategory.Text = category;
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
        protected void DownloadFile(object sender,EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd1= new  SqlCommand ("select [file] from books where id=@id", conn);
                cmd1.Parameters.AddWithValue("@id", bookID);
                SqlDataReader rd = cmd1.ExecuteReader();
                string file = "";
                while (rd.Read())
                {
                    file = rd["file"].ToString();
                }
                rd.Close();
                string path=(Server.MapPath("~/uploads/bookFiles/") + file);
                FileInfo fl = new FileInfo(path);
                if (fl.Exists)
                {
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file);
                    Response.AddHeader("Content-Length", fl.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.Flush();
                    Response.TransmitFile(fl.FullName);
                    Response.End();
                    var user = (LMS_v1.Models.User)Session["user"];
                   int  bookLimit = user.bookLimit;
                    int limit = bookLimit - 1;
                    SqlCommand cmd = new SqlCommand("update subscriptions set bookLimit=@limit where user_id=@uid", conn);
                    cmd.Parameters.AddWithValue("@uid", user.uid);
                    cmd.Parameters.AddWithValue ("@limit", limit);
                    cmd.ExecuteNonQuery();
                    user.bookLimit = limit;
                }
                else
                {
                    ShowAlert("Error 404: File not found!!");
                }

            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
        private void ShowAlert(string message)
        {
            StringBuilder alertScript = new StringBuilder();
            alertScript.Append("<script type='text/javascript'>" +
                $"alert('{message}');" +
                "</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", alertScript.ToString());
        }
    }
}