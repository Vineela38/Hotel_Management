using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Management.Data;
using Hotel_Management.Models.DAO;
using Hotel_Management.Models.ENTITY;

namespace Hotel_Management.Models.BAO
{
    public class HotelBookingsBAO
    {
        private readonly HotelDb _context;
        IHotelBookingsDAO ihotelBookingDAO=null;
        public HotelBookingsBAO(HotelDb context){
            _context=context;
            ihotelBookingDAO=new HotelBookingsDAO(_context);
        }

        public string InsertHotelBooking(HotelBooking hotelBooking)
        {
            return ihotelBookingDAO.InsertHotelBooking(hotelBooking);

        }
          public List<HotelBooking> getallhotelBooking()
        {
            return ihotelBookingDAO.getallHotelBooking();
        }
         public HotelBooking? GetBookingId(string bookingId)
        {
            return ihotelBookingDAO.GetBookingId(bookingId);
        }
           public string updateHotelBooking(HotelBooking P,string bookingId)
        {
            return ihotelBookingDAO.updateHotelBooking(P,bookingId);
        }
          public string deleteHotelBooking(string bookingId)
          {
            return ihotelBookingDAO.deleteHotelBooking(bookingId);
          }
    }
}