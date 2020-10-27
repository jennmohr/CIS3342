using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using BookLibrary;

namespace TempleBookstore
{
    public partial class BookForm : System.Web.UI.Page
    {

        DBConnect objDB = new DBConnect();
        ArrayList arrBooks = new ArrayList();
        Contact Customer = new Contact();

        protected void Page_Load(object sender, EventArgs e){

            if (!IsPostBack){

                String strSQL = "SELECT * FROM Books ORDER BY Title ASC";

                gvBooks.DataSource = objDB.GetDataSet(strSQL);
                String[] names = new String[1];
                names[0] = "BasePrice";
                gvBooks.DataKeyNames = names;
                gvBooks.DataBind();

            }
            

        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            getContact();
            bool process = false;
            int count = 0;

            for(int row = 0; row < gvBooks.Rows.Count; row++)
            {
                CheckBox CBox;
                CBox = (CheckBox)gvBooks.Rows[row].FindControl("chkSelect");

                if (CBox.Checked)
                {
                    if (ValidateOrder(row)) {

                        process = true;
                        Book objBook = new Book();
                        objBook.Title = gvBooks.Rows[row].Cells[1].Text;
                        DropDownList ddl = (DropDownList)gvBooks.Rows[row].Cells[4].FindControl("ddlType");
                        objBook.Type = ddl.SelectedValue;
                        RadioButtonList radio = (RadioButtonList)gvBooks.Rows[row].Cells[5].FindControl("rdoMethod");
                        objBook.Method = radio.SelectedValue;
                        TextBox tb = (TextBox)gvBooks.Rows[row].Cells[6].FindControl("tbQuantity");
                        string quantity = tb.Text;
                        objBook.ISBN = gvBooks.Rows[row].Cells[3].Text;
                        objBook.Quantity = Int32.Parse(quantity);
                        decimal price = Decimal.Parse(gvBooks.DataKeys[row].Value.ToString());
                        objBook.Price = Math.Round(price, 2);
                        decimal cost = objBook.Price * objBook.Quantity;
                        objBook.Cost = Math.Round(price, 2);
                        arrBooks.Add(objBook);
                        count = count + 1;

                    }
                    else
                    {
                        lblValidation.Text = "Make sure you've selected a method and entered a valid quantity for " + gvBooks.Rows[row].Cells[1].Text;
                        lblValidation.Focus();
                        process = false;
                        return;
                    }

                }
            }

            if (count > 0 && process)
            {
                getContact();
                tblOrder.Visible = true;
                displayContact();
                showOrder();
                processOrder();
                order.Visible = false;
            }
            else
            {
                lblValidation.Text = "You must select at least one book.";
                lblValidation.Focus();
                return;
            }
            

            
        }

        public void showOrder()
        {
            gvOrder.DataSource = arrBooks;
            gvOrder.DataBind();
            decimal quantTotal = calcQuantTotal();
            decimal costTotal = calcCostTotal();
            gvOrder.FooterRow.Cells[0].Text = "Totals";
            gvOrder.FooterRow.Cells[5].Text = quantTotal.ToString();
            gvOrder.FooterRow.Cells[6].Text = costTotal.ToString();

        }

        public decimal calcQuantTotal()
        {
            decimal total = 0;

            for (int row = 0; row < gvOrder.Rows.Count; row++)
            {
                total += Int32.Parse(gvOrder.Rows[row].Cells[5].Text);
            }


            return total;
        }

        public decimal calcCostTotal()
        {
            decimal total = 0;

            for (int row = 0; row < gvOrder.Rows.Count; row++)
            {
                total += Decimal.Parse(gvOrder.Rows[row].Cells[6].Text);
            }


            return total;
        }

        public void getContact()
        {
            Customer.StudentID = Request.Form["inputID"];
            Customer.Name = Request.Form["inputName"];
            Customer.Phone = Request.Form["inputPhone"];
            Customer.Address = Request.Form["inputAddress"];
            Customer.Campus = Request.Form["campusSelect"];
            
        }

        public bool ValidateOrder(int row)
        {
            string title = gvBooks.Rows[row].Cells[1].Text;
            int number;
            TextBox tb = (TextBox)gvBooks.Rows[row].Cells[6].FindControl("tbQuantity");
            string quantity = tb.Text;
            bool parse = Int32.TryParse(quantity, out number);
            RadioButtonList radio = (RadioButtonList)gvBooks.Rows[row].Cells[5].FindControl("rdoMethod");
            string method = radio.SelectedValue;

            if (quantity != "" && parse && method != "")
            {
                return true;
            }

            return false;
        }

        public void displayContact()
        {
            lblStudentID.Text = Customer.StudentID;
            lblName.Text = Customer.Name;
            lblPhone.Text = Customer.Phone;
            lblCampus.Text = Customer.Campus;
            lblAddress.Text = Customer.Address;

        }

        public void processOrder()
        {
            for(int i = 0; i < arrBooks.Count; i++)
            {
                Book selected = (Book)arrBooks[i];
                string method = selected.Method;

                int total = selected.Quantity;

                string sqlUpdate = "UPDATE Books SET TotalSales = TotalSales + " + total + " WHERE ISBN = " + selected.ISBN;
                objDB.DoUpdate(sqlUpdate);

                if(method == "Rent")
                {
                   sqlUpdate = "UPDATE Books SET TotalQuantityRented = TotalQuantityRented + " + total + " WHERE ISBN = " + selected.ISBN;
                   objDB.DoUpdate(sqlUpdate);
                }
                else if (method == "Buy")
                {
                    sqlUpdate = "UPDATE Books SET TotalQuantitySold = TotalQuantitySold + " + total + " WHERE ISBN = " + selected.ISBN;
                    objDB.DoUpdate(sqlUpdate);
                }

            }
        }

    }
}