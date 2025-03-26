using System.ComponentModel.DataAnnotations;

namespace HotelClientAPI.Models.Entities
{
  public class SignUp
  {
    [Required(ErrorMessage = "Enter CustomerName")]
    [StringLength(25, ErrorMessage = "Name Must be max 25 char")]
    [MinLength(length: 3, ErrorMessage = "Name must be 3 char")]

    public string CustomerName { set; get; }


    [Required(ErrorMessage = "Enter Email")]
    [EmailAddress(ErrorMessage = "Invalid Format")]
    [RegularExpression(pattern: "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$")]

    public string Email { get; set; }



    [Required(ErrorMessage = "Enter validate Password")]
    [RegularExpression(pattern: @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()])[A-Za-z\d!@#$%^&*()]{8,20}$")]

    public string Password { get; set; }

    [Required(ErrorMessage = "Enter  Confirm  Password")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Enter  DOB")]
    [Range(typeof(DateTime), "01/01/1950", "01/01/2024", ErrorMessage = "Date Not in  DOB range")]

    public DateTime DOB { get; set; }


    [Required(ErrorMessage = "Enter Mobile Number")]
    [MaxLength(10, ErrorMessage = "Check your Digits")]
    public string MobileNo { get; set; }


    [Required(ErrorMessage = "Enter Your Country")]
    public string Country { get; set; }


    [Required(ErrorMessage = "Enter Your City")]
    public string City { get; set; }

    [Required(ErrorMessage = "Enter valid Pincode")]
    [MaxLength(6,ErrorMessage ="Check your Digits")]
    public string Pincode { set; get; }
  }
}