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
                SqlCommand cmd= new SqlCommand("select * from users", con);
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
                        cell6.Text = dr["plan_id"].ToString();
                        row.Cells.Add(cell6);
                        TableCell cell7 = new TableCell();
                        cell7.Text = dr["updated_at"].ToString();
                        row.Cells.Add(cell7);
                        TableCell cell8 = new TableCell();
                        cell8.Text = "<a href='edituser.aspx?id=" + dr["id"].ToString() + "'>Edit</a>";
                        row.Cells.Add(cell8);
                        TableCell cell9 = new TableCell();
                        cell9.Text = "<a href='deleteuser.aspx?id=" + dr["id"].ToString() + "'>Delete</a>";
                        row.Cells.Add(cell9);
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