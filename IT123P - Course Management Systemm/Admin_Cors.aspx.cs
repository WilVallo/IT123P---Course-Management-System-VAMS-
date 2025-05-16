using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            courseGV.DataSource = null;
            courseGV.DataBind();

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

        public void ClearAddCors()
        {
            corsCode.Text = "";
            corsTitle.Text = "";
            corsUnits.Text = "";
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
            ClearAddCors();
        }

        protected void courseGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/CMVMAS.mdb");
            courseGV.DataSource = null;
            courseGV.DataBind();

            using (OleDbConnection conn = new OleDbConnection(connstr))
            {
                string retrieve = "select * from Courses";

                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(retrieve, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                courseGV.DataSource = dt;
                courseGV.DataBind();
                conn.Close();
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            string connstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/CMVMAS.mdb");

            using (OleDbConnection conn = new OleDbConnection(connstr))
            {
                string deleteQuery = $"DELETE FROM Accounts WHERE AccID = '{corsCode.Text}'";

                OleDbCommand cmd = new OleDbCommand(deleteQuery, conn);
                conn.Open();
                cmd.ExecuteNonQuery();

                deleteQuery = $"DELETE FROM Student WHERE StudID = '{corsCode.Text}'";

                cmd = new OleDbCommand(deleteQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            btnDelete.Enabled = false;
            ClearAddCors();
            LoadData();
        }
    }
}