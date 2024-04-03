using System.ComponentModel.DataAnnotations;

namespace BabyShop.Models
{
    public class Customers
    {

        

        [Key]
        [Required(ErrorMessage = "Error")]
        public string id { get; set; }

        
        [Required(ErrorMessage = "User Name is required")]
        [Display(Name = "User Name")]
        public string username { get; set; }



        
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }



       
        //[Required(ErrorMessage = "Please confirm your password")]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //[Display(Name = "Confirm Password")]
        //public string repassword { get; set; }




        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }




        [Required(ErrorMessage = "Phone number is required")]
        //[RegularExpression(@"^(\+[0-9]{9})$", ErrorMessage = "Invalid Phone number")]
        public string phone { get; set; }





        public Customers()
        {
            id = "";
            username = "";
            email = "";
            password = "";
       
            phone = "";
        }

        public Customers(string ID, string Username,  string email, string password,  string phone)
        {
            id = ID;
            username = Username;
            this.email = email;
            this.password = password;      
            this.phone = phone;
        }

    }

}

