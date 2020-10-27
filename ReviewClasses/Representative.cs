using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ReviewClasses
{
    public class Representative
    {
        string repID;
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        public Representative(string ID)
        {
            this.repID = ID;
            addRepToDatabase();
        }

        public void addRepToDatabase()
        {
            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "AddAccount";
            SqlParameter userID = new SqlParameter("@userID", repID);
            userID.Direction = System.Data.ParameterDirection.Input;
            userID.SqlDbType = System.Data.SqlDbType.VarChar;
            userID.Size = 50;
            objCommand.Parameters.Add(userID);

            SqlParameter userType = new SqlParameter("@userType", "Representative");
            userType.Direction = System.Data.ParameterDirection.Input;
            userType.SqlDbType = System.Data.SqlDbType.VarChar;
            userType.Size = 50;
            objCommand.Parameters.Add(userType);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }
    }
}
