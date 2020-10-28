using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using System.Data;
using ReviewClasses;

namespace RestaurantApp
{
    public partial class Login : System.Web.UI.Page
    {

        SQLHandler procedures = new SQLHandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Add("UserType", null);
                Session.Add("UserID", null);
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            string username = Request.Form["inputUsername"];
            string type = Request.Form["selectType"];

            if (username == "")
            {
                lblValidation.Text = "Must enter a username!";
            }
            else
            {
                int value = procedures.loginValidation(username, type);

                if (value == 1)
                {
                    Session["UserType"] = type;
                    Session["UserID"] = username;
                    Server.Transfer("Home.aspx");
                }
                else
                {
                    lblValidation.Text = "Invalid Login.";
                }

            }
        }

        protected void btnGuest_Click(object sender, EventArgs e)
        {
            Session["UserType"] = "Guest";
            Session["UserID"] = null;

            Server.Transfer("Home.aspx");
        }

        protected void btnNewAccount_Click(object sender, EventArgs e)
        {
            Server.Transfer("NewAccount.aspx");
        }
    }
}