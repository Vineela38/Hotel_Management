using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management.Models.ENTITY
{
    [Table(name: "SignUp_15")]
    public class SignUp
    {

        public string CustomerName { get; set; }

        [Key]
        public string Email { get; set; }

        [NotMapped]//data is not stored in db
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public DateTime DOB { get; set; }

        
        public string MobileNo { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Pincode { set; get; }




    }
}