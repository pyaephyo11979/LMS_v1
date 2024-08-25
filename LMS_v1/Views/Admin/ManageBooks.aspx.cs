using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using LMS_v1.MiddleWares;
namespace LMS_v1.Views.Admin
{
    public partial class ManageBooks : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        private SqlDataAdapter da;
        private DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAuth ca = new CheckAuth();
                ca.AuthicatorAdmin();
            }
        }
    }
}