using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS_v1.Models;
namespace LMS_v1.Views
{
    public partial class Register : System.Web.UI.Page
    {
        private SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        protected void connect()
        {
            try { cn.Open(); } catch (Exception ex) { Response.Write(ex.Message); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            connect();
        }
        protected void SignUp(object sender,EventArgs e)
        {
            SqlCommand cmd=new SqlCommand("insert into users(username,email,fullname,password) values(@username,@email,@fullname,@password)",cn);
            try
            {
                cmd.Parameters.AddWithValue("username", txtUserName.Text);
                cmd.Parameters.AddWithValue("email", txtEmail.Text);
                cmd.Parameters.AddWithValue("fullname", txtName.Text);
                cmd.Parameters.AddWithValue("password", txtPsw.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                Response.Redirect("~/login");
            }
            catch (Exception ex) { Response.Write(ex.Message); }
        }
    }
}