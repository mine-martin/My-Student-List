using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace Students_List.Pages.students
{
    public class IndexModel : PageModel
    {
        public List<StudentsInfo> listStudents = new List<StudentsInfo>(); 
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=students;Integrated Security=True";

                using (SqlConnection connection= new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * from students";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentsInfo studentsInfo= new StudentsInfo();
                                studentsInfo.id = "" + reader.GetInt32(0);
                                studentsInfo.name =  reader.GetString(1);
                                studentsInfo.email = reader.GetString(2);
                                studentsInfo.admission = reader.GetString(3);
                                studentsInfo.department = reader.GetString(4);
                                studentsInfo.address = "" + reader.GetString(5);
                                studentsInfo.created_at = reader.GetDateTime(6).ToString();

                                listStudents.Add(studentsInfo);

                            }
                        }
                    }
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Exception", ex.ToString());
            }
        }
    }
    public class StudentsInfo
    {
        public String? id;
        public String? name;
        public String? email;
        public String? admission;
        public String? department;
        public String? address;
        public String? created_at;
    }
}
