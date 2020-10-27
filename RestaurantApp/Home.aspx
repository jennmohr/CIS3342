<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RestaurantApp.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Schmelp</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous" />
    <style>
        .container img{
            width: 150px;
            height:150px;
            object-fit: cover;
            overflow: hidden;
        }

        #gvHome .btn{
            height:150px;
            width:100px;
            line-height:140px;
        }

        .filterList{
            width: 100%;
        }

        .filterList input[type="checkbox"]{
            margin-right: 6px;
        }
        
        h2{
            text-align:center;
        }

    </style>
</head>
<body style="background-color:ghostwhite">
    <form id="login" runat="server">
        

        <nav class="navbar navbar-dark bg-dark fixed-top navbar-expand-md">
        <div id="navbar" class="navbar-collapse collapse">
            <a class="navbar-brand">
                <img src="images/restaurant.svg" width="30" height="30" class="d-inline-block align-top" id="brand">
                Schmelp
            </a>
            <ul class="nav navbar-nav">
                <li>
                    <a href="Home.aspx" class="nav-link">Home</a>
                </li>
            </ul>
            <ul class="nav navbar-nav ml-auto">
                <li>
                    <asp:Button runat="server" Text="Log Out" id="btnLogOut" OnClick="btnLogOut_Click" />
                </li>
                <li>
                    <asp:Button runat="server" Text="Log In" id="btnLogIn" OnClick="btnLogIn_Click" />
                </li>
            </ul>
        </div>
    </nav>

        <br />
        <br />


        <div class="container">
            <br />
            <div class="card">
                <div class="card-body">
                <h2>Welcome to Schmelp!</h2>
                    <br />
                    <h5>Choose a restaurant or filter by category:</h5><p>
<asp:CheckBoxList id="checkFilter" AutoPostBack="True" runat="server" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="5" OnSelectedIndexChanged="checkFilter_SelectedIndexChanged" CssClass="filterList">
 
         <asp:ListItem id="American" value="American" runat="server"> American</asp:ListItem>
         <asp:ListItem id="Cafe" value="Cafe" runat="server"> Cafe</asp:ListItem>
         <asp:ListItem id="FastFood" value="Fast Food" runat="server"> Fast Food</asp:ListItem>
         <asp:ListItem id="Italian" value="Italian" runat="server"> Italian</asp:ListItem>
         <asp:ListItem id="Japanese"  value="Japanese" runat="server"> Japanese</asp:ListItem>
         <asp:ListItem id="Other"  value="Other" runat="server"> Other</asp:ListItem>
    <asp:ListItem id="Pub" value="Pub" runat="server"> Pub</asp:ListItem>
 
      </asp:CheckBoxList>
                    </p>
                    <br />
                    <asp:Button class="btn-info" ID="btnNewRestaurant" text="Add New Restaurant" runat="server" OnClick="btnNewRestaurant_Click"/>
                    <br /><br />

                <asp:GridView ID="gvHome" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="gvHome_RowCommand">
                <Columns>
                    <asp:ButtonField ControlStyle-CssClass="btn btn-info" CommandName="ShowRestInfo" HeaderText="View Restaurant" Text="View"/>

                    <asp:TemplateField HeaderText="Image" >
                        <ItemTemplate>
                          <img src='<%# Eval("ImageURL") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="RestName" HeaderText="Restaurant Name" />

                    <asp:BoundField DataField="Description" HeaderText="Description" />

                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    </Columns>
                 </asp:GridView>
            </div></div>
        </div>
    </form>
</body>
</html>
