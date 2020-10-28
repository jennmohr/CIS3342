using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using ReviewClasses;
using System.Net.Mime;

namespace RestaurantApp
{
    public partial class NewRestaurant : System.Web.UI.Page
    {

        SQLHandler procedures = new SQLHandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            string userType = Session["UserType"].ToString();

            if (userType == "Reviewer")
            {
                divAddRep.Visible = false;
                divReview.Visible = true;
            }else if(userType == "Representative")
            {
                divAddRep.Visible = true;
                divReview.Visible = false;
                showData();
            }
            else
            {
                divAddRest.Visible = false;
                divReview.Visible = false;
                lblAlert.Text = "You do not have access to this page. Please login to add restaurant.";
            }

        }

        protected void showData()
        {
            gvRep.DataSource = procedures.getRestNoReps();
            gvRep.DataBind();

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string userType = Session["UserType"].ToString();

            if (userType == "Reviewer")
            {
                string restName = Request.Form["inputRestName"];
                string description = Request.Form["inputDescription"];
                string category = Request.Form["selectCategory"];
                string imageURL = Request.Form["inputImage"];
                string rep = "";
                string userID = Session["UserID"].ToString();

                string comment = Request.Form["txtComment"];
                int service = Int32.Parse(Request.Form["selectService"]);
                int quality = Int32.Parse(Request.Form["selectQuality"]);
                int price = Int32.Parse(Request.Form["selectPrice"]);
                int atmos = Int32.Parse(Request.Form["selectAtmosphere"]);
                Restaurant newRest = new Restaurant(restName, description, category, imageURL, rep);
                Review newReview = new Review(restName, comment, service, quality, price, atmos, userID);
                procedures.addNewReview(newReview);
                Response.Redirect("RestaurantPage.aspx?Id=" + restName);
            }
            else if(userType == "Representative")
            {
                string restName = Request.Form["inputRestName"];
                string description = Request.Form["inputDescription"];
                string category = Request.Form["selectCategory"];
                string imageURL = Request.Form["inputImage"];
                string rep = Session["UserID"].ToString();

                Restaurant newRest = new Restaurant(restName, description, category, imageURL, rep);
                Response.Redirect("RestaurantPage.aspx?Id=" + restName);
            }
        }

        protected void gvRep_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String representative = Session["UserID"].ToString();
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            String restName = gvRep.Rows[rowIndex].Cells[1].Text;
            procedures.addRepToRest(representative, restName);
            showData();

            lblAlert.Text = "Representative added to " + restName ;
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Remove("UserType");
            Session.Remove("UserID");
            Response.Redirect("Login.aspx");
        }
    }        

}