﻿using System;
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
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        string id = row["id"].ToString();
                        string name = row["name"].ToString();
                        string imageurl = row["image"].ToString();
                        string description = row["description"].ToString();
                        string author = row["author"].ToString();
                        string categoryName= row["category_name"].ToString();
                        bookCard.Append($@"
                         <div class='card col-2 m-1'>
                         <div class='card-body'>
                        <img src='/uploads/bookCovers/{imageurl}' class='card-img-top'  alt='{name}' />
                         <p class='card-title text-decoration-bold'>{name}</p>
                         </div>
                        </div>
                        ");
                        latestBooks.InnerHtml = bookCard.ToString();
                    }
                }
                else
                {
                    latestBooks.InnerHtml = "";
                    latestBooks.InnerHtml = "<h1>No books available</h1>";
                }
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