using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_v1.Views
{
    public partial class Books : System.Web.UI.Page
    {
        private int bookLimit;
        private SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        protected void connect()
        {
            try
            {
                conn.Open();
            } catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void LoadCategory()
        {
            try
            {

                SqlCommand cmd= new SqlCommand("select * from categories", conn);
                SqlDataReader rd = cmd.ExecuteReader();
                ddlcategory.Items.Add(new ListItem("ChooseCategory", "0"));
                if (rd != null) {
                    while (rd.Read())
                    {
                        ListItem item = new ListItem(rd["category_name"].ToString(), rd["id"].ToString());
                        ddlcategory.Items.Add(item);
                    }
                }
                rd.Close();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void LoadAuthor()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select distinct author from books", conn);
                SqlDataReader rd = cmd.ExecuteReader();
                ddlauthor.Items.Add(new ListItem("ChooseAuthor", "null"));
                if (rd != null)
                {
                    while (rd.Read())
                    {
                        ListItem item = new ListItem(rd["author"].ToString());
                        ddlauthor.Items.Add(item);
                    }
                }
                rd.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void DisplayBooks()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select books.id,name,author,image,category_name from books,categories where books.category_id=categories.id", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                StringBuilder bookCard = new StringBuilder();
                bookDisplay.InnerHtml = "";
                while (reader.Read())
                {
                    string id = reader["id"].ToString();
                    string name = reader["name"].ToString();
                    string imageurl = reader["image"].ToString();
                    string author = reader["author"].ToString();
                    string categoryName = reader["category_name"].ToString();
                    bookCard.Append($@"
                         <div class='card col-3 m-2'>
                         <img src='/uploads/bookCovers/{imageurl}' class='card-img-top'  alt='{name}' />
                         <div class='card-body'>
                         <h5 class='card-title'>{name}</h5>
                            <p class='card-text'>{author}</p>
                            <p class='card-text'>{categoryName}</p>
                            <a href='book\{id}' class='d-inline text-decoration-none text-secondary'>See More..</a>
                         </div>
                        </div>
                        ");
                    bookDisplay.InnerHtml = bookCard.ToString();
                }
                reader.Close();
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
                connect();
                LoadCategory();
                LoadAuthor();
                DisplayBooks();
            }

        }
        protected void filter(object sender,EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da;
                DataSet ds;
                StringBuilder bookCard = new StringBuilder();
                bookDisplay.InnerHtml = "";
                connect();
                if (ddlcategory.SelectedIndex > 0 && ddlauthor.SelectedIndex > 0)
                {
                    cmd.CommandText = "SELECT books.id, name, author, image, category_name FROM books JOIN categories ON books.category_id = categories.id WHERE books.category_id = @categoryID AND books.author = @Author";
                    cmd.Parameters.AddWithValue("@categoryID", ddlcategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@Author", ddlauthor.SelectedValue);
                }
                else if (ddlcategory.SelectedIndex > 0)
                {
                    cmd.CommandText = "SELECT books.id, name, author, image, category_name FROM books JOIN categories ON books.category_id = categories.id WHERE books.category_id = @categoryID";
                    cmd.Parameters.AddWithValue("@categoryID", ddlcategory.SelectedValue);
                }
                else if (ddlauthor.SelectedIndex > 0)
                {
                    cmd.CommandText = "SELECT books.id, name, author, image, category_name FROM books JOIN categories ON books.category_id = categories.id WHERE books.author = @Author";
                    cmd.Parameters.AddWithValue("@Author", ddlauthor.SelectedValue);
                }
                cmd.Connection = conn;
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        string id = row["id"].ToString();
                        string name = row["name"].ToString();
                        string imageurl = row["image"].ToString();
                        string author = row["author"].ToString();
                        string categoryName = row["category_name"].ToString();

                        bookCard.Append($@"
                         <div class='card col-3 m-2'>
                         <img src='/uploads/bookCovers/{imageurl}' class='card-img-top' alt='{name}' />
                         <div class='card-body'>
                         <h5 class='card-title'>{name}</h5>
                            <p class='card-text'>{author}</p>
                            <p class='card-text'>{categoryName}</p>
                            <a href='book/{id}' class='d-inline text-decoration-none text-secondary'>See More..</a>
                         </div>
                        </div>
                        ");
                        bookDisplay.InnerHtml += bookCard.ToString();
                    }
                }
                else
                {
                    bookDisplay.InnerHtml = "<h4>No Matched Books </h4>";
                }
                ddlcategory.SelectedIndex = 0;
                ddlauthor.SelectedIndex = 0;
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
        protected void search(object sender,EventArgs e)
        {
            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("SELECT books.id,name,author,image,category_name FROM books,categories WHERE books.name LIKE @SearchTerm OR books.author LIKE @SearchTerm and books.category_id=categories.id", conn);
                cmd.Parameters.AddWithValue("@SearchTerm", "%" + txtSearch.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                StringBuilder bookCard = new StringBuilder();
                bookDisplay.InnerHtml = "";
                if (reader.HasRows) {
                    while (reader.Read())
                    {
                        string id = reader["id"].ToString();
                        string name = reader["name"].ToString();
                        string imageurl = reader["image"].ToString();
                        string author = reader["author"].ToString();
                        string categoryName = reader["category_name"].ToString();
                        bookCard.Append($@"
                         <div class='card col-3 m-2'>
                         <img src='/uploads/bookCovers/{imageurl}' class='card-img-top'  alt='{name}' />
                         <div class='card-body'>
                         <h5 class='card-title'>{name}</h5>
                            <p class='card-text'>{author}</p>
                            <p class='card-text'>{categoryName}</p>
                            <a href='book\{id}' class='d-inline text-decoration-none text-secondary'>See More..</a>
                         </div>
                        </div>
                        ");
                        bookDisplay.InnerHtml += bookCard.ToString();
                    }
                }
                else
                {
                    bookDisplay.InnerHtml = "<h4>No Matched Books </h4>";
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                conn.Close();
            }
        }
    }
}