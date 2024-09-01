using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using LMS_v1.MiddleWares;
using System.Text;

namespace LMS_v1.Views.Admin
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        private SqlConnection con=new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAuth ca = new CheckAuth();
                ca.AuthicatorAdmin();
            }
        }
        protected void LoadUser()
        {
            try
            {
                con.Open();
                SqlCommand cmd= new SqlCommand("SELECT users.id,users.username,users.email,users.fullname,users.phone,users.role_id,users.image,users.last_active,users.plan_id,users.status,subscriptions.booklimit,subscriptions.id as subscriptionID,subscriptions.expires_at,subscriptions.isUnlimited FROM users join subscriptions on users.id=subscriptions.user_id ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TableRow row = new TableRow();
                        TableCell cell1 = new TableCell();
                        cell1.Text = dr["id"].ToString();
                        row.Cells.Add(cell1);
                        TableCell cell2 = new TableCell();
                        cell2.Text = dr["username"].ToString();
                        row.Cells.Add(cell2);
                        TableCell cell3 = new TableCell();
                        cell3.Text = dr["fullname"].ToString();
                        row.Cells.Add(cell3);
                        TableCell cell4 = new TableCell();
                        cell4.Text = dr["email"].ToString();
                        row.Cells.Add(cell4);
                        TableCell cell5 = new TableCell();
                        cell5.Text = dr["phone"].ToString();
                        row.Cells.Add(cell5);
                        TableCell cell6 = new TableCell();
                        cell6.Text = dr["status"].ToString();
                        row.Cells.Add(cell6);
                        TableCell cell7 = new TableCell();
                        cell7.Text = dr["plan_id"].ToString();
                        row.Cells.Add(cell7);
                        DateTime expdate = Convert.ToDateTime(dr["expires_at"]);
                        TableCell cell8 = new TableCell();
                        cell8.Text = expdate.Day + "/"+ expdate.Month + "/" +expdate.Year;
                        row.Cells.Add(cell8);
                        DateTime lastUpdate = Convert.ToDateTime(dr["last_active"]);
                        TableCell cell9 = new TableCell();
                        cell9.Text = lastUpdate.Day + "/" + lastUpdate.Month + "/" + lastUpdate.Year;
                        row.Cells.Add(cell9);
                        TableCell cell10 = new TableCell();
                        cell10.Text = $"<a href='~/admin/suspendUser/{dr["id"]}' class='btn btn-primary'>Upgrade</a>";
                        row.Cells.Add(cell10);
                        TableCell cell11 = new TableCell();
                        cell11.Text= "<a href='~/admin/deleteUser/" + dr["id"] + "' class='btn btn-danger'>Delete</a>";
                        row.Cells.Add(cell11);
                        userTable.Rows.Add(row);
                    }
                }
            }
            catch(Exception ex)
            {
                ShowAlert(ex.Message);
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