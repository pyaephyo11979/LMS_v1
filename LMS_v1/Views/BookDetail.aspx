<%@ Page Title="BookDetail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetail.aspx.cs" Inherits="LMS_v1.Views.BookDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <style>
       .bgc{
           background-color:#f9f2ea;
       }
   </style>
    <div class="container " >
        <div class="card bgc">
            <div class="card-header">
                <asp:Label ID="lblTitle" runat="server" CssClass="display-4"></asp:Label>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-md-4">
                        <asp:Image ID="imgBookCover" runat="server" CssClass="img-fluid" />
                    </div>
                    <div class="col-md-8">
                        <div class="row">
                            <div class="col-md-3">
                                <strong>Author:</strong>
                            </div>
                            <div class="col-md-9">
                                <asp:Label ID="lblAuthor" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <strong>Category:</strong>
                            </div>
                            <div class="col-md-9">
                                <asp:Label ID="lblCategory" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <strong>Description:</strong>
                            </div>
                            <div class="col-md-9">
                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <% var user = (LMS_v1.Models.User)Session["user"]; if (user !=null && ((user.bookLimit >0 && user.expdate > DateTime.Now) || (user.isUnlimited == "True" && user.expdate > DateTime.Now)) ) {  %>
                                <asp:LinkButton runat="server" ID="btnDownloadBook" OnClick="DownloadFile" CssClass="btn btn-primary mt-1" > Download <i class="fas fa-download"></i></asp:LinkButton>
                                <%} else if(user != null && user.bookLimit <= 0) {  %>
                                <p>Your downloadable book Limit is exceed . Please <a runat="server" href="profile" class="btn btn-info">Upgrade now</a></p>
                                <%} else if(user != null && user.expdate < DateTime.Now) { %>
                                <p>Your subscription is expired. Please <a href="profile">Renew now</a></p>
                                <%} %>
                                <asp:LinkButton runat="server" OnClick="BookMark" CssClass="btn btn-info mt-1" ID="btnToBookmark" >
                                    <i class="fas fa-bookmark"></i> 
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
        </div>
    </div>
        </div>
</asp:Content>
