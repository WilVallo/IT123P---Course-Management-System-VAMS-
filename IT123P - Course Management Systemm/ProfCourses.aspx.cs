using System;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT123P___Course_Management_Systemm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";

        protected void Page_Init(object sender, EventArgs e)
        {
            connstr += Server.MapPath("~/App_Data/CMVMAS.mdb");

            if (Session["ID"] == null) return;
            string userID = Session["ID"].ToString();

            using (OleDbConnection conn = new OleDbConnection(connstr))
            {
                conn.Open();
                string query2 = $"SELECT CourseID, CourseSec, cName FROM CourseProctors WHERE profID = '{userID}'";
                OleDbCommand cmd2 = new OleDbCommand(query2, conn);
                OleDbDataReader reader2 = cmd2.ExecuteReader();

                int count = 0;
                while (reader2.Read())
                {
                    string courseID = reader2["CourseID"].ToString();
                    string courseSec = reader2["CourseSec"].ToString();
                    string cName = reader2["cName"].ToString();

                    Button courseButton = new Button();
                    courseButton.ID = "btnCourse" + count;
                    courseButton.Text = "Course " + (count + 1) + ": " + courseID + " - " + cName + "\n" + courseSec;
                    courseButton.CssClass = "course-button";
                    courseButton.Click += new EventHandler(DisplayInfo);
                    courseButton.CommandArgument = courseID + "|" + courseSec;

                    CourseButtonHolder.Controls.Add(courseButton);
                    CourseButtonHolder.Controls.Add(new Literal { Text = "<br /><br />" });

                    count++;
                }
                reader2.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ID"] == null) return;
                string userID = Session["ID"].ToString();

                string connstrWithPath = connstr;
                using (OleDbConnection conn = new OleDbConnection(connstrWithPath))
                {
                    conn.Open();

                    string query = $"SELECT Prof_fname, Prof_lname FROM Professor WHERE profID = '{userID}'";
                    OleDbCommand cmd1 = new OleDbCommand(query, conn);
                    OleDbDataReader reader1 = cmd1.ExecuteReader();

                    if (reader1.Read())
                    {
                        string fname = reader1["Prof_fname"].ToString();
                        string lname = reader1["Prof_lname"].ToString();
                        Label welcomeLabel = (Label)Master.FindControl("welcomeLabel");
                        if (welcomeLabel != null)
                        {
                            welcomeLabel.Text = "Welcome, Professor " + fname + " " + lname + "!";
                        }
                    }
                    reader1.Close();
                }
            }
        }

        protected void DisplayInfo(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] args = btn.CommandArgument.Split('|');
            if (args.Length < 2) return;

            string courseID = args[0];
            string courseSec = args[1];
            ViewState["CurrentCourse"] = courseID;
            ViewState["CurrentSec"] = courseSec;

            LoadStudentsTable(courseID, courseSec);
        }


        protected void SubmitGradesButton_Click(object sender, EventArgs e)
        {
            string courseID = ViewState["CurrentCourse"]?.ToString();
            string courseSec = ViewState["CurrentSec"]?.ToString();
            if (string.IsNullOrEmpty(courseID) || string.IsNullOrEmpty(courseSec)) return;

            foreach (Control ctrl in StudentsTableHolder.Controls)
            {
                if (ctrl is Table table)
                {
                    foreach (TableRow row in table.Rows)
                    {
                        if (row.Cells.Count == 2 && row.Cells[1].Controls[0] is TextBox gpaBox)
                        {
                            string textboxId = gpaBox.ID;
                            string studentId = textboxId.Replace("GPA_", "");
                            string grade = gpaBox.Text;

                            if (!string.IsNullOrWhiteSpace(grade))
                            {
                                GradeStudent(studentId, courseID, courseSec, grade);
                            }
                        }
                    }
                }
            }
        }

        private void GradeStudent(string studentId, string courseId, string courseSec, string grade)
        {
            string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/CMVMAS.mdb");

            using (OleDbConnection conn = new OleDbConnection(connstr))
            {
                conn.Open();
                string query = "UPDATE Student_Course SET GPA = ? WHERE StudId = ? AND CourseID = ? AND CourseSec = ?";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("?", grade);
                cmd.Parameters.AddWithValue("?", studentId);
                cmd.Parameters.AddWithValue("?", courseId);
                cmd.Parameters.AddWithValue("?", courseSec);

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        
                        Console.WriteLine($"No records updated for StudentId: {studentId}, CourseID: {courseId}, CourseSec: {courseSec}");
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("Error updating GPA: " + ex.Message);
                }
            }
        }
        private void LoadStudentsTable(string courseID, string courseSec)
        {
            string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/CMVMAS.mdb");

            using (OleDbConnection conn = new OleDbConnection(connstr))
            {
                conn.Open();

                string query = @"SELECT s.StudId, s.Stud_fname, s.Stud_lname 
                         FROM Student_Course sc
                         INNER JOIN Student s ON sc.StudId = s.StudId
                         WHERE sc.CourseID = ? AND sc.CourseSec = ?";

                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("?", courseID);
                cmd.Parameters.AddWithValue("?", courseSec);

                OleDbDataReader reader = cmd.ExecuteReader();

                Table table = new Table();
                table.CssClass = "student-table";

                Label courseInfoLabel = new Label();
                courseInfoLabel.Text = $"Students enrolled in {courseID} - {courseSec}<br/><br/>";

                StudentsTableHolder.Controls.Clear();
                StudentsTableHolder.Controls.Add(courseInfoLabel);

                while (reader.Read())
                {
                    string studentId = reader["StudId"].ToString();
                    string fullName = reader["Stud_fname"] + " " + reader["Stud_lname"];

                    TableRow row = new TableRow();

                    TableCell nameCell = new TableCell();
                    nameCell.Text = $"{fullName} ({studentId})";

                    TableCell gpaCell = new TableCell();
                    TextBox gpaBox = new TextBox();
                    gpaBox.ID = "GPA_" + studentId;
                    gpaBox.Attributes["placeholder"] = "Enter GPA";
                    gpaCell.Controls.Add(gpaBox);

                    row.Cells.Add(nameCell);
                    row.Cells.Add(gpaCell);
                    table.Rows.Add(row);
                }

                StudentsTableHolder.Controls.Add(table);
            }
        }

    }
}
