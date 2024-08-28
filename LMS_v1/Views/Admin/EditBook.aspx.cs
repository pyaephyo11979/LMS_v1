using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using LMS_v1.MiddleWares;
namespace LMS_v1.Views.Admin
{
    public partial class EditBook : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        private string bid;
        protected void Page_Load(object sender, EventArgs e)
        {
             bid = Page.RouteData.Values["id"] as string;
            if (!IsPostBack)
            {
                CheckAuth ca = new CheckAuth();
                ca.AuthicatorAdmin();
                LoadCategories();
                LoadBook(bid);
            }
        }
        protected void LoadCategories()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", con);
                SqlDataReader reader = cmd.ExecuteReader();
                ddlCtg.Items.Add(new ListItem("ChooseCategory", "none"));
                while (reader.Read())
                {
                    ListItem item = new ListItem(reader["category_name"].ToString(), reader["id"].ToString());
                    ddlCtg.Items.Add(item);
                }
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
        protected void LoadBook(string id)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT books.id,name,author,description,image,categories.category_name as category from books join categories on books.category_id=categories.id where books.id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblTitle.Text = reader["name"].ToString();
                    lblAuthor.Text = reader["author"].ToString();
                    lblDescription.Text = reader["description"].ToString();
                    lblCategory.Text = reader["category"].ToString();
                    imgBookCover.Attributes["src"] = "/uploads/bookCovers/" + reader["image"].ToString();
                }
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
        protected void UpdateCover(object sender,EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update table books set image=@image where id=@id");
                cmd.Parameters.AddWithValue("@image", fileImg.FileName);
                cmd.Parameters.AddWithValue("@id", bid);
                string path= Server.MapPath("~/uploads/bookCovers/");
                fileImg.SaveAs(path + fileImg.FileName);
                cmd.ExecuteNonQuery();
                imgBookCover.Attributes["src"] = "/uploads/bookCovers/" +fileImg.FileName.ToString();
            }catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        protected void UpdateTitle(object sender,EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update table books set name=@name where id=@id");
                cmd.Parameters.AddWithValue("@name", txtTitle.Text);
                cmd.Parameters.AddWithValue("@id", bid);
                cmd.ExecuteNonQuery();
                lblTitle.Text = txtTitle.Text;
                txtTitle.Text = "";
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
        protected void UpdateAuthor(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update table books set author=@author where id=@id");
                cmd.Parameters.AddWithValue("@author", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@id", bid);
                cmd.ExecuteNonQuery();
                lblAuthor.Text = txtAuthor.Text;
                txtAuthor.Text = "";
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
        protected void UpdateDescription(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update table books set description=@description where id=@id");
                cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@id", bid);
                cmd.ExecuteNonQuery();
                lblDescription.Text = txtDescription.Text;
                txtDescription.Text = "";
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
        protected void UpdateCategory(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update table books set category_id=@categoryId where id=@id");
                cmd.Parameters.AddWithValue("@categoryID",ddlCtg.SelectedValue);
                cmd.Parameters.AddWithValue("@id", bid);
                cmd.ExecuteNonQuery();
                lblCategory.Text = ddlCtg.SelectedItem.ToString();
                ddlCtg.SelectedIndex = 0;
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