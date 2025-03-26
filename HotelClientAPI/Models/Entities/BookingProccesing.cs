using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HotelClientAPI.Models.Entites;

namespace HotelClientAPI.Models.Entities
{
    public class BookingProccesing
    {
        public BookingProccesing(){
            hotelBooking=new HotelBooking();
            hotelPayment=new HotelPayment();
        }

        public HotelBooking hotelBooking{set;get;}
        public HotelPayment hotelPayment{set;get;}

        //HotelBooking

//                 [Key]
//                 [Required(ErrorMessage = "Enter Booking ID")]

//                 public string bookingId { set; get; }

//                 [Required(ErrorMessage = "Enter hotelid")]

//                 public string hotelId { set; get; }
//                 [Required(ErrorMessage = "*")]
//                 [EmailAddress(ErrorMessage = "Enter a valid email address")]

//                 public string emailID { set; get; }
//                 [Required(ErrorMessage = "Enter BookingDate")]
//                 public DateTime bookingDate { set; get; }
//                 [Required(ErrorMessage = "Enter Arrival Date")]
//                 [CustomDateValidation(ErrorMessage = "Arrival date must not be earlier than the current date.")]
//                 public DateTime arrivalDate { set; get; }
//                 [Required(ErrorMessage = "Enter Departure Date")]
//                 [CustomDateValidation(ErrorMessage = "Departure date must be after the arrival date.")]
//                 public DateTime departureDate { set; get; }


//                 [Required(ErrorMessage = "Enter Number of Adults")]
//                 [Range(1, int.MaxValue, ErrorMessage = "*")]

//                 public int noOfAdults { set; get; }
//                 [Required(ErrorMessage = "Enter Number of Children")]
//                 [Range(0, int.MaxValue, ErrorMessage = "Number of children cannot be negative")]

//                 public int noOfchild { set; get; }
//                 [Required(ErrorMessage = "Enter Number of Days")]
//                 [Range(1, int.MaxValue, ErrorMessage = "*")]

//                 public int noOfDays { set; get; }
//                 [Required(ErrorMessage = "*")]

//                 public string roomType { set; get; }

//         }

//         // Custom validation attributes for dates
//         public class Validation : ValidationAttribute
//         {
//                 protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//                 {
//                         var hotelBooking = (HotelBooking)validationContext.ObjectInstance;
//                         DateTime bookingDate = hotelBooking.bookingDate;

//                         if (value != null && value is DateTime dateValue)
//                         {
//                                 if (validationContext.MemberName == "ArrivalDate" && dateValue.Date < DateTime.Today)
//                                 {
//                                         return new ValidationResult(ErrorMessage);
//                                 }

//                                 if (validationContext.MemberName == "DepartureDate" && dateValue.Date <= hotelBooking.arrivalDate.Date)
//                                 {
//                                         return new ValidationResult(ErrorMessage);
//                                 }
//                         }
//                         return ValidationResult.Success;
//                 }

//         //Payment

//         public string? BookingId{get;set;}
//          //[Required(ErrorMessage ="*")]
//          //[Range(1,16,ErrorMessage ="Card Number Should not Exceed 16-Digits")]
//         public long Creditcardnumber { get ; set; }


//         //[Required(ErrorMessage ="*")]
//         public string Bankname{get;set;}


//         //[Required(ErrorMessage ="*")]
//         public string Cardtype { get; set ; }


//         //[Required(ErrorMessage ="*")]
//         //[StringLength(30,ErrorMessage ="Name on card should not exceed 30 characters")]
//         //[RegularExpression(pattern:"^[A-Z]{30}",ErrorMessage ="Name on card must allow only alphabets ")]
//         public string nameoncard { get; set ; }


//         //[Required(ErrorMessage ="*")]
//         public DateOnly Expirydate { get ; set ; }


//         //[Required(ErrorMessage ="*")]
//         //[Range(1,3,ErrorMessage ="Cvv must takes only 3-Digits")]
//         public int Cvv { get; set ; }


//         //[Required(ErrorMessage ="*")]
//         //[RegularExpression(@"^\d{4}(\d{2})?$", ErrorMessage = "PIN must be a 4 or 6 digit number")]
//         public int Pin { get ; set ; }
     }
}