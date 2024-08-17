using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Css.Ast.Selectors;
using System.Configuration;
using LMS_v1.Models;

namespace LMS_v1.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        protected void connect()
        {
            try
            {
                cn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            connect();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string email = txtEmail.Text;
            string password = txtPsw.Text;
            ValidateUser(email, password);
        }
        protected User  getUserDetail(string email)
        {
                SqlCommand cmd = new SqlCommand("select*from users where email=@email", cn);
                cmd.Parameters.AddWithValue("email", email);
                SqlDataReader rd = cmd.ExecuteReader();
                User user = null;
                while (rd.Read())
                {
                    user = new User
                    {
                        uid = Convert.ToInt32(rd["id"]),
                        username = rd["username"].ToString(),
                        email = rd["email"].ToString(),
                        fullname = rd["fullname"].ToString(),
                        phone = rd["phone"].ToString(),
                        role = rd["role_id"].ToString(),
                        status = rd["status"].ToString(),
                    };
                }
            rd.Close();
                return user;
        }
        private void ValidateUser(string email, string password)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from users where email=@email", cn);
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataReader reader = cmd.ExecuteReader();
                string psw = "";
                while (reader.Read())
                {
                    psw += reader["password"].ToString();
                }
                reader.Close();
                if (password == psw)
                {
                    User user = getUserDetail(email);
                    Session["user"] = user;
                    Response.Redirect("~/");
                    getUserDetail(email);
                    cn.Close();
                }
                else
                {
                    cn.Close();
                    Response.Redirect("~/login");
                    StringBuilder alertB = new StringBuilder();
                    alertB.Append("<script type='text/javascript'>" +
                        "window.onload=function(){" +
                        "alert('Invaild Email or Password');</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", alertB.ToString());
                }

            }catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}