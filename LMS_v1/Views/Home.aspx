<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LMS_v1.Views.WebForm1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
    <style>
        a .bookCover:hover{
            transform:scale(1,1);
        }
        .bd{
            background-color: #ece3d4;
        }
       .headerPart{
           min-width:500px;
           min-height:300px;
           background-image:url("");
           background-repeat:no-repeat;
           background-size:cover;
           background-attachment:scroll;
       }
       .BtnStrt{
           background-color:#d4ba91;
           color:maroon; 
           border-radius:5px;
           width:200px;
           height:160px;
           text-decoration:none;
           font-size:15px;
           padding:7px;
           text-align:center;
           margin-left:40%;
       }
       .BtnStrt:hover{
           background-color:#ece3d4;
           color:maroon;
           box-shadow:0 4px 15px rgba(0, 0, 0, 0.3);
       }
       .center{
           display:block;
           margin-left:auto;
           margin-right:auto;
           width:50%;
       }
        .ccbd {
            background-color: #f9f2ea;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container bd">
        <div class="headerPart">
        <p class="display-1">Welcome From  Konoha Digital Library</p>
        <p>KonohaDigitalLibrary is a place for Books lovers. If you are a lover of books, and you want to read all kinds of books.
    This is a right place for you. You can rent thousands of high-quality books.
    We want you to know that KonohaDigitalLibrary was born for you.. </p>
           <div>
                    <br />       <a href="books" class="  BtnStrt" style=" ">Start Explore Now</a>

           </div> 
             
    </div>
     
    <a href="~/books" class="text-decoration-none text-dark" style="width:200px;" runat="server">
    <div class="card  " data-aos="fade-up"  data-aos-duration="3000" >
        <div class="card-body ccbd">
            <h4 class="card-title">LatestBooks <i class="fas fa-clock"></i></h4>
            <div class="row container-fluid" runat="server" id="latestBooks">
             <asp:Repeater ID="rptltBooks" runat="server">
                <ItemTemplate>
                         <div class='card col-2 m-1'>
                        <img src='/uploads/bookCovers/<%# Eval("image") %>' class=' card-img m-auto bookCover'  alt='{name}' />
                        </div>
                </ItemTemplate>
            </asp:Repeater>
            </div>
        </div>
    </div>
    </a>
    </div>
</asp:Content>
