using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_v1.Views
{
    public class User
    {
        public int uid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }
        public string role { get; set; }
        public string phone { get; set; }
        public string status { get; set; }
    }
    public partial class Login : System.Web.UI.Page
    {
        protected SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            cn.Open();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtEmail.Text;
            string password = txtPsw.Text;
            if(ValidateUser(username, password)== true)
            {
                SqlCommand cmd = new SqlCommand("select*from users where email=@email", cn);
                cmd.Parameters.AddWithValue("email", username);
                SqlDataReader rd=cmd.ExecuteReader();
                User user = new User();
                while (rd.Read())
                {
                    user.uid = Convert.ToInt32(rd["id"]);
                    user.username = rd["username"].ToString();
                    user.email = rd["email"].ToString();
                    user.fullname = rd["fullname"].ToString();
                    user.phone = rd["phone"].ToString();
                    user.role = rd["role_id"].ToString();
                    user.status = rd["status"].ToString();
                }
                HttpCookie ck = new HttpCookie("UserCookie");

            }
        }
        private  bool ValidateUser(string email,string password)
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
                return Hash.Equals(psw, password);
        }
    }
}