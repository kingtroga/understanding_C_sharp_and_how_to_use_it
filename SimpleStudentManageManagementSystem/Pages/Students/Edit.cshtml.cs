using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace SimpleStudentManageManagementSystem.Pages.Students
{
    public class EditModel : PageModel
    {
        public StudentInfo studentInfo = new StudentInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
            string id = Request.Query["id"];

            try
            {
                string connectionString = "Data Source=localhost;Intial Catalog=students;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                studentInfo.id = "" + reader.GetInt32(0);
                                studentInfo.name = reader.GetString(1);
                                studentInfo.matric_no = reader.GetString(2);
                                studentInfo.level = reader.GetString(3);
                                studentInfo.program = reader.GetString(4);
                                studentInfo.department = reader.GetString(5);
                                studentInfo.college = reader.GetString(6);
                                studentInfo.date_added = reader.GetString(7);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        public void OnPost()
        {
            studentInfo.name = Request.Form["name"];
            studentInfo.matric_no = Request.Form["matric_no"];
            studentInfo.level = Request.Form["level"];
            studentInfo.program = Request.Form["program"];
            studentInfo.department = Request.Form["department"];
            studentInfo.college = Request.Form["college"];

            if (
                studentInfo.name.Length == 0 || studentInfo.matric_no.Length == 0 ||
                studentInfo.level.Length == 0 || studentInfo.program.Length == 0 ||
                studentInfo.department.Length == 0 || studentInfo.college.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }


            try
            {
                string connectionString = "Data Source=localhost;Intial Catalog=laptop-bag28bdg.master.dbo;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE clients " +
                                 "SET name=@name, matric_no=@matric_no, level=@level, program=@program, department=@department, college=@college" +
                                 "WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", studentInfo.name);
                        command.Parameters.AddWithValue("@matric_no", studentInfo.matric_no);
                        command.Parameters.AddWithValue("@level", studentInfo.level);
                        command.Parameters.AddWithValue("@program", studentInfo.program);
                        command.Parameters.AddWithValue("@department", studentInfo.department);
                        command.Parameters.AddWithValue("@college", studentInfo.college);
                        command.Parameters.AddWithValue("@id", studentInfo.id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }
    }
}
