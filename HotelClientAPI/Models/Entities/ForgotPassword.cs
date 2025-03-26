using System.ComponentModel.DataAnnotations;

namespace HotelClientAPI.Models.Entities
{
    public class ForgotPassword
    {
        public ForgotPassword()
        {
        }

        [Required(ErrorMessage = "Enter a valid  Email")]
        //[RegularExpression(pattern: "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$")]

        public string Email { get; set; }


        [Required(ErrorMessage = "Enter Mobile Number Mandatory")]
        //[MaxLength(10, ErrorMessage = "Check your Digits")]
        public string MobileNo { get; set; }


        //[Required(ErrorMessage = "Enter validate Password")]
       // [RegularExpression(pattern: @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()])[A-Za-z\d!@#$%^&*()]{8,20}$")]


        public string FPassword1 { get; set; }
        
    }

}