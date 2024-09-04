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
            routes.MapPageRoute("books", "books", "~/Views/Books.aspx");
            routes.MapPageRoute("bookDetail","book/{id}","~/Views/BookDetail.aspx");
            routes.MapPageRoute("Users", "Users", "~/Customers.aspx");
            routes.MapPageRoute("StaticsPage", "admin/dashboard", "~/Views/Admin/Dashboard.aspx");
            routes.MapPageRoute("Logout", "logout", "~/Views/Logout.aspx");
            routes.MapPageRoute("Profile", "profile", "~/Views/Profile.aspx");
            routes.MapPageRoute("addBook", "admin/addBook", "~/Views/Admin/AddBook.aspx");
            routes.MapPageRoute("manageBooks", "admin/manageBooks", "~/Views/Admin/ManageBooks.aspx");
            routes.MapPageRoute("manageUsers", "admin/manageUsers", "~/Views/Admin/ManageUsers.aspx");
            routes.MapPageRoute("editBook","admin/editbook/{id}", "~/Views/Admin/EditBook.aspx");
            routes.MapPageRoute("deleteBook", "admin/deletebook/{id}", "~/Views/Admin/DeleteBook.aspx");
            routes.MapPageRoute("UpgradeUser", "upgrade/{pid}", "~/Views/UpgradeUser.aspx");
            routes.MapPageRoute("bookMarks", "bookmarks", "~/Views/BookMarks.aspx");
            routes.MapPageRoute("SuspendUser", "admin/suspend/{uid}", "~/Views/Admin/SuspendUser.aspx");
            routes.MapPageRoute("DeleteUser", "admin/delete/{uid}", "~/Views/Admin/DeleteUser.aspx");
            routes.MapPageRoute("DeleteBookMark", "removebookmark/{bid}", "~/Views/DeleteBookMark.aspx");
        }
    }
}
