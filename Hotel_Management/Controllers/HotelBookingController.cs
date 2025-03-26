using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Management.Data;
using Hotel_Management.Models.BAO;
using Hotel_Management.Models.ENTITY;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelBookingController : ControllerBase
    {
         private readonly HotelDb _context;
        private HotelBookingsBAO hotelBookingBAO=null;

        public HotelBookingController(HotelDb context)
        {
            _context = context;
            hotelBookingBAO=new HotelBookingsBAO(_context);
        }
        [HttpGet]
        public IActionResult getallHotelBooking()
        {
            List<HotelBooking> Hlist = hotelBookingBAO.getallhotelBooking();
            if (Hlist.Count != 0)
                return Ok(Hlist);
            else
                return NotFound("No Records found");

        }
        
        [HttpPost]
        public IActionResult    InsertHotelBooking([FromBody] HotelBooking hotelBooking){
            //HotelBookingBAo hotelBookingBAo=new HotelBookingBAo();
            string S=hotelBookingBAO.InsertHotelBooking(hotelBooking);
            if(S.Equals("1"))
                return Ok("Details Inserted"); 
            else
                return BadRequest(S);
        }
         [HttpGet("{BookingId}")]
        public IActionResult GetHotelBooking(string bookingId)
        {
            HotelBooking? P = hotelBookingBAO.GetBookingId(bookingId);
            if (P != null)
                return Ok(P);
            else
                return NotFound("No project With id" + bookingId + "not found");
        }
         [HttpPut("{bookingid}")]
        public IActionResult updateHotelBooking ([FromBody] HotelBooking P, string bookingid)
        {


            string S = hotelBookingBAO.updateHotelBooking(P, bookingid);
            if (S.Equals("1"))
                return Ok(S);
            else
                return NotFound("No project With bookingid" + bookingid + "found");
        }
        
        [HttpDelete("{BookingId}")]
        public IActionResult deleteProject(string bookingId)
        {
            string S = hotelBookingBAO.deleteHotelBooking(bookingId);
            if (S.Equals("1"))
            {
                return Ok("1 row deleted");

            }
            else
                return NotFound(S);

        }

    }
}