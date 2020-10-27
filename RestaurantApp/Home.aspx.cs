using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace RestaurantApp
{
    public partial class Home : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();


        protected void Page_Load(object sender, EventArgs e)
        {

            string userType = Session["UserType"].ToString();

            if(userType != "Reviewer" && userType != "Representative")
            {
                btnNewRestaurant.Visible = false;
                btnLogOut.Visible = false;
                btnLogIn.Visible = true;
            }
            else
            {
                btnNewRestaurant.Visible = true;
                btnLogOut.Visible = true;
                btnLogIn.Visible = false;
            }

            if(userType == "Representative")
            {
                btnNewRestaurant.Text = "Add New Restaurant/Represent Restaurant";
            }

            if (!IsPostBack)
            {
                SqlCommand getRest = new SqlCommand();
                getRest.CommandType = System.Data.CommandType.StoredProcedure;
                getRest.CommandText = "GetAllRestaurants";
                gvHome.DataSource = objDB.GetDataSetUsingCmdObj(getRest);
                gvHome.DataBind();

            }
        }

        protected void gvHome_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            String restName = gvHome.Rows[rowIndex].Cells[2].Text;

            Response.Redirect("RestaurantPage.aspx?Id=" + restName);
        }

        protected void checkFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet restaurants = new DataSet();
            int count = 0;

            foreach (ListItem item in checkFilter.Items)
            {
                if (item.Selected)
                {
                    count++;
                    string category = item.Value;
                    SqlCommand objCommand = new SqlCommand();

                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.CommandText = "FilterRestaurants";
                    SqlParameter cat = new SqlParameter("@category", category);
                    cat.Direction = System.Data.ParameterDirection.Input;
                    cat.SqlDbType = System.Data.SqlDbType.VarChar;
                    cat.Size = 50;
                    objCommand.Parameters.Add(cat);

                    DataSet rests = objDB.GetDataSetUsingCmdObj(objCommand);
                    restaurants.Merge(rests);
                }
            }


            if(count == 0)
            {
                String strSQL = "SELECT * FROM Restaurants ORDER BY RestName ASC";

                gvHome.DataSource = objDB.GetDataSet(strSQL);
                gvHome.DataBind();
            }
            else
            {
                gvHome.DataSource = restaurants;
                gvHome.DataBind();
            }


        }

        protected void btnNewRestaurant_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewRestaurant.aspx");
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