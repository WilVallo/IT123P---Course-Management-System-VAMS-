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
        string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
        protected void Page_Load(object sender, EventArgs e)
        {
            connstr += Server.MapPath("~/App_Data/CMVMAS.mdb");
            LoadData();
        }

        public void LoadData()
        {
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
            studentTable.DataSource = null;
            studentTable.DataBind();

            if (!IsPostBack)
            {
                using (OleDbConnection conn = new OleDbConnection(connstr))
                {
                    string retrieve = "select * from Student";
                    OleDbDataAdapter da = new OleDbDataAdapter(retrieve, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    studentTable.DataSource = dt;
                    studentTable.DataBind();
                }
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
            GenerateGridView();
            ClearTextFields();
        }

        protected void studentTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (studentTable.SelectedRow != null)
            {
                studID.Text = studentTable.SelectedRow.Cells[1].Text;
                fname.Text = studentTable.SelectedRow.Cells[2].Text;
                lname.Text = studentTable.SelectedRow.Cells[3].Text;
                email.Text = studentTable.SelectedRow.Cells[4].Text;
            }
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            ClearTextFields();
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connstr))
            {
                string delete = $"delete from Accounts where AccID = '{studID.Text}'";

                conn.Open();
                OleDbCommand cmd = new OleDbCommand(delete, conn);
                cmd.ExecuteNonQuery();

                delete = $"delete from Student where StudID = '{studID.Text}'";
                cmd = new OleDbCommand(delete, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }
    }
}