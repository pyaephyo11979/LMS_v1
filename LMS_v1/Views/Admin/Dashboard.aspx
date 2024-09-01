<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="LMS_v1.Views.Admin.StaticsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-4">
                <canvas id="userViewChart"></canvas>
            </div>
            <div class="col-8">
                <canvas id="bookViewChart"></canvas>
            </div>
        </div>
    </div>
</asp:Content>
