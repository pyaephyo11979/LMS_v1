using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS_v1.MiddleWares;
namespace LMS_v1.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        private SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        public int bookLimit = 0;
        protected void Connect()
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAuth checkAuth = new CheckAuth();
                checkAuth.Authicate();
            }
            var user= (LMS_v1.Models.User)Session["user"];
            bookLimit = user.bookLimit;

        }
        protected void UpdateProfile(object sender, EventArgs e)
        {
            try
            {
                Connect();
                var user = (LMS_v1.Models.User)Session["user"];
                string query = "UPDATE Users SET image = @image WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@image", fileProfile.FileName);
                cmd.Parameters.AddWithValue("@id", user.uid);
                string path = Server.MapPath("~/uploads/profiles/") + fileProfile.FileName;
                fileProfile.PostedFile.SaveAs(path);
                cmd.ExecuteNonQuery();
                user.profileUrl = fileProfile.FileName;
                Response.Redirect("profile");
            }
            catch (Exception ex) {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        protected void ChangeProfile(object sender, EventArgs e)
        {
            try
            {
                Connect();
                var user = (LMS_v1.Models.User)Session["user"];
                string query = "UPDATE Users SET image = @image WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@image", filePP.FileName);
                cmd.Parameters.AddWithValue("@id", user.uid);
                string path = Server.MapPath("~/uploads/profiles/") + filePP.FileName;
                fileProfile.PostedFile.SaveAs(path);
                cmd.ExecuteNonQuery();
                user.profileUrl = filePP.FileName;
                Response.Redirect("profile");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        protected void AddPhone(object sender,EventArgs e) {
            try
            {
                Connect();
                var user = (LMS_v1.Models.User)Session["user"];
                string query = "UPDATE Users SET phone = @phone WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@id", user.uid);
                cmd.ExecuteNonQuery();
                user.phone = txtPhone.Text;
                Response.Redirect("profile");
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void ChangePsw(object sender,EventArgs e)
        {
            string oldPsw = txtOldPassword.Text;
            string newPsw = txtNewPassword.Text;
            string confirmPsw = txtConfirmPassword.Text;
            var user = (LMS_v1.Models.User)Session["user"];
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from users where id=@id", conn);
                cmd.Parameters.AddWithValue("id", user.uid);
                string psw = "";
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    psw = rd["password"].ToString();
                }
                rd.Close();
                if (DecodePsw(oldPsw) == psw)
                {
                    if (newPsw == confirmPsw)
                    {
                        string query = "UPDATE Users SET password = @password WHERE Id = @Id";
                        SqlCommand cmd2 = new SqlCommand(query, conn);
                        cmd2.Parameters.AddWithValue("@password", DecodePsw(newPsw));
                        cmd2.Parameters.AddWithValue("@id", user.uid);
                        cmd2.ExecuteNonQuery();
                        Response.Redirect("profile");
                    }
                    else
                    {
                        lblError.Text="Password does not match";
                    }
                }
                else
                {
                    lblError.Text="Old password is incorrect";
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private string DecodePsw(string password)
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