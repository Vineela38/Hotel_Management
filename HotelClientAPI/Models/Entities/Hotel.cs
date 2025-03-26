using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

namespace HotelClientAPI.Models.Entities
{
    public class Hotel
    {
        public Hotel()
        {
        }
        public string? hotelId { get;set; }
        [Required(ErrorMessage ="Required")]
        [StringLength(30,ErrorMessage ="Min 3 chars")]
        [MinLength(length:3,ErrorMessage ="Min 3 chars")]
        [RegularExpression(pattern:"^[a-zA-Z0-9\\s]*$",ErrorMessage ="Invalid Format")]
        public string hotelName { get;set; }
        [Required(ErrorMessage ="Required")]
        [StringLength(150,ErrorMessage ="should not 150 characters")]
        public string description{get;set;}
        [Required(ErrorMessage ="Required")]
        public string area { get ; set ; }
        [Required(ErrorMessage ="Required")]
        public string state { get;set; }
        [Required(ErrorMessage ="Required")]
        public string city { get ;set; }
        [Required(ErrorMessage ="Required")]
        public string country { get ;set; }
        [Required(ErrorMessage ="Required")]
        [Range(1, 300, ErrorMessage = "Only between 1-300")]
        public Nullable<int> noOfACRooms { get ;set; }
        [Required(ErrorMessage ="Required")]
        [Range(2000, 3000, ErrorMessage = "Only between 2000-3000")]
        public double? costPerDay { get ;set; }
        [Required(ErrorMessage ="Required")]
        [Range(1, 300, ErrorMessage = "Only between 1-300")]
        public int? noOfNonACRooms { get ;set; }
        [Required(ErrorMessage ="Required")]
        [Range(1000, 2000, ErrorMessage = "Only between 1000-2000")]
        public double? costPerDayNonAc { get ;set; }
    }
}