using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            string psw=HashPsw(txtPsw.Text);
            try
            {
                cmd.Parameters.AddWithValue("username", txtUserName.Text);
                cmd.Parameters.AddWithValue("email", txtEmail.Text);
                cmd.Parameters.AddWithValue("fullname", txtName.Text);
                cmd.Parameters.AddWithValue("password", psw);
                cmd.ExecuteNonQuery();
                cn.Close();
                Response.Redirect("~/login");
            }
            catch (Exception ex) { Response.Write(ex.Message); }
        }
        private string HashPsw(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}