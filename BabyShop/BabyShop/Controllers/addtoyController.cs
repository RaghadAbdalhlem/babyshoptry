using Microsoft.AspNetCore.Mvc;
using BabyShop.Models;
using System.Data.SqlClient;
namespace BabyShop.Controllers
    
{
    public class addtoyController : Controller
    {
        public IConfiguration _configuration;
        public string connectionString = "";
        public addtoyController(IConfiguration configuration)
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

        public IActionResult addtoy()
        {
           return View("addtoy", new babytoys());
        }


        [HttpPost]
        public IActionResult entertoy(babytoys toy)
        {

            if (ModelState.IsValid)
            {


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Babytoys(id,name,price,amount,age,img) VALUES (@value1,@value2,@value4,@value5,@value7,@value8)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@value1", toy.id);
                    command.Parameters.AddWithValue("@value2", toy.name);
                    command.Parameters.AddWithValue("@value4", toy.price);
                    command.Parameters.AddWithValue("@value5", toy.amount);
                    command.Parameters.AddWithValue("@value7", toy.age);
                    command.Parameters.AddWithValue("@value8", toy.img);



                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        //insretion successfuly
                        return View("homepageadd");
                    }
                    else
                    {
                        ViewBag.Message = "Failed to insert your data";
                        return View("addtoy", toy);
                    }

                }





            }




            return View("addtoy");
        }




    }
}
