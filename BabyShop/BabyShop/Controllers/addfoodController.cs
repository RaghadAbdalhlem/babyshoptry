using Microsoft.AspNetCore.Mvc;
using BabyShop.Models;
using System.Data.SqlClient;
namespace BabyShop.Controllers
{
    public class addfoodController : Controller
    {
        public IConfiguration _configuration;
        public string connectionString = "";
        public addfoodController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("connectString");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult homepageadd()
        {
            return View("homepageadd");
        }

        public IActionResult addfood()
        {
            return View("addfood", new babyfood());
        }


        [HttpPost]
        public IActionResult enterfood(babyfood food)
        {

            if (ModelState.IsValid)
            {


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Babyfood(id,name,price,amount,age,img) VALUES (@value1,@value2,@value4,@value5,@value7,@value8)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@value1", food.id);
                    command.Parameters.AddWithValue("@value2", food.name);
                    command.Parameters.AddWithValue("@value4", food.price);
                    command.Parameters.AddWithValue("@value5", food.amount);
                    command.Parameters.AddWithValue("@value7", food.age);
                    command.Parameters.AddWithValue("@value8", food.img);



                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        //insretion successfuly
                        return View("homepageadd");
                    }
                    else
                    {
                        ViewBag.Message = "Failed to insert your data";
                        return View("addfood", food);
                    }

                }





            }




            return View("addfood");
        }




    }
}

