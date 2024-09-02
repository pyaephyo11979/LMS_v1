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
                LoadUser();
            }
        }
        protected void LoadUser()
        {
            try
            {
                con.Open();
                SqlCommand cmd= new SqlCommand("SELECT users.id,users.username,users.email,users.fullname,users.phone,users.role_id,users.image,users.last_active,users.plan_id,users.status,subscriptions.booklimit,subscriptions.id as subscriptionID,subscriptions.expires_at,subscriptions.isUnlimited FROM users join subscriptions on users.id=subscriptions.user_id where users.role_id=1", con);
                SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                    TableRow row = new TableRow();

                    row.Cells.Add(new TableCell { Text = dr["id"].ToString() });
                    row.Cells.Add(new TableCell { Text = dr["username"].ToString() });
                    row.Cells.Add(new TableCell { Text = dr["fullname"].ToString() });
                    row.Cells.Add(new TableCell { Text = dr["email"].ToString() });
                    row.Cells.Add(new TableCell { Text = dr["phone"].ToString() });
                    row.Cells.Add(new TableCell { Text = dr["status"].ToString() });
                    row.Cells.Add(new TableCell { Text = dr["plan_id"].ToString() });
                    DateTime expdate = Convert.ToDateTime(dr["expires_at"]);
                    row.Cells.Add(new TableCell { Text = expdate.ToString("dd/MM/yyyy") });
                    DateTime lastUpdate = Convert.ToDateTime(dr["last_active"]);
                    row.Cells.Add(new TableCell { Text = lastUpdate.ToString("dd/MM/yyyy") });
                    TableCell cell10 = new TableCell();
                    cell10.Controls.Add(new LiteralControl($"<a href='~/admin/suspendUser/{dr["id"]}' class='btn btn-primary'>Upgrade</a>"));
                    row.Cells.Add(cell10);
                    TableCell cell11 = new TableCell();
                    cell11.Controls.Add(new LiteralControl($"<a href='~/admin/deleteUser/{dr["id"]}' class='btn btn-danger'>Delete</a>"));
                    row.Cells.Add(cell11);
                    userTable.Rows.Add(row);
                }
                dr.Close();
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