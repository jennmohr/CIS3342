using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace TempleBookstore
{
    public partial class ManagementForm : System.Web.UI.Page
    {

        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String strSQL = "SELECT * FROM Books ORDER BY TotalSales DESC";
                gvBooks.DataSource = objDB.GetDataSet(strSQL);
                gvBooks.DataBind();

            }
        }
    }
}