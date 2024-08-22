<%@ Page Title="BookDetail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetail.aspx.cs" Inherits="LMS_v1.Views.BookDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="card">
            <div class="card-header">
                <asp:Label ID="lblTitle" runat="server" CssClass="display-3"></asp:Label>
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
                                <%if (Session["user"] != null) {  %>
                                <button class="btn btn-info" runat="server" id="btnGetBook">Read</button>
                                <%} %>
                            </div>
                        </div>
                    </div>
                </div>
        </div>
    </div>
</asp:Content>
