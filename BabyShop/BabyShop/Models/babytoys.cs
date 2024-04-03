

using System.ComponentModel.DataAnnotations;
namespace BabyShop.Models
{
    public class babytoys
    {
        [Key]
        [Required(ErrorMessage = "Error")]
        public string id { get; set; }




        [Required(ErrorMessage = "Error")]
        public string name { get; set; }




        [Required(ErrorMessage = "Error")]
        [Range(10, 200)]
        public string price { get; set; }



        [Required(ErrorMessage = "Error")]
        [Range(0, 4000)]
        public string amount { get; set; }




        [Required(ErrorMessage = "Error")]
        [Range(0, 5)]
        public string age { get; set; }

        [Required(ErrorMessage = "Error")]
        public string img { get; set; }



        public babytoys()
        {
            id = "";
            name = "";
            price = "";
            amount = "";
            age = "";
            img = "";
        }
        public babytoys(string ID, string Name, string Price, string Amount, string Age, string Img)
        {
            id = ID;
            name = Name;
            price = Price;
            amount = Amount;
            age = Age;
            img = Img;
        }

    }
}


