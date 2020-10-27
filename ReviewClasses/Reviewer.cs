using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

// Can view reviews
// Create new reviews
// Modify existing reviews
// Make reservations

namespace ReviewClasses
{
    public class Reviewer
    {

        string revID;
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        public Reviewer(string ID)
        {
            this.revID = ID;
            addUserToDatabase();
        }

        public void addUserToDatabase()
        {
            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "AddAccount";
            SqlParameter userID = new SqlParameter("@userID", revID);
            userID.Direction = System.Data.ParameterDirection.Input;
            userID.SqlDbType = System.Data.SqlDbType.VarChar;
            userID.Size = 50;
            objCommand.Parameters.Add(userID);

            SqlParameter userType = new SqlParameter("@userType", "Reviewer");
            userType.Direction = System.Data.ParameterDirection.Input;
            userType.SqlDbType = System.Data.SqlDbType.VarChar;
            userType.Size = 50;
            objCommand.Parameters.Add(userType);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

    }
}
