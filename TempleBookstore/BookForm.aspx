<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookForm.aspx.cs" Inherits="TempleBookstore.BookForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Undercover Books</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous" />
<style>
    table{
        text-align: center; 
        vertical-align: middle;
    }
     
</style>
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
      <li class="nav-item active">
        <a class="nav-link" href="BookForm.aspx">Order Books<span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="ManagementForm.aspx">Management Report</a>
      </li>
    </ul>
  </div>
</nav>
    <br /><br />

    <form id="bookForm" runat="server">
          <div class="container-md" id="order" runat="server">

              <div class="form-group row">
                <label for="inputAddress" class="col-sm-2 col-form-label">Student ID</label>
                <div class="col-sm-8">
                    <input type="text" class="form-control" id="inputID" name="inputID" placeholder="Enter Your Student ID" runat="server" required>
                </div>
            </div>
              
              <div class="form-group row">
                <label for="inputName" class="col-sm-2 col-form-label">Name</label>
                <div class="col-sm-5">
                    <input type="text" class="form-control" id="inputName" name="inputName" placeholder="Enter Your Name" runat="server" required>
                    <div class="invalid-feedback">
                        Please enter your name.
                    </div>
                </div>
            </div>


            <div class="form-group row">
                <label for="inputPhone" class="col-sm-2 col-form-label">Phone Number</label>
                <div class="col-sm-3">
                    <input type="tel" class="form-control" id="inputPhone" name="inputPhone" placeholder="Enter Your Phone Number" runat="server" required>
                </div>
            </div>


            <div class="form-group row">
                <label for="inputAddress" class="col-sm-2 col-form-label">Address</label>
                <div class="col-sm-8">
                    <input type="text" class="form-control" id="inputAddress" name="inputAddress" placeholder="Enter Your Address" runat="server" required>
                </div>
            </div>

            <div class="form-group row">
                <label for="campusSelect" class="col-sm-2 col-form-label">Campus</label>
                <div class="col-sm-3">
                    <select class="form-control" id="campusSelect" name="campusSelect" runat="server">
                        <option>Main</option>
                        <option>TUCC</option>
                        <option>Ambler</option>
                        <option>Tokyo</option>
                        <option>Rome</option>
                    </select>
                </div>
            </div>


              <br />
              
              <br />

              <h5><center>
              <asp:Label ID="lblValidation" runat="server" /></center></h5>

            <br /><br />

            <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <asp:TemplateField HeaderText="Select Book">

                        <ItemTemplate>

                            <asp:CheckBox ID="chkSelect" runat="server" />

                        </ItemTemplate>

                        <HeaderStyle Width="70px"/>

                    </asp:TemplateField>

                    <asp:BoundField DataField="Title" HeaderText="Title" />

                    <asp:BoundField DataField="Authors" HeaderText="Authors" />

                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />

                    <asp:TemplateField HeaderText="Book Type">

                        <ItemTemplate>

                            <asp:DropDownList ID="ddlType" runat="server">
                                <asp:ListItem Text="Hardcover" Value="Hardcover"></asp:ListItem>
                                <asp:ListItem Text="Paper Back" Value="PaperBack"></asp:ListItem>
                                <asp:ListItem Text="E-Book" Value="EBook"></asp:ListItem>
                            </asp:DropDownList>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Method">

                        <ItemTemplate>

                            <asp:RadioButtonList ID="rdoMethod" runat="server" RepeatLayout="Flow">
                                <asp:ListItem Value="Rent"> Rent</asp:ListItem>
                                <asp:ListItem Value="Buy"> Buy</asp:ListItem>
                            </asp:RadioButtonList>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Quantity">

                        <ItemTemplate>

                            <asp:TextBox id="tbQuantity" runat="server" Height="19px" Width="25px" />

                        </ItemTemplate>

                        <HeaderStyle Width="20px" />

                    </asp:TemplateField>

                  

                 </Columns>
            </asp:GridView>
              <br />
              <br />

              <center>
            <asp:Button type="button" class="btn btn-info" ID="btnOrder" runat="server" Text="Place Order" OnClick="btnOrder_Click" Width="200px" Height="75px" Font-Size="Larger"/>
        </center>
          
              <br />
              <br />

              </div>
              <div id="details" class="container-md">

              <table id="tblOrder" class="table table-borderless" runat="server" visible="false">
            <thead>
                <tr>
                    <td><h4>Order Details</h4></td>
                    <td></td>
                </tr>
            </thead>
                <tbody>
                    <tr>
                        <td><h5>Student ID</h5></td>
                        <td><asp:Label ID="lblStudentID" runat="server" visible="true"/></td>
                    </tr>
                    <tr>
                        <td><h5>Name</h5></td>
                        <td><asp:Label ID="lblName" runat="server" visible="true"/></td>
                    </tr>
                    <tr>
                        <td><h5>Phone Number</h5></td>
                        <td><asp:Label ID="lblPhone" runat="server" visible="true"/></td>
                    </tr>
                    <tr>
                        <td><h5>Address</h5></td>
                        <td><asp:Label ID="lblAddress" runat="server" visible="true"/></td>
                    </tr>
                    <tr>
                        <td><h5>Campus</h5></td>
                        <td><asp:Label ID="lblCampus" runat="server" visible="true"/></td>
                    </tr>
                    
                </tbody>
        </table>

                  <br />

              <asp:GridView ID="gvOrder" runat="server" Height="243px" ShowFooter="true" CssClass="table table-striped"/>
        
          
          </div>
    </form>
</body>
</html>
