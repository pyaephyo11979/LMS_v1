using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace LMS_v1.Views.Admin
{
    public partial class DeleteBook : System.Web.UI.Page
    {
        private SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string uid = Page.RouteData.Values["id"] as string;
                Delete(uid);
            }
        }
        protected void Delete(string bid)
        {
            try
            {
                conn.Open();
                SqlCommand cmd1= new SqlCommand("select * from books where id=@id", conn);
                cmd1.Parameters.AddWithValue("@id", bid);
                SqlDataReader rd = cmd1.ExecuteReader();
                string bookFile = "";
                string bookImage = "";
                while (rd.Read())
                {
                    bookFile = rd["file"].ToString();
                    bookImage = rd["image"].ToString();
                }
                rd.Close();
                string path = Server.MapPath("~/uploads/bookFiles/") + bookFile;
                string path2 = Server.MapPath("~/uploads/bookCovers") + bookImage;
                System.IO.File.Delete(path);
                System.IO.File.Delete(path2);
                SqlCommand cmd = new SqlCommand("delete from books where id=@id", conn);
                cmd.Parameters.AddWithValue("@id", bid);
                cmd.ExecuteNonQuery();
                Response.Write($"<script>alert('Delete Book Successfully!');</script>");
                Response.Redirect("~/admin/manageBooks");
                conn.Close();
            }catch(Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
        }
    }
}