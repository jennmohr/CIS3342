using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using ReviewClasses;
using System.Data.SqlClient;
using System.Data;

namespace RestaurantApp
{
    public partial class NewAccount : System.Web.UI.Page
    {

        SQLHandler procedures = new SQLHandler();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string type = Request.Form["selectType"];


            if(type == "Reviewer")
            {
                string username = Request.Form["inputUsername"];

                if (checkUnique(username))
                {
                    Reviewer newUser = new Reviewer(username);
                    Server.Transfer("Login.aspx");
                }
                else
                {
                    lblValidation.Text = "Username is already in use.";
                }
                
            }
            else
            {
                string username = Request.Form["inputUsername"];

                if (checkUnique(username))
                {
                    Representative newUser = new Representative(username);
                    Server.Transfer("Login.aspx");
                }
                else
                {
                    lblValidation.Text = "Username is already in use.";
                }
                
            }
            
            
        }

        public bool checkUnique(string username)
        {
            int value = procedures.uniqueUserValidation(username);

            if (value == 1)
                return false;
            else
                return true;
        }
    }
}