using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS_v1.MiddleWares;

namespace LMS_v1.Views
{
    public partial class BookMarks : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        protected void LoadBook()
        {
            try
            {
                var user=(LMS_v1.Models.User)Session["user"];
                SqlCommand cmd=new SqlCommand("select books.id,books.name,books.author,books.[file],books.description,books.image,bookmarks.id as bookmark_id,categories.category_name as category from books  join bookmarks on books.id=bookmarks.book_id join categories on books.category_id=categories.id where bookmarks.user_id=@user_id", con);
                cmd.Parameters.AddWithValue("@user_id", user.uid.ToString());
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    TableRow row= new TableRow();
                    TableCell cell = new TableCell();
                    cell.Controls.Add(new LiteralControl($"<img src='/uploads/bookCovers/{dr["image"]}' alt='book image' class='img-thumbnail' style='width:100px;height:100px;' />"));
                    row.Cells.Add(cell);
                    row.Cells.Add(new TableCell { Text = dr["name"].ToString() });
                    row.Cells.Add(new TableCell { Text = dr["author"].ToString() });
                    row.Cells.Add(new TableCell { Text = dr["category"].ToString() });
                    TableCell cell1 = new TableCell();
                    cell1.Controls.Add(new LiteralControl($"<a runat='server' href='book/{dr["id"]}' class='btn btn-primary'>View Book <i class='fas fa-book-open'></i></a>"));
                    row.Cells.Add(cell1);
                    TableCell cell2 = new TableCell();
                    cell2.Controls.Add(new LiteralControl($"<a runat='server' href='removebookmark/{dr["bookmark_id"]}' class='btn btn-danger'>Remove</a>"));
                    row.Cells.Add(cell2);
                    tbBookMarks.Rows.Add(row);
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAuth ca = new CheckAuth();
                ca.Authicate();
                LoadBook();
            }
        }
    }
}