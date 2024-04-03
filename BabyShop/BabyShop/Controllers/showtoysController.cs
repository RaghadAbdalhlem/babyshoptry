using Microsoft.AspNetCore.Mvc;
using BabyShop.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BabyShop.Controllers
{
    public class ShowToysController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ShowToysController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("connectString");
        }
       
        public IActionResult Index()
        {
            var toys = new List<babytoys>(); // Assuming babytoys is a class representing a single toy
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT id, name, price, amount, age, img FROM Babytoys";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var toy = new babytoys
                            {
                                id = reader["id"].ToString(),
                                name = reader["name"].ToString(),
                                price = reader["price"].ToString(),
                                amount = reader["amount"].ToString(),
                                age = reader["age"].ToString(),
                                img = reader["img"].ToString()
                            };
                            toys.Add(toy);
                        }
                    }
                }
            }
            return View(toys);
        }
       
        public IActionResult showtoys(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT id, name, price, amount, age, img FROM Babytoys WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var toy = new babytoys
                            {
                                id = reader["id"].ToString(),
                                name = reader["name"].ToString(),
                                price = reader["price"].ToString(),
                                amount = reader["amount"].ToString(),
                                age = reader["age"].ToString(),
                                img = reader["img"].ToString()
                            };
                            return View(toy);
                        }
                    }
                }
            }
            return NotFound(); // Return 404 if the toy with the specified ID is not found
        }
    }
}
