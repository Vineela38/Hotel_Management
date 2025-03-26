using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hotel_Management.Data;

namespace Hotel_Management.Models.ENTITY
{
    [Table(name: "Login_15")]
    public class Login
    {
        string email;
        string password;
        string userType;
        private HotelDb context;

        public Login()
        {
        }

    
        public Login(string email, string password, string userType)
        {
            this.Email = email;
            this.Password = password;
            this.UserType = userType;
        }

        [Key]
        public string Email { get; set; }
        
        public string Password { get; set; }

        public string? UserType { get; set; }

    }
}