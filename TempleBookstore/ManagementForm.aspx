<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagementForm.aspx.cs" Inherits="TempleBookstore.ManagementForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Temple Bookstore</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous" />
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand" href="#">
  <img src="Images/books.svg" width="30" height="30" class="d-inline-block align-top" alt="" loading="lazy">
      Undercover Books</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="navbarNav">
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" href="BookForm.aspx">Order Books</a>
      </li>
      <li class="nav-item active">
        <a class="nav-link" href="ManagementForm.aspx">Management Report<span class="sr-only">(current)</span></a>
      </li>
    </ul>
  </div>
</nav>
    <form id="form1" runat="server">
        <br />
        <br />
        <div class="container-md">
        <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" />

                <asp:BoundField DataField="ISBN" HeaderText="ISBN" />

                <asp:BoundField DataField="TotalSales" HeaderText="Total Sales" />

                <asp:BoundField DataField="TotalQuantityRented" HeaderText="Amount Rented" />

                <asp:BoundField DataField="TotalQuantitySold" HeaderText="Amount Sold" />
            </Columns>
        </asp:GridView>
            <br />
            <br />
            </div>
    </form>
</body>
</html>
