<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAccount.aspx.cs" Inherits="RestaurantApp.NewAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Schmelp</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous" />
    <style>
    .card{
            width:50%;
            margin:auto;
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
                    <a href="Login.aspx" class="nav-link">Back to Login</a>
                </li>
            </ul>
        </div>
    </nav><br /><br />
        <div class="container">
            <br /><br />
            <div class="card">
                <div class="card-body">
                <h2>Create New Account</h2>
                <br />
                <label><b>Select Your Account Type</b></label>
                <select class="form-control" id="selectType" name="selectType">
                    <option value="Reviewer">Reviewer</option>
                    <option value="Representative">Representative</option>
                </select>
            <br />
            <label for="username"><b>Username</b></label>
            <input type="text" class="form-control" id="inputUsername" name="inputUsername" placeholder="Choose a Username" runat="server" required/>
             <br />
                <asp:Label runat="server" id="lblValidation"></asp:Label>
                <br />
                <br />
            <asp:Button type="button" class="btn btn-info" ID="btnCreate" runat="server" Text="Create Account" OnClick="btnCreate_Click" />
                
            </div>
                </div>
        </div>
    </form>
</body>
</html>
