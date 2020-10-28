using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using ReviewClasses;

namespace RestaurantApp
{
    public partial class RestaurantPage : System.Web.UI.Page
    {
        string restName = "";
        string userID = "";
        SQLHandler procedures = new SQLHandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            string userType = Session["UserType"].ToString();
            string rep = "";

            restName = Request.QueryString["Id"];
            loadRestaurant();
            reviewList.Visible = true;
            newReview.Visible = false;
            userReviews.Visible = false;
            getAverages();
            loadReviews();

            if (userType == "Reviewer")
            {
                userID = Session["UserID"].ToString();
                btnModifyReservations.Visible = false;
                btnLogIn.Visible = false;
            }
            else if (userType == "Representative")
            {
                userID = Session["UserID"].ToString();
                btnModifyReviews.Visible = false;
                btnAddReview.Visible = false;
                btnMakeReservation.Visible = true;
                btnLogIn.Visible = false;

                DataSet represent = procedures.getRepresentative(restName);

                if (represent.Tables[0].Rows.Count == 0)
                {
                    rep = null;
                }
                else
                {
                    rep = represent.Tables[0].Rows[0][0].ToString();
                }


                if (userID == rep)
                {
                    btnModifyReservations.Visible = true;
                    btnUpdateRest.Visible = true;
                }
                else
                {
                    btnModifyReservations.Visible = false;
                    btnUpdateRest.Visible = false;
                }
            }
            else
            {
                btnMakeReservation.Visible = true;
                btnModifyReviews.Visible = false;
                btnAddReview.Visible = false;
                btnLogOut.Visible = false;
                btnModifyReservations.Visible = false;
                btnLogIn.Visible = true;
            }

        }

        protected void loadRestaurant()
        {
            lblRest.Text = restName;
            inputRestName.Value = restName;
            DataSet restaurant = procedures.loadRestaurant(restName);
            lblDesc.Text = restaurant.Tables[0].Rows[0][1].ToString();
            inputDescription.Value = lblDesc.Text;
            lblCat.Text = restaurant.Tables[0].Rows[0][2].ToString();
            selectCategory.Value = lblCat.Text;
            picRest.ImageUrl = restaurant.Tables[0].Rows[0][3].ToString();
            inputImage.Value = picRest.ImageUrl;

        }

        protected void loadReviews()
        {
            gvReviews.DataSource = procedures.loadReviews(restName);
            gvReviews.DataBind();
        }

        protected void btnAddReview_Click(object sender, EventArgs e)
        {
            newReview.Visible = true;
            reviewList.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            addReviewToDatabase();
        }

        public void addReviewToDatabase()
        {
            string comment = Request.Form["txtComment"];
            int service = Int32.Parse(Request.Form["selectService"]);
            int quality = Int32.Parse(Request.Form["selectQuality"]);
            int price = Int32.Parse(Request.Form["selectPrice"]);
            int atmos = Int32.Parse(Request.Form["selectAtmosphere"]);
            Review rev = new Review(restName, comment, service, quality, price, atmos, userID);
            procedures.addNewReview(rev);
            reviewList.Visible = true;
            newReview.Visible = false;
            loadReviews();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void btnModifyReviews_Click(object sender, EventArgs e)
        {
            reviewList.Visible = false;
            userReviews.Visible = true;
            gvUserReviews.DataSource = procedures.getUserReviews(userID, restName);
            String[] ids = new String[1];
            ids[0] = "ReviewID";
            gvUserReviews.DataKeyNames = ids;
            gvUserReviews.DataBind();
        }

        protected void getAverages()
        {
            DataSet averages = procedures.getAverages(restName);
            lblAvgService.Text = averages.Tables[0].Rows[0][0].ToString();
            lblAvgQuality.Text = averages.Tables[0].Rows[0][1].ToString();
            lblAvgPrice.Text = averages.Tables[0].Rows[0][2].ToString();
            lblAvgAtmosphere.Text = averages.Tables[0].Rows[0][3].ToString();

        }

        protected void gvUserReviews_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int reviewID = Int32.Parse(gvUserReviews.DataKeys[rowIndex].Value.ToString());

            if (e.CommandName == "DeleteReview")
            {
                gvReviews.DataSource = procedures.deleteReview(reviewID, userID);
                loadReviews();

            }
            else if(e.CommandName == "ModifyReview")
            {
                
                displayEditBoxes(reviewID);
                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
                reviewList.Visible = false;
                lblHidden.Text = reviewID.ToString();

            }
        }

        protected void displayEditBoxes(int reviewID)
        {

            DataSet review = procedures.getReview(reviewID);

            newReview.Visible = true;
            selectQuality.Value = review.Tables[0].Rows[0][3].ToString();
            selectAtmosphere.Value = review.Tables[0].Rows[0][5].ToString();
            selectPrice.Value = review.Tables[0].Rows[0][4].ToString();
            selectService.Value = review.Tables[0].Rows[0][2].ToString();
            txtComment.Text = review.Tables[0].Rows[0][6].ToString();
        }

