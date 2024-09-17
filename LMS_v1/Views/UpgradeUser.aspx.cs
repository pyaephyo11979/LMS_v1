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
        private string pid = "";
        private string uid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAuth checkAuth = new CheckAuth();
                checkAuth.Authicate();
            }
            var user = (LMS_v1.Models.User)Session["user"];
             pid = Page.RouteData.Values["pid"] as string;
            uid = Convert.ToString(user.uid);
        }
        protected void Upgrade(object sender,EventArgs e)
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
                user.isUnlimited = isUnlimited;
                user.expdate = DateTime.Now.AddMonths(1);
                ShowAlert("Upgraded Subscription Successfully !");
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