using Microsoft.AspNetCore.Mvc;
using BabyShop.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BabyShop.Controllers
{
    public class showtoolsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public showtoolsController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("connectString");
        }

        public IActionResult Index()
        {
            var tools = new List<babytools>(); // Assuming babytoys is a class representing a single toy
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT id, name, price, amount, age, img FROM Babytools";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tool = new babytools
                            {
                                id = reader["id"].ToString(),
                                name = reader["name"].ToString(),
                                price = reader["price"].ToString(),
                                amount = reader["amount"].ToString(),
                                age = reader["age"].ToString(),
                                img = reader["img"].ToString()
                            };
                            tools.Add(tool);
                        }
                    }
                }
            }
            return View(tools);
        }

        public IActionResult showtools(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT id, name, price, amount, age, img FROM Babytools WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var tool = new babytools
                            {
                                id = reader["id"].ToString(),
                                name = reader["name"].ToString(),
                                price = reader["price"].ToString(),
                                amount = reader["amount"].ToString(),
                                age = reader["age"].ToString(),
                                img = reader["img"].ToString()
                            };
                            return View(tool);
                        }
                    }
                }
            }
            return NotFound(); // Return 404 if the toy with the specified ID is not found
        }
    }
}
