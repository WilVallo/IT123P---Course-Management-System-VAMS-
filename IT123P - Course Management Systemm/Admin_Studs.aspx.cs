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
    public partial class Admin_AddStudent : System.Web.UI.Page
    {
        private Administrator admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/CMVMAS.mdb");
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
                string retrieve = "select count(studID) from student";

                conn.Open();

                OleDbCommand cmd = new OleDbCommand(retrieve, conn);
                int count = (int)cmd.ExecuteScalar();
                count += 1;

                studID.Text = DateTime.Now.Year.ToString() + count.ToString("D8");

                conn.Close();
            }
            GenerateGridView();
        }

        public void GenerateGridView()
        {
            string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/CMVMAS.mdb");
            studentTable.DataSource = null;
            studentTable.DataBind();

            using (OleDbConnection conn = new OleDbConnection(connstr))
            {
                string retrieve = "select * from Student";

                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(retrieve, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                studentTable.DataSource = dt;
                studentTable.DataBind();
                conn.Close();
            }
        }

        public void ClearTextFields()
        {
            studID.Text = "";
            fname.Text = "";
            lname.Text = "";
            email.Text = "";
        }

        protected void confirm_Click(object sender, EventArgs e)
        {
            string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/CMVMAS.mdb");
            using (OleDbConnection conn = new OleDbConnection(connstr))
            {
                string id, first, last, em;
                id = studID.Text.Trim();
                first = fname.Text.Trim();
                last = lname.Text.Trim();
                em = email.Text.Trim();

                string insert = $"insert into student values ('{id}','{first}','{last}','{em}')";

                conn.Open();

                OleDbCommand cmd = new OleDbCommand(insert, conn);
                cmd.ExecuteNonQuery();

                insert = $"insert into accounts values('{id}','school@2025','B')";
                cmd = new OleDbCommand(insert, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            ClearTextFields();
            LoadData();
        }


        protected void clear_Click(object sender, EventArgs e)
        {
            ClearTextFields();
            LoadData();
            GenerateGridView();
            delete.Enabled = false;
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            string connstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/CMVMAS.mdb");

            using (OleDbConnection conn = new OleDbConnection(connstr))
            {
                string deleteQuery = $"DELETE FROM Accounts WHERE AccID = '{studID.Text}'";

                OleDbCommand cmd = new OleDbCommand(deleteQuery, conn);
                conn.Open();
                cmd.ExecuteNonQuery();

                deleteQuery = $"DELETE FROM Student WHERE StudID = '{studID.Text}'";

                cmd = new OleDbCommand(deleteQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            delete.Enabled = false;
            ClearTextFields();
            GenerateGridView();
            LoadData();
        }
        protected void studentTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = studentTable.SelectedIndex;

            if (selectedIndex == -1)
            {
                return;
            }
            studID.Text = studentTable.DataKeys[selectedIndex].Values["StudID"].ToString();
            fname.Text = studentTable.DataKeys[selectedIndex].Values["Stud_fname"].ToString();
            lname.Text = studentTable.DataKeys[selectedIndex].Values["Stud_lname"].ToString();
            email.Text = studentTable.DataKeys[selectedIndex].Values["Email"].ToString();

            delete.Enabled = true;
        }

        protected void delete_Click1(object sender, EventArgs e)
        {

        }
    }
}