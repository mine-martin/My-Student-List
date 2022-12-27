using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Students_List.Pages.students
{
    public class UpdateModel : PageModel
    {
        public StudentsInfo studentsInfo = new StudentsInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=students;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * from students WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                studentsInfo.id = "" + reader.GetInt32(0);
                                studentsInfo.name = reader.GetString(1);
                                studentsInfo.email = reader.GetString(2);
                                studentsInfo.admission = reader.GetString(3);
                                studentsInfo.department = reader.GetString(4);
                                studentsInfo.address =  reader.GetString(5);
                                
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost() 
        {
            studentsInfo.id = Request.Form["id"];
            studentsInfo.name = Request.Form["name"];
            studentsInfo.email = Request.Form["email"];
            studentsInfo.admission = Request.Form["admission"];
            studentsInfo.department = Request.Form["department"];
            studentsInfo.address = Request.Form["address"];


            if (
                studentsInfo.id.Length == 0 ||
                studentsInfo.name.Length == 0 ||
                studentsInfo.email.Length == 0 ||
                studentsInfo.admission.Length == 0 ||
                studentsInfo.department.Length == 0 ||
                studentsInfo.address.Length == 0)
            {
                errorMessage = "All fields are required";
                return;
            }

            try
            {

                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=students;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE students " +
                                    "SET name=@name, email=@email, admission=@admission, department=@department, address=@address  " +
                                    "WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", studentsInfo.name);
                        command.Parameters.AddWithValue("@email", studentsInfo.email);
                        command.Parameters.AddWithValue("@admission", studentsInfo.admission);
                        command.Parameters.AddWithValue("@department", studentsInfo.department);
                        command.Parameters.AddWithValue("@address", studentsInfo.address);
                        command.Parameters.AddWithValue("@id", studentsInfo.id);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/students");
        }
    }
}
