using System.ComponentModel.DataAnnotations;

namespace HotelClientAPI.Models.Entities
{
    public class Login
    {

    private string email;
    private string password;
    private string? usertype;

        

        public Login() { 
        
    }

        public Login(string email, string password, string? usertype)
        {
            this.Email = email;
            this.Password = password;
            this.Usertype = usertype;
        }

        [Key]
        [Required(ErrorMessage = "Enter a valid  Email")]
        [RegularExpression(pattern: "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$")]
        
        public string Email { get => email; set => email = value; }
        
        

        [Required(ErrorMessage = "Enter a validate Password")]
        [RegularExpression(pattern: @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()])[A-Za-z\d!@#$%^&*()]{8,20}$")]
        
        public string Password { get => password; set => password = value; }

        [Required(ErrorMessage = "Select UserType")]

        public string? Usertype { get => usertype; set => usertype = value; }
        
    }
}