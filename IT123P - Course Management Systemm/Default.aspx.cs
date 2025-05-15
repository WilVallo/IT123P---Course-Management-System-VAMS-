using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace IT123P___Course_Management_Systemm
{
    public partial class Default : System.Web.UI.Page
    {
        string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
        protected void Page_Load(object sender, EventArgs e)
        {
            connstr += Server.MapPath("~/App_Data/CMVMAS.mdb");
        }

        protected void login_id_Click(object sender, EventArgs e)
        {
            string uname, pword;

            uname = unameTB.Text.Trim();
            pword = pwordTB.Text.Trim();

            string query = $"select accType from accounts where accID = '{uname}' and password = '{pword}'";

            OleDbConnection conn = new OleDbConnection(connstr);

            conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if (reader["accType"].ToString().Trim() == "A")
                {
                    Response.Redirect("Admin_Home.aspx");
                    Session["ID"] = reader["accID"].ToString().Trim();
                }
                else if (reader["accType"].ToString().Trim() == "B")
                {
                    Response.Redirect(".aspx");
                    Session["ID"] = reader["accID"].ToString().Trim();
                }
                else
                {
                    Response.Redirect(".aspx");
                    Session["ID"] = reader["accID"].ToString().Trim();
                }
            }
            conn.Close();
        }
    }
}