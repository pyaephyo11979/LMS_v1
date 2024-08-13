using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace LMS_v1
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            routes.MapPageRoute("Login", "login", "~/Views/Login.aspx");
            routes.MapPageRoute("Register", "register", "~/Views/Register.aspx");
            routes.MapPageRoute("HomeRoute", "", "~/views/Home.aspx");
            routes.MapPageRoute("books", "books", "~/Views/Home.aspx");
            routes.MapPageRoute("bookDetail","books/{id}","~/Views/BookDetail.aspx");
            routes.MapPageRoute("Users", "Users", "~/Customers.aspx");
            routes.MapPageRoute("StaticsPage", "admin/statics", "~/Views/Admin/StaticsPage.aspx");
        }
    }
}
