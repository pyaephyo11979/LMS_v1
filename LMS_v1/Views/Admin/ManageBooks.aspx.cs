using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using LMS_v1.MiddleWares;
using System.Text;
namespace LMS_v1.Views.Admin
{
    public partial class ManageBooks : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        private SqlDataAdapter da;
        private DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAuth ca = new CheckAuth();
                ca.AuthicatorAdmin();
                Load_and_Display();
            }

        }
        protected void Load_and_Display()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select books.id,books.name,author,image,categories.category_name as category from books,categories where books.category_id=categories.id order by books.created_at desc", con);
                StringBuilder bookRow = new StringBuilder();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string bid = rd["id"].ToString();
                    string bname = rd["name"].ToString();
                    string bauthor = rd["author"].ToString();
                    string bimage = rd["image"].ToString();
                    string bcategory = rd["category"].ToString();
                    TableRow TR = new TableRow();
                    TableCell cellImage = new TableCell();
                    cellImage.Text = $"<img src='/uploads/bookCovers/{bimage}' width='80px' height='100' />";
                    TR.Cells.Add(cellImage);
                    TableCell cellName = new TableCell();
                    cellName.Text = bname;
                    TR.Cells.Add(cellName);
                    TableCell cellAuthor = new TableCell();
                    cellAuthor.Text = bauthor;
                    TR.Cells.Add(cellAuthor);
                    TableCell cellCategory = new TableCell();
                    cellCategory.Text = bcategory;
                    TR.Cells.Add(cellCategory);
                    TableCell cellActions = new TableCell();
                    cellActions.Text = $"<a href='editbook/{bid}' runat='server' class='btn btn-primary'>Edit</a> " +
                                       $"<a href='deletebook/{bid}' runat='server' class='btn btn-danger'>Delete <i class='fas fa-trash'></i></a>";
                    TR.Cells.Add(cellActions);
                    bookTable.Rows.Add(TR);
                }
                rd.Close();
            }
            catch(Exception ex)
            {
                Response.Write($"<script>window.alert('{ex.Message}');</script>");
            }
            finally
            {
                con.Close();
            }
        }
        protected void searchBook(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select books.id,name,author,image,categories.category_name as category from books,categories where books.category_id=categories.id and name like @name order by books.created_at desc", con);
                cmd.Parameters.AddWithValue("@name", "%" + txtSearch.Text + "%");
                StringBuilder bookRow = new StringBuilder();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string bid = rd["id"].ToString();
                    string bname = rd["name"].ToString();
                    string bauthor = rd["author"].ToString();
                    string bimage = rd["image"].ToString();
                    string bcategory = rd["category"].ToString();
                    TableRow TR = new TableRow();
                    TableCell cellImage = new TableCell();
                    cellImage.Text = $"<img src='/uploads/bookCovers/{bimage}' width='80px' height='100' />";
                    TR.Cells.Add(cellImage);
                    TableCell cellName = new TableCell();
                    cellName.Text = bname;
                    TR.Cells.Add(cellName);
                    TableCell cellAuthor = new TableCell();
                    cellAuthor.Text = bauthor;
                    TR.Cells.Add(cellAuthor);
                    TableCell cellCategory = new TableCell();
                    cellCategory.Text = bcategory;
                    TR.Cells.Add(cellCategory);
                    TableCell cellActions = new TableCell();
                    cellActions.Text = $"<a href='~/admin/editbook/{bid}' runat='server' class='btn btn-primary'>Edit</a> " +
                                       $"<a href='~/admin/deleteBook/{bid}' runat='server' class='btn btn-danger'>Delete <i class='fas fa-trash'></i></a>";
                    TR.Cells.Add(cellActions);
                    bookTable.Rows.Add(TR);
                }
                rd.Close();
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
    }
}