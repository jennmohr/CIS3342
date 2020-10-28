<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewRestaurant.aspx.cs" Inherits="RestaurantApp.NewRestaurant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Schmelp</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous" />

</head>
<body style="background-color:ghostwhite">
    <form id="newRest" runat="server">

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
            </ul>
        </div>
    </nav>
        <br />
        <br />
        <div class="container" id="divAddRest" runat="server">
            <br /><br />
            <div class="card">
                <div class="card-body">
                <h2>Add a new restaurant</h2>
                <br />
            <label for="inputRestName"><b>Restaurant name:</b></label>
            <input type="text" class="form-control" id="inputRestName" name="inputRestName" placeholder="Enter Restaurant Name" runat="server" required/>
             <br />
            <label for="inputDescription"><b>Description:</b></label>
            <input type="text" class="form-control" id="inputDescription" name="inputDescription" placeholder="Enter Description" runat="server" required/>
             <br />
            <label><b>Category</b></label>
                <select class="form-control" id="selectCategory" name="selectCategory">
                    <option value="American">American</option>
                    <option value="Cafe">Cafe</option>
                    <option value="Fast Food">Fast Food</option>
                    <option value="Italian">Italian</option>
                    <option value="Japanese">Japanese</option>
                    <option value="Other">Other</option>
                    <option value="Pub">Pub</option>
                </select>
                <br />
                <label for="inputImage"><b>Image:</b></label>
                <input type="text" class="form-control" id="inputImage" name="inputImage" placeholder="Enter Image URL" runat="server" required/>
             <br />
                   
                    <div id="divReview" runat="server" Visible="false">
                        <p>Because you are a reviewer, you must add a review when creating a new restaurant. Please give the restaurant a review!</p>
                        <asp:Label ID="lblQuality" runat="server">Enter your rating for Food Quality:</asp:Label>
               <select class="form-control" id="selectQuality" name="selectQuality" runat="server">
                        <option value="1">1</option>
                        <option value="2">2</option>
                         <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                </select><br />
                    <asp:Label ID="lblService" runat="server">Enter your rating for Service:</asp:Label>
                    <select class="form-control" id="selectService" name="selectService" runat="server">
                        <option value="1">1</option>
                        <option value="2">2</option>
                         <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                </select><br />
                    <asp:Label ID="lblAtmosphere" runat="server">Enter your rating for Restaurant Atmosphere:</asp:Label>
                    <select class="form-control" id="selectAtmosphere" name="selectAtmosphere" runat="server">
                        <option value="1">1</option>
                        <option value="2">2</option>
                         <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                </select><br />
                    <asp:Label ID="lblPrice" runat="server">Enter your rating for Price Level:</asp:Label>
                    <select class="form-control" id="selectPrice" name="selectPrice" runat="server">
                        <option value="1">1</option>
                        <option value="2">2</option>
                         <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                </select><br />
                <asp:Label ID="lblComment" runat="server">Enter your review:</asp:Label>
                    <asp:TextBox ID="txtComment" runat="server" size="50"></asp:TextBox><br /><br />
                    </div>
            <asp:Button type="button" class="btn btn-info" ID="btnCreateRest" runat="server" Text="Create Restaurant" OnClick="btnCreate_Click" />
            <br />
            </div>
            <br />
            <br />
            <div class="col-sm-10" id="divAddRep" runat="server">
                <span>If you would like to be added to a restaurant that a reviewer added and does not already have a representative, select a restaurant: </span>
                <br /><br />
                <asp:GridView ID="gvRep" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="gvRep_RowCommand">
                <Columns>
                    <asp:ButtonField ControlStyle-CssClass="btn btn-info" HeaderText="Represent Restaurant" Text="Select" CommandName="AddRepToRest" />

                    <asp:BoundField DataField="RestName" HeaderText="Restaurant Name" />

                    </Columns>
                 </asp:GridView>

            </div>
                </div>

            </div>
        <div class="container">
            <br />
            <asp:Label runat="server" id="lblAlert"></asp:Label>
        </div>
        </form>

</body>
</html>