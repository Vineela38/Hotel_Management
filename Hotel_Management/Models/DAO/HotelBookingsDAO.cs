using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Management.Data;
using Hotel_Management.Models.ENTITY;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Models.DAO
{
    public class HotelBookingsDAO:IHotelBookingsDAO
    {
        private readonly HotelDb _context;
         //IhotelBookingDAO hotelBookingDAO=null;
         public HotelBookingsDAO(HotelDb context)
         {
            _context=context;
            //hotelBookingDAO=new HotelBookingDAO(_cotext);
         }
      
        public string InsertHotelBooking(HotelBooking hotelBooking){
            try{
                hotelBooking.BookingDate=DateTime.Now;
               _context.Entry(hotelBooking).State=EntityState.Added;
                _context.SaveChanges();
                return "1 ";
            }
            catch(DbUpdateException E){
                SqlException ex=(SqlException)E.GetBaseException();
                if(ex.Message.Contains("PK_HotelBookingtbl4"))
                return " Hotel id cannot be duplicate";
                else
                return "Cloud not insert";
            }
        }
          public List<HotelBooking> getallHotelBooking()
         {
            return _context.hotelBookings.ToList();
         }

         public HotelBooking? GetBookingId(string id)
        {
            return _context.hotelBookings.Where(x=>x.BookingId==id).FirstOrDefault();
        }


public string updateHotelBooking(HotelBooking p,string bookingId)
        {
            try{
               HotelBooking? existing=GetBookingId(bookingId);
            if(existing!=null)
            {
                existing.HotelId=p.HotelId;
                existing.BookingDate = p.BookingDate; // Update Booking Date
                existing.ArrivalDate = p.ArrivalDate; // Update Arrival Date
                existing.DepartureDate = p.DepartureDate; // Update Departure Date
                existing.NoOfAdults = p.NoOfAdults; // Update Number of Adults
                existing.NoOfchild = p.NoOfchild; // Update Number of Children
                existing.NoOfDays=p.NoOfDays;
                _context.Entry(existing).State=EntityState.Modified;
                _context.SaveChanges();
                return "1";
            }
            else{
                return "No Hotel Found With Id ";
            } 
            }
            catch(DbUpdateException E){
                SqlException ex=(SqlException)E.GetBaseException();
                if(ex.Message.Contains("PK_HotelBookingtbl4"))
                return " Hotel id cannot be duplicate";
                else
                return "Cloud not insert";
            }
           
        }

         public string deleteHotelBooking(string bookingId)
        {
            HotelBooking? P=_context.hotelBookings.Where(x=>x.BookingId==bookingId).FirstOrDefault();
            //_context.Projects.Remove(P);
            if(P!=null)
            {
            _context.hotelBookings.Remove(P);
            _context.SaveChanges();
            return "1";
            }
            else
            {
                return "No Project exists with id"+bookingId;
            }
        }
    }
}