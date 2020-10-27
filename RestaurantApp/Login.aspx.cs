using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace RestaurantApp
{
    public partial class Login : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
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

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "ValidateLogin";
                SqlParameter userID = new SqlParameter("@userID", username);
                userID.Direction = System.Data.ParameterDirection.Input;
                userID.SqlDbType = System.Data.SqlDbType.VarChar;
                userID.Size = 50;
                objCommand.Parameters.Add(userID);

                SqlParameter userType = new SqlParameter("@userType", type);
                userType.Direction = System.Data.ParameterDirection.Input;
                userType.SqlDbType = System.Data.SqlDbType.VarChar;
                userType.Size = 50;
                objCommand.Parameters.Add(userType);

                DataSet returnVal = objDB.GetDataSetUsingCmdObj(objCommand);
                int value = Int32.Parse(returnVal.Tables[0].Rows[0][0].ToString());

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