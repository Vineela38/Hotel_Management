using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelClientAPI.Models.Entities
{

        public class HotelBooking
        {
                public string? bookingId { set; get; }

                [Required(ErrorMessage = "Enter hotelid")]

                public string hotelId { set; get; }
                [Required(ErrorMessage = "*")]
                [EmailAddress(ErrorMessage = "Enter a valid email address")]

                public string emailID { set; get; }
                [Required(ErrorMessage = "Enter BookingDate")]
                public DateTime bookingDate { set; get; }
                [Required(ErrorMessage = "Enter Arrival Date")]
                [CustomDateValidation(ErrorMessage = "Arrival date must not be earlier than the current date.")]
                public DateTime arrivalDate { set; get; }
                [Required(ErrorMessage = "Enter Departure Date")]
                [CustomDateValidation(ErrorMessage = "Departure date must be after the arrival date.")]
                public DateTime departureDate { set; get; }


                [Required(ErrorMessage = "Enter Number of Adults")]
                [Range(1, int.MaxValue, ErrorMessage = "*")]

                public int noOfAdults { set; get; }
                [Required(ErrorMessage = "Enter Number of Children")]
                [Range(0, int.MaxValue, ErrorMessage = "Number of children cannot be negative")]

                public int noOfchild { set; get; }
                [Required(ErrorMessage = "Enter Number of Days")]
                [Range(1, int.MaxValue, ErrorMessage = "*")]

                public int noOfDays { set; get; }
                [Required(ErrorMessage = "*")]

                public string roomType { set; get; }

        }

        // Custom validation attributes for dates
        public class CustomDateValidation : ValidationAttribute
        {
                protected override ValidationResult IsValid(object value, ValidationContext validationContext)
                {
                        var hotelBooking = (HotelBooking)validationContext.ObjectInstance;
                        DateTime bookingDate = hotelBooking.bookingDate;

                        if (value != null && value is DateTime dateValue)
                        {
                                if (validationContext.MemberName == "arrivalDate" && dateValue.Date < DateTime.Today)
                                {
                                        return new ValidationResult(ErrorMessage);
                                }

                                if (validationContext.MemberName == "departureDate" && dateValue.Date <= hotelBooking.arrivalDate.Date)
                                {
                                        return new ValidationResult(ErrorMessage);
                                }
                        }
                        return ValidationResult.Success;
                }
        }
}

