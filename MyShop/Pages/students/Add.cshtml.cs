using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Students_List.Pages.students
{
    public class AddModel : PageModel
    {
        public StudentsInfo studentsInfo = new StudentsInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost() { 
        
            studentsInfo.name = Request.Form["name"];
            studentsInfo.email = Request.Form["email"];
            studentsInfo.admission = Request.Form["admission"];
            studentsInfo.department = Request.Form["department"];
            studentsInfo.address = Request.Form["address"];

            if (
                studentsInfo.name.Length == 0 ||
                studentsInfo.email.Length == 0 ||
                studentsInfo.admission.Length == 0 ||
                studentsInfo.department.Length == 0 ||
                studentsInfo.address.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }
            //save to database

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=students;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO students" +
                                    "(name, email, admission, department, address) VALUES" +
                                    "(@name, @email, @admission, @department, @address);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", studentsInfo.name);
                        command.Parameters.AddWithValue("@email", studentsInfo.email);
                        command.Parameters.AddWithValue("@admission", studentsInfo.admission);
                        command.Parameters.AddWithValue("@department", studentsInfo.department);
                        command.Parameters.AddWithValue("@address", studentsInfo.address);

                        command.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex) 
            {
                errorMessage = ex.Message;
                return;
            }

            studentsInfo.name = ""; studentsInfo.email = ""; studentsInfo.admission = "";
            studentsInfo.department = ""; studentsInfo.address = "";
            successMessage = "New Student Added Successfully";

            Response.Redirect("/students");
        }
    }
}
