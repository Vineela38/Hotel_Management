using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelClientAPI.Models.Entities
{
    public class HotelPayment
    {
         public string? BookingId{get;set;}
         [Required(ErrorMessage ="*")]
         //[Range(1,16,ErrorMessage ="Card Number Should not Exceed 16-Digits")]
        public long Creditcardnumber { get ; set; }


        [Required(ErrorMessage ="*")]
        public string Bankname{get;set;}


        [Required(ErrorMessage ="*")]
        public string Cardtype { get; set ; }


        [Required(ErrorMessage ="*")]
        //[StringLength(30,ErrorMessage ="Name on card should not exceed 30 characters")]
        //[RegularExpression(pattern:"^[A-Z]{30}",ErrorMessage ="Name on card must allow only alphabets ")]
        public string Nameoncard { get; set ; }
 

        [Required(ErrorMessage ="*")]
        public DateOnly Expirydate { get ; set ; }


        [Required(ErrorMessage ="*")]
        //[Range(1,3,ErrorMessage ="Cvv must takes only 3-Digits")]
        public int Cvv { get; set ; }


        [Required(ErrorMessage ="*")]
        //[RegularExpression(@"^\d{4}(\d{2})?$", ErrorMessage = "PIN must be a 4 or 6 digit number")]
        public int Pin { get ; set ; }

        
    }
}