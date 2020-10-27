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

        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

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
            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "UsernameCheck";
            SqlParameter userID = new SqlParameter("@userID", username);
            userID.Direction = System.Data.ParameterDirection.Input;
            userID.SqlDbType = System.Data.SqlDbType.VarChar;
            userID.Size = 50;
            objCommand.Parameters.Add(userID);

            DataSet returnVal = objDB.GetDataSetUsingCmdObj(objCommand);
            int value = Int32.Parse(returnVal.Tables[0].Rows[0][0].ToString());

            if (value == 1)
                return false;
            else
                return true;
        }
    }
}