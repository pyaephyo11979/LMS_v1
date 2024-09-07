<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="LMS_v1.Views.Admin.StaticsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h4 class="display-4 ms-1">Dashboard</h4>
        <div class="row mt-1">
            <div class="col-4">
                <div class="card rounded-2">
                    <div class="card-body">
                        <h5 class="card-title text-center">Total Books <br /> <i class="fas fa-book"></i> </h5>
                        <p class="card-text text-center fw-bold"><%= totalBooks %></p>
                     </div>
                </div>
            </div>
            <div class="col-4">
                <div class="card rounded-2">
                    <div class="card-body">
                        <h5 class="card-title text-center">Total Active Users <br />
                            <i class="fas fa-user"></i>
                        </h5>
                        <p class="card-text text-center fw-bold"><%= totalUsers %></p>
                     </div>
                </div>
            </div>
            <div class="col-12 mt-1">
                <h4 class="display-6">Recently Added Books</h4>
                <div class="row mt-1" runat="server"  id="bookDisplay"></div>
            </div>
        </div>
    </div>
</asp:Content>
