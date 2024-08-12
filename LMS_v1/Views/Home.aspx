<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LMS_v1.Views.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="row">
            <div class="d-flex row col-sm-12 col-lg-9" runat="server" id="bookdisplay"></div>
            <div class="d-none d-lg-flex d-lg-3" id="searchPanel"></div>
        </div>
    </main>
</asp:Content>
