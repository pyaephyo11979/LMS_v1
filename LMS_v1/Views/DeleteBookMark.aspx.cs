using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using LMS_v1.MiddleWares;

namespace LMS_v1.Views
{
    public partial class DeleteBookMark : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAuth ca = new CheckAuth();
                ca.Authicate();
            }
            string bid = Page.RouteData.Values["bid"] as string;
            var user=(LMS_v1.Models.User)Session["user"];
            string uid = user.uid.ToString();
            DeleteBM(bid, uid);
        }
        protected void DeleteBM(string bid,string uid)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from bookMarks where id=@bid and user_id=@uid", con);
                cmd.Parameters.AddWithValue("@bid", bid);
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("~/bookmarks");
            }catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}