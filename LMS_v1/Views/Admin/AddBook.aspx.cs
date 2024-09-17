using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS_v1.MiddleWares;
namespace LMS_v1.Views.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private SqlConnection conn=new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        private SqlDataAdapter da;
        protected void connect_and_load()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from categories", conn);
                da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        ddlCategory.Items.Add(new ListItem(row["category_name"].ToString(), row["id"].ToString()));
                    }
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAuth checkAuth = new CheckAuth();
                checkAuth.AuthicatorAdmin();
            }
            connect_and_load();
        }
        protected void Add(object sender, EventArgs e)
        {
            try
            {
                string name = txtBookName.Text;
                string author = txtAuthorName.Text;
                string description = txtBookDescription.Text;
                string category_id = ddlCategory.SelectedValue;
                string image = fuBookCover.FileName;
                string path = Server.MapPath("~/uploads/bookCovers/") + image;
                string path2 = Server.MapPath("~/uploads/bookFiles/") + fuBookFile.FileName;
                fuBookCover.PostedFile.SaveAs(path);
                fuBookFile.PostedFile.SaveAs(path2);
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into books(name,author,description,category_id,image,[file]) values(@name,@author,@description,@category_id,@image,@file)", conn);
                cmd.Parameters.AddWithValue("@name",  name);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@category_id", category_id);
                cmd.Parameters.AddWithValue("@image", image);
                cmd.Parameters.AddWithValue("@file", fuBookFile.FileName);
                cmd.ExecuteNonQuery();
                Response.Redirect("~/admin/manageBooks");
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
    }
}