<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="LMS_v1.Views.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
            .cpbtn{
            background-color: #d4c2aa;
            color: maroon;
            border-radius: 5px;
            width: 130px;
            height: 39px;
            text-decoration: none;
            font-size: 15px;
            padding: 7px;
            text-align: center;
            
            border: 0px;
          
       }
        .cpbtn:hover {
             background-color: mintcream;
            color: maroon;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3);
           }
         .updatephonebtn{
            background-color: #d4c2aa;
            color: maroon;
            border-radius: 5px;
            width: 130px;
            height: 40px;
            text-decoration: none;
            font-size: 15px;
            padding: 7px;
            text-align: center;
            margin-left: 5px;
            border: 0px;
            
            
       }
        .updatephonebtn:hover {
             background-color: mintcream;
            color: maroon;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3);
}

                .updateph{
            width: 130px;
            height: 40px;
}
            .uploadppbtn{
            background-color: #d4ba91;
            color: maroon;
            border-radius: 5px;
            width: 130px;
            height: 40px;
            text-decoration: none;
            font-size: 15px;
            padding: 7px;
            text-align: center;
            margin: 2px;
            border: 0px;
            margin-left: 100px;
       }
        .uploadppbtn:hover {
             background-color:  #ece3d4;
            color: maroon;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3);
}

        .chof{
            width:900px;

            
        }

            .upgradebtn{
            background-color:#d4ba91;
            color: maroon;
            border-radius: 5px;
            width: 130px;
            height: 40px;
            text-decoration: none;
            font-size: 15px;
            padding: 7px;
            text-align: center;
            margin: 2px;
            border: 0px;
            
       }
        .upgradebtn:hover {
             background-color: #ece3d4;
            color: maroon;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3);
}

        .sout{
            margin-right:5px;
              width: 200px;
  height: 40px;
        }
       .c{
           
    background-color:#f9f2ea;

       }
         
    </style>
    <% var user = (LMS_v1.Models.User)Session["user"]; %>
    <div class="row container-fluid ">
        <div class="col-12">
            <h2>Profile</h2>
        </div>
        <div class="col-12 ">
            <div class="card c">
                <div class="card-body row">
                    <div class="col-4">
                        <% if(user.profileUrl != "") {  %>
                        <img src="/uploads/profiles/<%= user.profileUrl %>" class="card-img" alt="Profile Picture" />
                        <div class="input-group mt-1">
                            <asp:FileUpload ID="filePP" accept=".jpg,.jepg,.png" runat="server" CssClass="form-control" />
                            <asp:Button ID="btnChangePP" runat="server" Text="ChangeProfile" OnClick="ChangeProfile" CssClass="btn changeppbtn input-group-text" />
                        </div>
                        <% } else { %>
                        <img src="https://via.placeholder.com/150" class="img-fluid" alt="Profile Picture" />
                        <div class="mt-1">
                            <asp:FileUpload ID="fileProfile" CssClass="form-control"  accept=".jpg,.jepg,.png" runat="server" />
                                                       
                             <asp:Button ID="btnUploadProfile" runat="server" Text="Upload" OnClick="UpdateProfile" CssClass="btn uploadppbtn " />
                           
                         </div>
                        <% } %>
                    </div>
                    <div class="col-8">
                        <div class="row">
                            <div class="col-12">
                                <h5>Personal Information</h5>
                            </div>
                            <div class="col-12">
                                <p>Name: <%= user.fullname %></p>
                            </div>
                            <div class="col-12">
                                <p>Email: <%= user.email %></p>
                            </div>
                            <div class="col-12">
                                <% if(user.phone == "") { %>
                                <p>Phone: Not Provided</p>
                                <div class="input-group">
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control updateph" TextMode="Phone" placeholder="Enter Phone Number"></asp:TextBox>
                                    <div>
    <asp:Button ID="btnUpdatePhone" runat="server" Text="Update" OnClick="AddPhone" CssClass="btn updatephonebtn"/>
</div>
                                </div>
                                
                                <% } else { %>
                                <p>Phone: <%= user.phone %></p>
                                <% } %>
                            </div>
                            <div class="col-12">
                                <% if (bookLimit >= 0 && IsUnlimited == "False")
                                    {  %>
                                <p>BookLimitLeft: <%= bookLimit %></p> 
                                <% }
                                    else if (IsUnlimited == "True")
                                    {  %>
                                <p>Unlimited BookLimit</p>
                                <% } %>
                            </div>
                            <div class="col-12">
                                <% int level = Convert.ToInt32(user.planID); switch(level) {  %>
                                <% case 1: %>
                                <p>Plan: <span class="text-secondary">Free</span></p>
                                <button class="btn upgradebtn" type="button" data-bs-toggle="modal" data-bs-target="#upgradeModel">Upgrade</button>
                                <% break; %>
                                <% case 2: %>
                                <p>Plan: <span style="color:lightblue">Basic</span></p>
                                <button class="btn upgradebtn" type="button" data-bs-toggle="modal" data-bs-target="#upgradeModel">Change Plan</button>
<%--                                <a class="btn  upgradebtn" style="width:200px" runat="server" href="~/upgrade/1">Cancel Subscription</a>--%>
                                <% break; %>
                                <% case 3: %>
                                <p>Plan: <span style="color:silver">Standard</span></p>
                                <button class="btn upgradebtn" type="button" data-bs-toggle="modal" data-bs-target="#upgradeModel">Change Plan</button>
<%--                                <a class="btn  upgradebtn" style="width:200px" runat="server" href="~/upgrade/1">Cancel Subscription</a>--%>
                                <% break; %>
                                <% case 4: %>
                                <p>Plan: <span style="color:goldenrod">Premium</span></p>
                                <button class="btn upgradebtn" type="button" data-bs-toggle="modal" data-bs-target="#upgradeModel">Change Plan</button>
<%--                                <a class="btn  upgradebtn" style="width:200px;" runat="server" href="~/upgrade/1">Cancel Subscription</a>--%>
                                <% break; %>
                                <% case 5: %>
                                <p>Plan: <span style="color:gold">Unlimited</span></p>
                                <button class="btn upgradebtn" type="button" data-bs-toggle="modal" data-bs-target="#upgradeModel">Change Plan</button>
<%--                                <a class="btn  upgradebtn" style="width:200px" runat="server" href="~/upgrade/1">Cancel Subscription</a>--%>
                                <% break; %>
                                <% default: %>
                                <p>Plan: <span class="text-secondary">Free</span></p>
<%--                                <button class="btn upgradebtn" type="button" data-bs-toggle="modal" data-bs-target="#upgradeModel">Upgrade</button>--%>
                                <% break; %>
                                <% } %>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-12">
            <div class="card">
                <div class="card-body">
                    <asp:Label ID="lblError" CssClass="text-danger" runat="server"></asp:Label>
                    <div class=" soutgroup row">
                       <div class="sout col-3">
                                                   <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control d" TextMode="Password" placeholder="Old Password"></asp:TextBox>

                       </div> 
                        <div class="sout col-3">
                                                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="New Password"></asp:TextBox>

                        </div>
                        <div class="sout col-3">
                                                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>

                        </div>    
                    <asp:Button ID="btnChangePassword" CssClass="cpbtn col-3" runat="server" Text="Change Password" />
                        
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
