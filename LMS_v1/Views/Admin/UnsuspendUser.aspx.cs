﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using LMS_v1.MiddleWares;

namespace LMS_v1.Views.Admin
{
    public partial class UnsuspendUser : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAuth ca = new CheckAuth();
                ca.AuthicatorAdmin();
            }
            string id = Page.RouteData.Values["uid"] as string;
            Unsuspend(id);
        }
        protected void Unsuspend(string uid)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Users SET status = 1 WHERE id = @uid", con);
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("~/admin/manageUsers");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}