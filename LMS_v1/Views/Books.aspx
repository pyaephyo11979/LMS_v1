<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="LMS_v1.Views.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row mb-3">
            <div class="col-12">
                <h2>Books</h2>
                <p>Here you can find all the books available in the library.</p>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-9 d-flex align-items-end">
                <div class="me-2">
                    <asp:DropDownList ID="ddlcategory" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="me-2">
                    <asp:DropDownList ID="ddlauthor" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="me-2">
                    <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="filter" CssClass="btn btn-primary" />
                </div>
            </div>
            <div class="col-md-3">
                <div class="input-group">
                    <asp:TextBox ID="txtSearch"  runat="server" CssClass="form-control" placeholder="Search books..."></asp:TextBox>
                    <asp:Button ID="btnSearch" OnClick="search" runat="server" CssClass="btn btn-info" Text="Search" />
                </div>
            </div>
        </div>
        <div class="row" id="bookDisplay" runat="server"></div>
    </div>
</asp:Content>
