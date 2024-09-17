<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="LMS_v1.Views.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <style type="text/css">
       .bookCover {
    transition: transform 0.3s ease, box-shadow 0.3s ease;
 
}

.bookCover:hover {
    transform: scale(1.1); /* Uniform scaling */
    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3); /* Adds a shadow */
}
.btnf{
    background-color: #d4ba91;
              
           color:maroon; 
           border-radius:5px;
           width:60px;
           height:35px;
           text-decoration:none;
           font-size:15px;
           padding:7px;
           text-align:center;
           margin:2px;
           border:0px;
           margin-left:10px;
           
}
.btnf:hover{
    background-color:#ece3d4;
    color:maroon;
    box-shadow:0 4px 15px rgba(0, 0, 0, 0.3);
}
        .btns {
            background-color: #d4ba91;
            color: maroon;
            border-radius: 5px;
            width: 40px;
            height: 35px;
            text-decoration: none;
            font-size: 15px;
            padding: 7px;
            text-align: center;
            margin: 2px;
            border: 0px;
            margin-left: 10px;
        }
            .btns:hover {
                background-color: #ece3d4;
                color: maroon;
                box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3);
            }
    
        .ts {
           
            color: maroon;
            border-radius: 5px;
           
            text-decoration: none;
            font-size: 15px;
            padding: 7px;
            
            margin: 2px;
            border: 0px;
            margin-left: 10px;
        }
        .detail{
            width:250px;
            height:10px;
            border-radius:10px;
            text-decoration:none;
             background-color: #d4ba91;
             color: maroon;
             padding:8px;
             margin:auto;
       }
        .detail:hover{
            background-color:#ece3d4;
            color:maroon;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.3); 
        }
        .cbd{
            background-color:#f9f2ea;
        }
        .ft{
    background-color:#f9f2ea;
}
           

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row mb-3" >
            <div class="col-12">
                <h2 class="headerTxgt" style="color:maroon; text-align:center;">Explore Our Library</h2>
                <p style= text-align:center;">Browse our extensive collection of books and find your next read.</p>

                <p></p>
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
                <div class="me-2 ">
                    <asp:Button ID="btnFilter" CssClass="btnf" runat="server" Text="Filter" OnClick="filter"  />
                </div>
                <div class="me-1">
                    <asp:LinkButton ID="btnClrFilter" OnClick="clrFilter" CssClass="btn" runat="server">
                        <i class="fas fa-broom"></i>
                    </asp:LinkButton>
                </div>
            </div>
            <div class="col-md-3 container-fluid">
                <div class="flex-fill"></div>
                <div class="input-group">
                    <asp:TextBox ID="txtSearch"  runat="server" CssClass="ts" placeholder="Search books..."></asp:TextBox>
                    <asp:LinkButton ID="btnSc" OnClick="search" runat="server" CssClass="btns"><i class="fas fa-search"></i></asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="row " id="bookDisplay" runat="server">
            <asp:Repeater ID="rptBook" runat="server">
                <ItemTemplate>
                         <div class='card book col-2 m-3' data-aos="fade-up" data-aos-easing="ease-in-out" data-aos-duration="3500" >
                         <img src='/uploads/bookCovers/<%# Eval("image") %>' class='bookCover m-auto card-img-top '  alt='<%# Eval("image") %>' />
                         <div class='card-body cbd' >
                         <h5 class='card-title'><%# Eval("name") %></h5>
                            <p class='card-text'><%# Eval("author") %></p>
                            <p class='card-text'><%# Eval("category_name") %></p>
                         </div>
                        <div class="card-footer text-center ft">
                            <a href='<%# "book/"+Eval("id") %>' class=" detail">Details</a>
                        </div>
                        </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
