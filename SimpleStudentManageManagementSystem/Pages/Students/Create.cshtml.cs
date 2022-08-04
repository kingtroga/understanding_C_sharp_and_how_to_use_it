using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace SimpleStudentManageManagementSystem.Pages.Students
{
    public class CreateModel : PageModel
    {
        public StudentInfo studentInfo = new StudentInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
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
                studentInfo.name.Length == 0|| studentInfo.matric_no.Length == 0 ||
                studentInfo.level.Length == 0 || studentInfo.program.Length == 0 ||
                studentInfo.department.Length == 0 || studentInfo.college.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            // save the new client into the database
            try
            {
                string connectionString = "Data Source=localhost;Intial Catalog=students;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO students " +
                                 "(name, matric_no, level, program, department, college) VALUES " +
                                 "(@name, @matric_no, @level, @program, @department, @college);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", studentInfo.name);
                        command.Parameters.AddWithValue("@matric_no", studentInfo.matric_no);
                        command.Parameters.AddWithValue("@level", studentInfo.level);
                        command.Parameters.AddWithValue("@program", studentInfo.program);
                        command.Parameters.AddWithValue("@department", studentInfo.department);
                        command.Parameters.AddWithValue("@college", studentInfo.college);
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }




            studentInfo.name = ""; 
            studentInfo.matric_no = "";
            studentInfo.level = "";
            studentInfo.program = "";
            studentInfo.department = "";
            studentInfo.college = "";
            successMessage = "New Students Added Correctly";

            Response.Redirect("/Students/Index");
        }
    }
}
