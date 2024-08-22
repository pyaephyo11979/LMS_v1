<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LMS_v1.Views.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <p class="display-1">Welcome Form Rakha Online Library</p>

    </div>
    <div class="card">
        <div class="card-body">
            <h6 class="card-title">LatestBooks</h6>
            <div class="row container-fluid" runat="server" id="latestBooks"></div>
        </div>
    </div>
</asp:Content>
