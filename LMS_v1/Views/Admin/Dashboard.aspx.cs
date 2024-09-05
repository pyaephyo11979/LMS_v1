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
    }
}