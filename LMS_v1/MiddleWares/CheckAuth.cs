using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS_v1.Models;

namespace LMS_v1.MiddleWares
{
    public class CheckAuth
    {
        public void AuthicatorAdmin() { 
            if (HttpContext.Current.Session["user"] == null)
            {
                HttpContext.Current.Response.Redirect("/login");
            }
            else
            {
                User user = (User)HttpContext.Current.Session["user"];
                if (user.role != "2")
                {
                    HttpContext.Current.Response.Redirect("/login");
                }
            }
        }
        public void Authicate()
        {

           if (HttpContext.Current.Session["user"] == null)
            {
                HttpContext.Current.Response.Redirect("/login");
            }

        }
    }
}