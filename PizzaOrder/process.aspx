<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="process.aspx.cs" Inherits="PizzaOrder.process" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pizza Builder</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    
    <style>
        h6{
            display: inline;
        }

        text{
            float:right;
        }
    </style>

</head>
<body>
    <nav class="navbar navbar-light bg-light">
        <a class="navbar-brand" href="#">
            <img src="/Images/pizza.svg" width="45" height="45" class="d-inline-block align-top" alt=""/>

            &nbsp;  Pizza Builder

            <span class="navbar-text">
                By Jennifer Mohr
            </span>

        </a>
        
    </nav>
    <br />

    <div class="container">

        <table class="table table-borderless">
            <thead>
                <tr>
                    <td><h4>Order Contact</h4></td>
                </tr>
            </thead>
                <tbody>
                    <tr>
                        <td><h5>Name</h5></td>
                        <td><asp:Label ID="lblName" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><h5>Phone Number</h5></td>
                        <td><asp:Label ID="lblPhone" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><h5>Address</h5></td>
                        <td><asp:Label ID="lblAddress" runat="server" /></td>
                    </tr>
                    
                </tbody>
        </table>
        <br /><br /><br />
        <table class="table table-borderless">
            <thead>
                <tr>
                    <td width="25%"><h4>Order Details</h4></td>
                    <td ></td>
                    <td ></td>
                </tr>
            </thead>
                <tbody>
                     <tr>
                        <td><h6><asp:Label ID="lblMethod" runat="server" /></h6></td>
                         <td></td>
                        <td><asp:Label ID="lblMethodPrice" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><h6><asp:Label ID="lblPizzaSize" runat="server" /> Pizza</h6></td>
                        <td></td>
                        <td><asp:Label ID="lblPizzaPrice" runat="server" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><h6>Crust:</h6> <asp:Label ID="lblCrust" runat="server" /></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><h6>Sauce:</h6> <asp:Label ID="lblSauce" runat="server" /></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><h6>Toppings:</h6> <asp:Label ID="lblToppings" runat="server" /></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><h6>Premium Toppings:</h6> <asp:Label ID="lblPremiumToppings" runat="server" /></td>
                        <td><asp:Label ID="lblPremiumToppingsPrice" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><h6>Family Meal:</h6></td>
                        <td><asp:Label ID="lblFamily" runat="server" /></td>
                        <td><asp:Label ID="lblFamilyPrice" runat="server" /></td>
                    </tr>
                    </tbody>
            </table>
        <br /><br /><br />
        <table class="table table-borderless">
            <thead>
                <tr>
                    <td width="50%"><h4>Order Total</h4></td>
                </tr>
            </thead>
            <tbody>
                    <tr>
                        <td></td>
                        <td><h6>Subtotal:</h6></td>
                        <td><asp:Label ID="lblSubtotal" runat="server" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><h6>Tax:</h6></td>
                        <td><asp:Label ID="lblTax" runat="server" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><h6>Tip:</h6></td>
                        <td><asp:Label ID="lblTip" runat="server" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><h6>Grand Total:</h6></td>
                        <td><asp:Label ID="lblGrandTotal" runat="server" /></td>
                    </tr>
                    
                </tbody>
        </table>
       

    </div>

    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
