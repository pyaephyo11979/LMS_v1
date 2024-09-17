<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="LMS_v1.Views.Admin.StaticsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <style>
        .cccbd{
            background-color:#f2f2f2;
        }
        .ccccbd{
            background-color:#cccccc;
        }
        .ccccccbd{
            background-color:#b3b3b3;
        }
        .ccl{
            background-color:#b3b3b3; 
        }
    </style>
    
    <div class="container">
        <h4 class="display-4 ms-1">Dashboard</h4>
        <div class="row mt-1">
            <div class="col-4">
                <div class="card rounded-2 cccbd">
                    <div class="card-body">
                        <h5 class="card-title text-center">Total Books <br /> <i class="fas fa-book"></i> </h5>
                        <p class="card-text text-center fw-bold"><%= totalBooks %></p>
                     </div>
                </div>
            </div>
            <div class="col-4">
                <div class="card rounded-2 ccccbd">
                    <div class="card-body">
                        <h5 class="card-title text-center">Total Users <br />
                            <i class="fas fa-user"></i>
                        </h5>
                        <p class="card-text text-center fw-bold" ><%= totalUsers %></p>
                     </div>
                </div>
            </div>                
            <div class="col-4">
                <div class="card rounded-2 ccccccbd">
                    <div class="card-body">
                        <h5 class="card-title text-center " style="color:mintcream;">Total Active Users <br />
                            <i class="fas fa-user"></i>
                        </h5>
                        <p class="card-text text-center fw-bold" style="color:mintcream;"><%= totalActiveUsers %></p>
                     </div>
                </div>
            </div>
            <div class="col-12 mt-1">
                <h4 class="display-6">Recently Added Books</h4>
                <div class="row mt-1" runat="server"  id="bookDisplay">
                    <asp:Repeater ID="rptBooks" runat="server">
                        <ItemTemplate>
                         <div class='card col-3 m-4 ccl'>
                         <img src='/uploads/bookCovers/<%# Eval("image") %>' class='card-img-top'  alt='{name}' />
                         <div class='card-body'>
                         <h5 class='card-title'><%# Eval("name") %></h5>
                            <p class='card-text'><%# Eval("author") %></p>
                            <p class='card-text'><%# Eval("category_name") %></p>
                            <a href='<%# "editbook/"+Eval("id") %>' class='d-inline btn btn-info'>Edit Book</a>
                         </div>
                        </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
