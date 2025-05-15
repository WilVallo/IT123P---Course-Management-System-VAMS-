using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace IT123P___Course_Management_Systemm
{
    public partial class Admin_Home : System.Web.UI.Page
    {
        string connstr = "Provider=Microsoft.Jet.Oledb.4.0; Data Source:";
        protected void Page_Load(object sender, EventArgs e)
        {
            connstr += Server.MapPath("~/App_Data/CMVMAS.mdb");

        }
    }
}