        protected void updateReview(int reviewID)
        {
                string comment = Request.Form["txtComment"];
                int service = Int32.Parse(Request.Form["selectService"]);
                int quality = Int32.Parse(Request.Form["selectQuality"]);
                int price = Int32.Parse(Request.Form["selectPrice"]);
                int atmos = Int32.Parse(Request.Form["selectAtmosphere"]);

                procedures.updateReview(reviewID, comment, service, quality, price, atmos, userID);
                reviewList.Visible = true;
                newReview.Visible = false;
                loadReviews();
                Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int reviewID = Int32.Parse(lblHidden.Text);
            updateReview(reviewID);
        }

        protected void btnMakeReservation_Click(object sender, EventArgs e)
        {
            reservation.Visible = true;
            reviewList.Visible = false;
            resDateTime.Value = DateTime.Now.AddDays(1).ToString("yyyy-MM-ddTHH:mm");
            resDateTime.Attributes["min"] = DateTime.Now.AddDays(1).ToString("yyyy-MM-ddTHH:mm");
            resDateTime.Attributes["max"] = DateTime.Now.AddDays(15).ToString("yyyy-MM-ddTHH:mm");
            
        }

        protected void btnResev_Click(object sender, EventArgs e)
        {
            DateTime resTime = DateTime.Parse(Request.Form["resDateTime"]);
            string date = resTime.ToString("MMMM dd");
            string time = resTime.ToString("hh:mm tt");
            int partyAmount = Int32.Parse(Request.Form["selectParty"]);
            string name = Request.Form["txtName"];
            Reservation res = new Reservation(resTime, partyAmount, name, restName);
            procedures.addNewReservation(res);

            lblConfirmation.Text = "Thank you, " + name + "! Your reservation is confirmed for " + date + " at " + time + " for " + partyAmount + " people. Contact the restaurant to change or cancel your reservation.";
            reservation.Visible = false;
        }

        protected void btnModifyReservations_Click(object sender, EventArgs e)
        {
            reviewList.Visible = false;
            divManageReservations.Visible = true;
            loadReservations();

        }

        protected void loadReservations()
        {
            gvReservations.DataSource = procedures.getReservations(restName);
            String[] ids = new String[1];
            ids[0] = "ReservationID";
            gvUserReviews.DataKeyNames = ids;
            gvReservations.DataBind();
        }

        protected void gvReservations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int resID = Int32.Parse(gvReservations.DataKeys[rowIndex].Value.ToString());

            if (e.CommandName == "DeleteRes")
            {
                gvReviews.DataSource = procedures.deleteReservation(resID, userID, restName); 
                loadReservations();
                reviewList.Visible = false;

            }
            else if (e.CommandName == "ModifyRes")
            {
                displayResEditBoxes(resID);
                lblHidden.Text = resID.ToString();
                reviewList.Visible = false;
                btnUpdateRes.Visible = true;
                btnResev.Visible = false;
            }
        }

        protected void displayResEditBoxes(int resID)
        {
            DataSet res = procedures.getReservation(resID);

            reservation.Visible = true;
            txtName.Value = res.Tables[0].Rows[0][3].ToString();
            selectParty.Value = res.Tables[0].Rows[0][2].ToString();
            resDateTime.Value = DateTime.Parse(res.Tables[0].Rows[0][1].ToString()).ToString("yyyy-MM-ddTHH:mm");

        }

        protected void btnUpdateRes_Click(object sender, EventArgs e)
        {
            int resID = Int32.Parse(lblHidden.Text);
            updateReservation(resID);
        }

        protected void updateReservation(int resID)
        {

            string resName = Request.Form["txtName"];
            int party = Int32.Parse(Request.Form["selectParty"]);
            DateTime resTime = DateTime.Parse(Request.Form["resDateTime"]);
            procedures.updateReservation(resID, userID, restName, resTime, party, resName);

            loadReservations();
            divManageReservations.Visible = true;
            reservation.Visible = false;
            reviewList.Visible = false;
        }

        protected void btnUpdateRest_Click(object sender, EventArgs e)
        {
            reviewList.Visible = false;
            updateform.Visible = true;
            inputRestName.Disabled = true;
        }

        protected void btnRestUpdate_Click(object sender, EventArgs e)
        {
            string desc = Request.Form["inputDescription"];
            string image = Request.Form["inputImage"];
            string cat = Request.Form["selectCategory"];

            procedures.updateRestaurant(restName, desc, userID, cat, image);

            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Remove("UserType");
            Session.Remove("UserID");
            Response.Redirect("Login.aspx");
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            Session.Remove("UserType");
            Session.Remove("UserID");
            Response.Redirect("Login.aspx");
        }
    }
}