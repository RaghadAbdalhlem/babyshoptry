using Microsoft.AspNetCore.Mvc;
using BabyShop.Models;
using System.Data.SqlClient;
namespace BabyShop.Controllers

{
    public class addtoolController : Controller
    {
        public IConfiguration _configuration;
        public string connectionString = "";
        public addtoolController(IConfiguration configuration)
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

        public IActionResult addtool()
        {
            return View("addtool", new babytools());
        }


        [HttpPost]
        public IActionResult entertool(babytools tool)
        {

            if (ModelState.IsValid)
            {


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Babytools(id,name,price,amount,age,img) VALUES (@value1,@value2,@value4,@value5,@value7,@value8)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@value1", tool.id);
                    command.Parameters.AddWithValue("@value2", tool.name);
                    command.Parameters.AddWithValue("@value4", tool.price);
                    command.Parameters.AddWithValue("@value5", tool.amount);
                    command.Parameters.AddWithValue("@value7", tool.age);
                    command.Parameters.AddWithValue("@value8", tool.img);



                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        //insretion successfuly
                        return View("homepageadd");
                    }
                    else
                    {
                        ViewBag.Message = "Failed to insert your data";
                        return View("addtool", tool);
                    }

                }





            }




            return View("addtool");
        }




    }
}
