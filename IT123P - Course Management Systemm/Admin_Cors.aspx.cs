using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

using System.Data;

namespace IT123P___Course_Management_Systemm
{
    public partial class Admin_Cors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/CMVMAS.mdb");

            using (OleDbConnection conn = new OleDbConnection(connstr))
            {
                conn.Open();

                string retrieve = "select * from Courses";

                OleDbDataAdapter da = new OleDbDataAdapter(retrieve, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                courseGV.DataSource = dt;
                courseGV.DataBind();

                conn.Close();
            }
        }

        public void CourseGenerateGV()
        {

        }

        protected void addCors_Click(object sender, EventArgs e)
        {
            string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/CMVMAS.mdb");
            string cCode = corsCode.Text.Trim();
            string cTitle = corsTitle.Text.Trim();
            string cUnit = corsUnits.Text.Trim();
            using (OleDbConnection conn = new OleDbConnection(connstr))
            {
                conn.Open();

                string retrieve = $"select CourseID from Courses where CourseID = '{cCode}'";

                OleDbCommand cmd = new OleDbCommand(retrieve, conn);
                OleDbDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    string insert = $"insert into Courses values ('{cCode}','{cTitle}','{cUnit}')";
                    cmd = new OleDbCommand(insert, conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}