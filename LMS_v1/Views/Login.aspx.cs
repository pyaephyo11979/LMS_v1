using System;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;
using LMS_v1.Models;
using System.Security.Cryptography;

namespace LMS_v1.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);

        protected void connect()
        {
            try
            {
                if (cn.State == System.Data.ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Database connection error: {ex.Message}');</script>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                connect();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPsw.Text.Trim();

            if (ValidateUser(email, password))
            {
                User user = getUserDetail(email);
                Session["user"] = user;

                if (user != null && user.role == "2") 
                {
                    Response.Redirect("~/admin/dashboard");
                }
                else
                {
                    Response.Redirect("~/");
                }
            }
            else
            {
                ShowAlert("Invalid Email or Password");
            }
        }

        protected User getUserDetail(string email)
        {
            User user = null;
            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE email=@Email", cn);
                cmd.Parameters.AddWithValue("@Email", email);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    user = new User
                    {
                        uid = Convert.ToInt32(rd["id"]),
                        username = rd["username"].ToString(),
                        email = rd["email"].ToString(),
                        fullname = rd["fullname"].ToString(),
                        phone = rd["phone"].ToString(),
                        role = rd["role_id"].ToString(),
                        planID = rd["plan_id"].ToString(),
                        profileUrl = rd["image"].ToString(),
                        status = rd["status"].ToString(),
                    };
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error retrieving user details: {ex.Message}');</script>");
            }
            finally
            {
                cn.Close();
            }

            return user;
        }

        private bool ValidateUser(string email, string password)
        {
            bool isValid = false;

            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("SELECT password FROM users WHERE email=@Email", cn);
                cmd.Parameters.AddWithValue("@Email", email);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedHashedPassword = reader["password"].ToString();
                    string enteredHashedPassword = HashPassword(password);

                    if (storedHashedPassword == enteredHashedPassword)
                    {
                        isValid = true;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error validating user: {ex.Message}');</script>");
            }
            finally
            {
                cn.Close();
            }

            return isValid;
        }

        private string HashPassword(string password)
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

        private void ShowAlert(string message)
        {
            StringBuilder alertScript = new StringBuilder();
            alertScript.Append("<script type='text/javascript'>" +
                $"alert('{message}');" +
                "</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", alertScript.ToString());
        }
    }
}
