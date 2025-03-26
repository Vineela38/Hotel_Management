using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Management.Models.ENTITY;

namespace Hotel_Management.Models.DAO
{
    public interface IHotelBookingsDAO
    {
        string InsertHotelBooking(HotelBooking hotelBooking);
         List<HotelBooking>getallHotelBooking();
         string updateHotelBooking(HotelBooking P,string bookingId);
        string deleteHotelBooking(string id);
        HotelBooking? GetBookingId(string id);
    }
}