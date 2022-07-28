using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace SimpleStudentManageManagementSystem.Pages.Students
{
    public class IndexModel : PageModel
    {
        public List<StudentInfo> listStudents = new List<StudentInfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=localhost;Intial Catalog=laptop-bag28bdg.master.dbo;Integrated Security=True";

                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM students";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentInfo studentInfo = new StudentInfo();
                                studentInfo.id = "" + reader.GetInt32(0);
                                studentInfo.name = reader.GetString(1);
                                studentInfo.matric_no = reader.GetString(2);
                                studentInfo.level = reader.GetString(3);
                                studentInfo.program = reader.GetString(4);
                                studentInfo.department = reader.GetString(5);
                                studentInfo.college = reader.GetString(6);
                                studentInfo.date_added = reader.GetString(7);


                                listStudents.Add(studentInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class StudentInfo
    {
        public string id;
        public string name;
        public string matric_no;
        public string level;
        public string program;
        public string department;
        public string college;
        public string date_added;
    }
}
