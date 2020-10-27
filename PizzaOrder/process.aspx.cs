using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaOrder
{
    public partial class process : System.Web.UI.Page
    {

        double price = 0;
        double delPrice = 3.00;
        double smallPrice = 8.95;
        double medPrice = 12.50;
        double largePrice = 13.95;
        double xlargePrice = 15.95;
        double premTopPrice = 1.50;
        double famMealPrice = 7.50;
        double tipAmount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request.Form["inputName"];
            string phone = Request.Form["inputPhone"];
            string address = Request.Form["inputAddress"];
            string method = Request.Form["methodRadios"];
            string size = Request.Form["sizeRadios"];
            string crust = Request.Form["crustSelect"];
            string sauce = Request.Form["sauceSelect"];
            string toppings = Request.Form["toppingsCheck"];
            string premToppings = Request.Form["premToppingsCheck"];
            string familyMeal = Request.Form["familyMeal"];
            string tip = Request.Form["tipAmount"];

            loadContact(name, phone, address);

            loadDetails(method, size, crust, sauce, toppings, premToppings, familyMeal, tip);

            calculateTotal(tip);

        } 

        public void loadContact(string name, string phone, string address)
        {
            lblName.Text = name;
            lblPhone.Text = phone;
            lblAddress.Text = address;
        }

        public void calculateTotal(string tip)
        {
            double subtotal = price;
            lblSubtotal.Text = subtotal.ToString("C");

            double tax = Math.Round(subtotal * 0.08, 2);
            lblTax.Text = tax.ToString("C");

            price += tax;

            if (tip != "")
            {
                price += tipAmount;
                lblTip.Text = tipAmount.ToString("C");
            }
            else
            {
                lblTip.Text = "No Tip";
            }

            lblGrandTotal.Text = price.ToString("C");

        }

        public void loadDetails(string method, string size, string crust, string sauce, string toppings, string premToppings, string familyMeal, string tip)
        {

            double invalidTip = 0;

            if (tip != "" && Double.TryParse(tip, out invalidTip))
            {
                tipAmount = Double.Parse(tip);
            }

            if(method == "Delivery")
            {
                price += delPrice;
                lblMethod.Text = method + " Fee";
                lblMethodPrice.Text = delPrice.ToString("C");
            }
            else
            {
                lblMethod.Text = method;
                lblMethodPrice.Text = "$0.00";
            }

            if(size == "Small")
            {
                price += smallPrice;
                lblPizzaSize.Text = "Small 12 Inch";
                lblPizzaPrice.Text = smallPrice.ToString("C");
            }
            else if(size == "Medium")
            {
                price += medPrice;
                lblPizzaSize.Text = "Medium 14 Inch";
                lblPizzaPrice.Text = medPrice.ToString("C");
            }
            else if(size == "Large")
            {
                price += largePrice;
                lblPizzaSize.Text = "Large 16 Inch";
                lblPizzaPrice.Text = largePrice.ToString("C");
            }
            else
            {
                price += xlargePrice ;
                lblPizzaSize.Text = "X-Large 18 Inch";
                lblPizzaPrice.Text = xlargePrice.ToString("C");
            }

            lblCrust.Text = crust;
            lblSauce.Text = sauce;


            if (toppings == null)
            {
               lblToppings.Text = "None";
            }
            else
            {
                lblToppings.Text = toppings;
            }


            int premToppingsCount;

            if(premToppings == null)
            {
                premToppingsCount = 0;
                lblPremiumToppings.Text = "None";

            }
            else
            {
                lblPremiumToppings.Text = premToppings;
                premToppingsCount = 1;
                for(int i = 0; i < premToppings.Length; i++)
                {
                    if (premToppings[i] == ','){
                        premToppingsCount++;
                    }
                }

            }

            double premToppingsPrice = premTopPrice * premToppingsCount;
            lblPremiumToppingsPrice.Text = premToppingsPrice.ToString("C");
            price += premToppingsPrice;



            if(familyMeal == "true")
            {
                price += famMealPrice;
                string drinkChoice = Request.Form["familyDrink"];
                string sideChoice = Request.Form["familySide"];
                lblFamily.Text = "<h6>Drink: </h6>" + drinkChoice + ", <h6>Side: </h6>" + sideChoice;
                lblFamilyPrice.Text =  famMealPrice.ToString("C");
            }else{

                lblFamily.Text = "n/a";
                lblFamilyPrice.Text = "$0.00";

            }

            

        }
    }
}