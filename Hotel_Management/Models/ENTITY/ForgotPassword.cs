using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management.Models.ENTITY
{
    [Table(name:"ForgotPassword_11")]
    public class ForgotPassword
    {
         string mobileNo;

         string email;

         string fPassword;

        public ForgotPassword()
        {
        }

        public ForgotPassword(string mobileNo, string email, string fPassword)
        {
            this.MobileNo = mobileNo;
            this.Email = email;
            FPassword1 = fPassword;
        }

        public string MobileNo { get => mobileNo; set => mobileNo = value; }
        [Key]
        public string Email { get => email; set => email = value; }
        public string FPassword1 { get => fPassword; set => fPassword = value; }
    }
}