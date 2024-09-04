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
                SqlCommand cmd = new SqlCommand(
                    "SELECT u.id, u.username, u.email, u.fullname, u.phone, u.role_id, u.image, u.last_active, u.plan_id, u.status, " +
                    "s.booklimit, s.id as subscriptionID, s.expires_at, s.isUnlimited " +
                    "FROM users u " +
                    "JOIN subscriptions s ON u.id = s.user_id " +
                    "WHERE u.role_id = 1", con);
                SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                    TableRow row = new TableRow();

                    row.Cells.Add(new TableCell { Text = dr["id"].ToString() });
                    row.Cells.Add(new TableCell { Text = dr["username"].ToString() });
                    row.Cells.Add(new TableCell { Text = dr["fullname"].ToString() });
                    row.Cells.Add(new TableCell { Text = dr["email"].ToString() });
                    string sts = dr["status"].ToString();
                    if (sts == "True")
                    {
                        TableCell csts1 = new TableCell();
                        csts1.Controls.Add(new LiteralControl("<span class=' text-success '>Active</span>"));
                        row.Cells.Add(csts1);
                    }
                    else
                    {
                        TableCell csts1 = new TableCell();
                        csts1.Controls.Add(new LiteralControl("<span class=' text-danger '>Suspended</span>"));
                        row.Cells.Add(csts1);
                    }
                    row.Cells.Add(new TableCell { Text = dr["plan_id"].ToString() });
                    DateTime expdate = Convert.ToDateTime(dr["expires_at"]);
                    row.Cells.Add(new TableCell { Text = expdate.ToString("dd/MM/yyyy") });
                    DateTime lastUpdate = Convert.ToDateTime(dr["last_active"]);
                    row.Cells.Add(new TableCell { Text = TimeHelper.GetTimeAgo(lastUpdate)});
                    TableCell cell10 = new TableCell();
                    cell10.Controls.Add(new LiteralControl($"<a href='~/admin/suspend/{dr["id"]}' class='btn btn-warning'>Suspend</a>"));
                    row.Cells.Add(cell10);
                    TableCell cell11 = new TableCell();
                    cell11.Controls.Add(new LiteralControl($"<a href='~/admin/delete/{dr["id"]}' class='btn btn-danger'>Delete</a>"));
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
        protected void SearchUser(object sender,EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT u.id, u.username, u.email, u.fullname, u.phone, u.role_id, u.image, u.last_active, u.plan_id, u.status, " +
                    "s.booklimit, s.id as subscriptionID, s.expires_at, s.isUnlimited " +
                    "FROM users u " +
                    "JOIN subscriptions s ON u.id = s.user_id " +
                    "WHERE u.role_id = 1 AND (u.fullname LIKE @name OR u.username LIKE @name)", con);
                cmd.Parameters.AddWithValue("@name", "%" + txtSearch.Text + "%");
                for (int i = userTable.Rows.Count - 1; i > 0; i--)
                {
                    userTable.Rows.RemoveAt(i);
                }
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TableRow row = new TableRow();
                        row.Cells.Add(new TableCell { Text = dr["id"].ToString() });
                        row.Cells.Add(new TableCell { Text = dr["username"].ToString() });
                        row.Cells.Add(new TableCell { Text = dr["fullname"].ToString() });
                        row.Cells.Add(new TableCell { Text = dr["email"].ToString() });
                        string sts = dr["status"].ToString();
                        if (sts == "True")
                        {
                            TableCell csts1 = new TableCell();
                            csts1.Controls.Add(new LiteralControl("<span class=' text-success '>Active</span>"));
                            row.Cells.Add(csts1);
                        }
                        else
                        {
                            TableCell csts1 = new TableCell();
                            csts1.Controls.Add(new LiteralControl("<span class=' text-danger '>Suspended</span>"));
                            row.Cells.Add(csts1);
                        }
                        row.Cells.Add(new TableCell { Text = dr["plan_id"].ToString() });
                        DateTime expdate = Convert.ToDateTime(dr["expires_at"]);
                        row.Cells.Add(new TableCell { Text = expdate.ToString("dd/MM/yyyy") });
                        DateTime lastUpdate = Convert.ToDateTime(dr["last_active"]);
                        row.Cells.Add(new TableCell { Text = TimeHelper.GetTimeAgo(lastUpdate) });
                        TableCell cell10 = new TableCell();
                        cell10.Controls.Add(new LiteralControl($"<a href='~/admin/suspend/{dr["id"]}' class='btn btn-primary'>Upgrade</a>"));
                        row.Cells.Add(cell10);
                        TableCell cell11 = new TableCell();
                        cell11.Controls.Add(new LiteralControl($"<a href='~/admin/delete/{dr["id"]}' class='btn btn-danger'>Delete</a>"));
                        row.Cells.Add(cell11);
                        userTable.Rows.Add(row);
                    }
                }
                else
                {
                    TableRow noResultsRow = new TableRow();
                    TableCell noResultsCell = new TableCell
                    {
                        Text = "No users found.",
                        ColumnSpan = userTable.Rows[0].Cells.Count, 
                        HorizontalAlign = HorizontalAlign.Center
                    };
                    noResultsRow.Cells.Add(noResultsCell);
                    userTable.Rows.Add(noResultsRow);
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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