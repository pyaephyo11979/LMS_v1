using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS_v1.MiddleWares;
using System.Text;

namespace LMS_v1.Views
{
    public partial class UpgradeUser : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        private string planName = "";
        private string planPrice = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAuth checkAuth = new CheckAuth();
                checkAuth.Authicate();
            }
            var user = (LMS_v1.Models.User)Session["user"];
            string pid = Page.RouteData.Values["pid"] as string;
            string usemail=user.email;
            Upgrade(user.uid.ToString(), pid);
        }
        protected void Upgrade(string uid, string pid)
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select*from plans where id=@pid", con);
                cmd1.Parameters.AddWithValue("@pid", pid);
                SqlDataReader rd = cmd1.ExecuteReader();
                string bookLimit="";
                string isUnlimited="";
                while (rd.Read())
                {
                    bookLimit = rd["bookLimit"].ToString();
                    isUnlimited = rd["isUnlimited"].ToString();
                    planName = rd["name"].ToString();
                    planPrice = rd["price"].ToString();
                }
                rd.Close();
                SqlCommand cmd = new SqlCommand("update subscriptions set plan_id=@pid,bookLimit=@bLimit,isUnlimited=@isUnlimited,expires_at=dateadd(month,1,getdate()),updated_at=getdate() where user_id=@uid", con);
                SqlCommand cmd2 = new SqlCommand("update users set plan_id=@pid where id=@id",con);
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.Parameters.AddWithValue("@bLimit", bookLimit);
                cmd.Parameters.AddWithValue("@isUnlimited", isUnlimited);
                cmd2.Parameters.AddWithValue("@pid", pid);
                cmd2.Parameters.AddWithValue("@id", uid);
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                var user= (LMS_v1.Models.User)Session["user"];
                user.planID = pid;
                user.bookLimit= Convert.ToInt32(bookLimit);
                user.isUnlimited = Convert.ToInt32(bookLimit);
                user.expdate = DateTime.Now.AddMonths(1);
                SendEmail();
                Response.Redirect("~/profile");
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
        protected void SendEmail()
        {
            try
            {
                MailService mailService = new MailService();
                StringBuilder mailBody = new StringBuilder();
                var user = (LMS_v1.Models.User)Session["user"];
                mailBody.Append("<!DOCTYPE html>" +
                    "<html>" +
                    "<head>" +
                    "<title>Your Email Title</title>" +
                    "<style type=\"text/css\">" +
                    "body {margin: 0;" +
                    "padding: 0;" +
                    "background-color: #f4f4f4;" +
                    "}table {" +
                    " border-spacing: 0;" +
                    " border-collapse: collapse;" +
                    "width: 100%;" +
                    "}" +
                    "img {" +
                    " display: block;" +
                    "outline: none;" +
                    "border: none;" +
                    " text-decoration: none;" +
                    " }" +
                    "p {" +
                    "margin: 0;" +
                    "padding: 0;" +
                    "}" +
                    " a {" +
                    "text-decoration: none;" +
                    " color: #007bff;" +
                    "}" +
                    "</style>" +
                    "</head>" +
                    "<body style=\"margin: 0; padding: 0; background-color: #f4f4f4;\">" +
                    "<center>" +
                    "<table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"background-color: #ffffff; margin: 20px auto;\">" +
                    " <tr>" +
                    "<td style=\"padding: 20px; text-align: center; background-color: #007bff;\">" +
                    "<h1 style=\"color: #ffffff; font-family: Arial, sans-serif;\">Your Account have been Upgraded!!</h1>" +
                    "</td>" +
                    "</tr>" +
                    " <tr>" +
                    "<td style=\"padding: 20px; font-family: Arial, sans-serif; color: #333333;\">" +
                    $"<p>Dear [{user.fullname.ToString()}],</p>" +
                    $"<p>Thank you for upgrading the {planName} for $ {planPrice} per month .We hope we we will get feedbacks for your experience.</p>" +
                    "<p style=\"margin-top: 20px;\">To get started, click the button below:</p>" +
                    "<table align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"margin-top: 20px;\">" +
                    "<tr>" +
                    " <td align=\"center\" bgcolor=\"#007bff\" style=\"padding: 10px 20px; border-radius: 5px;\">" +
                    "</td>" +
                    "</tr>" +
                    "</table>" +
                    "</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td style=\"padding: 20px; text-align: center; font-family: Arial, sans-serif; color: #999999; background-color: #f4f4f4;\">" +
                    "<p>If you have any questions, feel free to <a href='librarykonoha@gmail'>contact our support team</a>.</p>" +
                    "<p>&copy; 2024 Your Company Name. All rights reserved.</p>" +
                    "</td>" +
                    "</tr>" +
                    "/table>" +
                    "</center>" +
                    "</body>" +
                    "</html>");
                mailService.sendMail(user.email, "Account Upgraded", mailBody.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}