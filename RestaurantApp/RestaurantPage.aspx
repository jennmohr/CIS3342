<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestaurantPage.aspx.cs" Inherits="RestaurantApp.RestaurantPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Schmelp</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous" />
    <style>
        .card img{
            width: 250px;
            height: 250px;
            object-fit: cover;
            overflow: hidden;
            float:left;
            margin-right: 20px;
        }

        .ratings{
            padding:30px;
            float:none;
        }
    </style>
</head>
<body style="background-color:ghostwhite">
    <form id="login" runat="server">
<nav class="navbar navbar-dark bg-dark fixed-top navbar-expand-md">
        <div id="navbar" class="navbar-collapse collapse">
            <a class="navbar-brand" href="/">
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
                    <asp:Button runat="server" Text="Log Out" id="btnLogOut" OnClick="btnLogOut_Click" class="btn btn-info" />
                </li>
                <li>
                    <asp:Button runat="server" Text="Log In" id="btnLogIn" OnClick="btnLogIn_Click" class="btn btn-info"/>
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
            
                    <asp:Image ID="picRest" runat="server" />
                    <h2><asp:Label ID="lblRest" name="lblRest" runat="server" ></asp:Label></h2>
            <p><asp:Label ID="lblDesc" name="lblDesc" runat="server" ></asp:Label><br /><br />
                <b>Category: </b><asp:Label ID="lblCat" name="lblCat" runat="server" ></asp:Label><br /><br /><br />
                <div class="ratings">
                <label><b>Average Rating for Service: </b></label> <asp:Label ID="lblAvgService" name="lblService" runat="server" ></asp:Label><br />
                <label><b>Average Rating for Quality: </b></label> <asp:Label ID="lblAvgQuality" name="lblQuality" runat="server" ></asp:Label><br />
                <label><b>Average Rating for Price: </b></label> <asp:Label ID="lblAvgPrice" name="lblPrice" runat="server" ></asp:Label><br />
                <label><b>Average Rating for Atmosphere: </b></label> <asp:Label ID="lblAvgAtmosphere" name="lblAtmosphere" runat="server" ></asp:Label><br /></div>
            </p>
                    <asp:Button ID="btnAddReview" class="btn btn-info" Text="Add Review" runat="server" OnClick="btnAddReview_Click"/>
                    <asp:Button ID="btnModifyReviews" class="btn btn-info" Text="Modify My Reviews" runat="server" OnClick="btnModifyReviews_Click" />
                    <asp:Button ID="btnMakeReservation" class="btn btn-info" Text="Make Reservation" runat="server" OnClick="btnMakeReservation_Click" />
                    <asp:Button ID="btnModifyReservations" class="btn btn-info" Text="Modify Reservations" runat="server" OnClick="btnModifyReservations_Click"/>
                    <asp:Button ID="btnUpdateRest" class="btn btn-info" Text="Update Restaurant Info" runat="server" Visible="false" OnClick="btnUpdateRest_Click" />
                    <br /><br />
                    <asp:Label ID="lblConfirmation" runat="server"></asp:Label>
                    </div>
                </div><br />
            <div class="container" id="reviewList" runat="server">
                <div class="card">
                    <div class="card-body">
                        <h3>Reviews</h3>
                        <br />
                <asp:GridView ID="gvReviews" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>

                    <asp:BoundField DataField="UserID" HeaderText="User" />

                    <asp:BoundField DataField="ServiceRating" HeaderText="Service Rating" />

                    <asp:BoundField DataField="QualityRating" HeaderText="Quality Rating" />

                    <asp:BoundField DataField="PriceRating" HeaderText="Price Rating" />

                    <asp:BoundField DataField="AtmosRating" HeaderText="Atmosphere Rating" />

                    <asp:BoundField DataField="ReviewComment" HeaderText="Review Comment" />
                    </Columns>
                 </asp:GridView>
                    </div>
                </div>
            </div>

            <div class="container" id="userReviews" runat="server">
                <div class="card">
                    <div class="card-body">
                        <h3>My Reviews</h3>
                        <br />
                <asp:GridView ID="gvUserReviews" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="gvUserReviews_RowCommand">
                <Columns>


                    <asp:ButtonField ControlStyle-CssClass="btn btn-info" CommandName="ModifyReview" HeaderText="Modify Review" Text="Modify" />
                    <asp:ButtonField ControlStyle-CssClass="btn btn-info" CommandName="DeleteReview" HeaderText="Delete Review" Text="Delete" />


                    <asp:BoundField DataField="ServiceRating" HeaderText="Service Rating" />

                    <asp:BoundField DataField="QualityRating" HeaderText="Quality Rating" />

                    <asp:BoundField DataField="PriceRating" HeaderText="Price Rating" />

                    <asp:BoundField DataField="AtmosRating" HeaderText="Atmosphere Rating" />

                    <asp:BoundField DataField="ReviewComment" HeaderText="Review Comment" />
                    </Columns>
                 </asp:GridView>
                    </div>
                </div>
            </div>

            <div class="container" id="divManageReservations" runat="server" Visible="false">
                <div class="card">
                    <div class="card-body">
                        <h3>Manage Reservations</h3>
                        <br />
                <asp:GridView ID="gvReservations" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="gvReservations_RowCommand" DataKeyNames="ReservationID">
                <Columns>


                    <asp:ButtonField ControlStyle-CssClass="btn btn-info" CommandName="ModifyRes" HeaderText="Modify Reservation" Text="Modify" />
                    <asp:ButtonField ControlStyle-CssClass="btn btn-info" CommandName="DeleteRes" HeaderText="Delete Reservation" Text="Delete" />


                    <asp:BoundField DataField="reservationName" HeaderText="Name" />

                    <asp:BoundField DataField="ReservationDateTime" HeaderText="Date and Time" />

                    <asp:BoundField DataField="NumInParty" HeaderText="Amount in Party" />

                    </Columns>
                 </asp:GridView>
                    </div>
                </div>
            </div>

            <div class="container" id="newReview" runat="server">
                <br />
                <div class="card">
                <div class="card-body">
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
                    <asp:Button ID="btnSubmit" class="btn btn-info" runat="server" text="Submit Review" OnClick="btnSubmit_Click"/>
                    <asp:Button ID="btnUpdate" class="btn btn-info" runat="server" text="Update Review" Visible="false" OnClick="btnUpdate_Click"/>
                    <asp:Label ID="lblHidden" runat="server" Visible="false"></asp:Label>
                    </div>
                    </div>
            </div>

            <div class="container" id="reservation" Visible="false" runat="server">
                <br />
                <div class="card">
                <div class="card-body">
                    <label for="resName">
                        Enter your name:
                    </label>
                    <input type="text" runat="server" id="txtName" /><br />
                    <label for="resDateTime" class="col-4 col-form-label">Choose Reservation Time</label>
                    <input class="form-control" runat="server" type="datetime-local" id="resDateTime"/><br />
                    <label for="selectPartyNum">How many people are in your party?</label>
                    <select class="form-control" id="selectParty" name="selectParty" runat="server">
                        <option value="1">1</option>
                        <option value="2">2</option>
                         <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                        <option value="6">6</option>
                        <option value="7">7</option>
                        <option value="8">8</option>
                        <option value="9">9</option>
                        <option value="10">10</option>
                </select>
                    <br />
                    <br />
                    <asp:Button class="btn btn-info" ID="btnResev" runat="server" Text="Make Reservation" OnClick="btnResev_Click" />
                    <asp:Button class="btn btn-info" ID="btnUpdateRes" runat="server" Text="Update Reservation" Visible="False" OnClick="btnUpdateRes_Click"/>
                    <br />
              </div>
              </div>
            </div>

            <div class="container" id="updateform" Visible="false" runat="server">
                <div class="card">
                    <div class="card-body">
                        <label for="inputRestName"><b>Restaurant name:</b></label>
            <input type="text" class="form-control" id="inputRestName" name="inputRestName" placeholder="Enter Restaurant Name" runat="server" required/>
             <br />
            <label for="inputDescription"><b>Description:</b></label>
            <input type="text" class="form-control" id="inputDescription" name="inputDescription" placeholder="Enter Description" runat="server" required/>
             <br />
            <label><b>Category</b></label>
                <select class="form-control" id="selectCategory" name="selectCategory" runat="server">
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
            <asp:Button type="button" class="btn btn-info" ID="btnRestUpdate" runat="server" Text="Update Restaurant" OnClick="btnRestUpdate_Click"/>

                    </div>
                </div>
            </div>

            </div>

    </form>
</body>
</html>
