using Microsoft.AspNetCore.Mvc;
using BabyShop.Models;
using System.Data.SqlClient;

namespace BabyShop.Controllers
{
    public class signupController : Controller
    {


        public IConfiguration _configuration;
        public string connectionString = "";
        public signupController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("connectString");
        }
        

        public IActionResult Index()
        {
            return View();
        }


        
        public IActionResult signup()
        {
            return View("signup", new Customers());
        }
        [HttpPost]
        public IActionResult enter(Customers cust)
        {

            if (ModelState.IsValid)
            {

           
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO Customers(id,username,email,password,phone) VALUES (@value1,@value2,@value4,@value5,@value7)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@value1", cust.id);
                        command.Parameters.AddWithValue("@value2", cust.username);
                        command.Parameters.AddWithValue("@value4", cust.email);
                        command.Parameters.AddWithValue("@value5", cust.password);
                        command.Parameters.AddWithValue("@value7", cust.phone);



                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            //insretion successfuly
                            return View("signup");
                        }
                        else
                        {
                            ViewBag.Message = "Failed to insert your data";
                            return View("signup", cust);
                        }

                    }

                

                

            }




            return View("signup");
        }





        public IActionResult Login()
        {
            return View("Login", new Customers());
        }

        [HttpPost]
       public IActionResult login( Customers cust) {



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Customers WHERE username=@username AND password=@password";
                SqlCommand command = new SqlCommand(query, connection);
       
                command.Parameters.AddWithValue("@username", cust.username);
                command.Parameters.AddWithValue("@password", cust.password);
              

                int countof = (int)command.ExecuteNonQuery();
                if (countof > 0)
                {
                    //insretion successfuly
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.Message = "Failed to find your username";
                    return View("Login");
                }

            }


            



        }
       


    }



}

