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
                Console.WriteLine(ex.Message);
            }
        }
        protected void Display()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select books.id,name,description,author,category_name from books,categories where books.category_id=categories.id;", cn);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                StringBuilder bookCard = new StringBuilder();
                da.Fill(ds);
                DataTable dt = ds.Tables["books"];
                if (dt.Rows != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string name = row["name"].ToString();
                        string imageurl = $"~/bookCovers/{row["image"].ToString()}";
                        bookCard.Append($@"
                 <div class='col-md-4 col-lg-3 col-sm-6 m-2'>
                 <div class='card '>
                 <img src='{imageurl}' class='card-img-top' alt='{name} />
                 <div class='card-body>
                 <h5 class='crd-title'>{name}</h5>
                 </div>
                   </div>
                ");
                        bookdisplay.InnerHtml += bookCard.ToString();
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            connec();
            Display();
        }

    }
}