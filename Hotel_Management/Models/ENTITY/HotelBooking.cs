using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models.ENTITY
{
    [Table(name:"HotelBookingtbl45")]
    public class HotelBooking
    {
        [Key]
        public string BookingId{set;get;}
        [ForeignKey("HotelId")]
       public string HotelId{set;get;}
        [ForeignKey("EmailID")]
       public string EmailID{set;get;}

       public DateTime BookingDate{set;get;}=DateTime.Now;

      public DateTime ArrivalDate{set;get;}

       public DateTime DepartureDate{set;get;}

 
        public int NoOfAdults{set;get;}

 
       public int NoOfchild{set;get;}

       public int NoOfDays{set;get;}

       public string? RoomType{set;get;}
 
    }
    
}