using System;
using System.Collections.Generic;
using System.Data;
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
        public int totalActiveUsers = 0;
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
                totalActiveUsers = (int)cmd.ExecuteScalar();
                query = "Select count(*) from users where role_id=1";
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
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                rptBooks.DataSource = dt;
                rptBooks.DataBind();
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