using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ReviewClasses
{
    public class Restaurant
    {
        string restName;
        string description;
        string category;
        string imageURL;
        string repID;
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        public Restaurant(string restName, string description, string category, string imageURL, string repID)
        {
            this.restName = restName;
            this.description = description;
            this.category = category;
            this.imageURL = imageURL;
            this.repID = repID;
            addRestToDatabase();
        }

        public void addRestToDatabase()
        {
            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "AddRestaurant";

            SqlParameter name = new SqlParameter("@restName", restName);
            name.Direction = System.Data.ParameterDirection.Input;
            name.SqlDbType = System.Data.SqlDbType.VarChar;
            name.Size = 50;
            objCommand.Parameters.Add(name);

            SqlParameter desc = new SqlParameter("@description", description);
            desc.Direction = System.Data.ParameterDirection.Input;
            desc.SqlDbType = System.Data.SqlDbType.VarChar;
            desc.Size = -1;
            objCommand.Parameters.Add(desc);

            SqlParameter restCategory = new SqlParameter("@category", category);
            restCategory.Direction = System.Data.ParameterDirection.Input;
            restCategory.SqlDbType = System.Data.SqlDbType.VarChar;
            restCategory.Size = 50;
            objCommand.Parameters.Add(restCategory);

            SqlParameter image = new SqlParameter("@imageURL", imageURL);
            image.Direction = System.Data.ParameterDirection.Input;
            image.SqlDbType = System.Data.SqlDbType.VarChar;
            image.Size = -1;
            objCommand.Parameters.Add(image);

            SqlParameter rep = new SqlParameter("@representative", repID);
            rep.Direction = System.Data.ParameterDirection.Input;
            rep.SqlDbType = System.Data.SqlDbType.VarChar;
            rep.Size = 50;
            objCommand.Parameters.Add(rep);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }
    }
}
