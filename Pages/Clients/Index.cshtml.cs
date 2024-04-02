using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace CRUD_Operation.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<clientInfo> listClients = new List<clientInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = " ";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM clients";
                    using(SqlCommand command = new SqlCommand(sql, connection))
                    {
                        while (reader.Read())
                        {
                            clientInfo clientInfo = new clientInfo();
                            clientInfo.id = "" + reader.GetInt32(0);
                            clientInfo.Name = reader.GetString(1);
                            clientInfo.Email = reader.GetString(2);
                            clientInfo.Phone = reader.GetString(3);
                            clientInfo.Address = reader.GetString(4);
                            clientInfo.Created_at = reader.GetDateTime(5).ToString();

                            listClients.Add(clientInfo);
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
}

public class clientInfo
{
    public String Name { get; set; }
    public String Email { get; set; }
    public String Phone { get; set; }
    public String Address { get; set; }
    public String Created_at { get; set; }
}