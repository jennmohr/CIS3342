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

        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            string userType = Session["UserType"].ToString();

            if (userType == "Reviewer")
            {
                divAddRep.Visible = false;
            }else if(userType == "Representative")
            {
                divAddRep.Visible = true;
                showData();

            }
            else
            {
                divAddRest.Visible = false;
                lblAlert.Text = "You do not have access to this page. Please login to add restaurant.";
            }

        }

        protected void showData()
        {

            SqlCommand noRepCommand = new SqlCommand();
            noRepCommand.CommandType = System.Data.CommandType.StoredProcedure;
            noRepCommand.CommandText = "GetRestNoReps";
            gvRep.DataSource = objDB.GetDataSetUsingCmdObj(noRepCommand);
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

                Restaurant newRest = new Restaurant(restName, description, category, imageURL, rep);
                Server.Transfer("Home.aspx");
            }
            else if(userType == "Representative")
            {
                string restName = Request.Form["inputRestName"];
                string description = Request.Form["inputDescription"];
                string category = Request.Form["selectCategory"];
                string imageURL = Request.Form["inputImage"];
                string rep = Session["UserID"].ToString();

                Restaurant newRest = new Restaurant(restName, description, category, imageURL, rep);
                Server.Transfer("Home.aspx");
            }
        }

        protected void gvRep_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String representative = Session["UserID"].ToString();
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            String restName = gvRep.Rows[rowIndex].Cells[1].Text;


            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "AddReptoRest";
            SqlParameter rep = new SqlParameter("@Representative", representative);
            rep.Direction = System.Data.ParameterDirection.Input;
            rep.SqlDbType = System.Data.SqlDbType.VarChar;
            rep.Size = 50;
            objCommand.Parameters.Add(rep);

            SqlParameter name = new SqlParameter("@RestName", restName);
            name.Direction = System.Data.ParameterDirection.Input;
            name.SqlDbType = System.Data.SqlDbType.VarChar;
            name.Size = 50;
            objCommand.Parameters.Add(name);

            objDB.DoUpdateUsingCmdObj(objCommand);
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