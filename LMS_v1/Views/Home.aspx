<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LMS_v1.Views.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <p class="display-1">Welcome From  Online Library</p>
    </div>
    <a href="~/books" class="text-decoration-none text-dark" style="width:200px;" runat="server">
    <div class="card ">
        <div class="card-body">
            <h4 class="card-title">LatestBooks</h4>
            <div class="row container-fluid" runat="server" id="latestBooks"></div>
        </div>
    </div>
    </a>
</asp:Content>
