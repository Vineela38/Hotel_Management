using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelClientAPI.Models.Entities
{
    public class Bank
    {
        [Required(ErrorMessage ="*")]
        public string? bankid{set;get;}
        
         [Required(ErrorMessage ="*")]
        public string? bankname{set;get;}
    }
}