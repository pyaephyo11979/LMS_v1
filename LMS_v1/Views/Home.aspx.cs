using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LMS_v1.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        protected SqlDataAdapter da;
        protected DataSet ds;
        protected void connec()
        {
            try
            {
                cn.Open();
            }catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void Display()
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select top 5 books.id,name,author,description,image,category_name from books join categories on books.category_id=categories.id order by books.created_at desc;", cn);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                StringBuilder bookCard = new StringBuilder();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                rptltBooks.DataSource= dt;
                rptltBooks.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally {                 cn.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
        }

    }
}