using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Management.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Models.DAO
{
    
    public class HotelDAO:IHotelDAO
    {
        private readonly HotelDb _context;
        //IHotelDAO hotelDAO=null;

        public HotelDAO(HotelDb context)
        {                                                                                                                 
            _context = context;
        }
        public List<Hotel> getDetails(){
            return _context.hotels.ToList();
        }

        public string insertHotel(Hotel hotel){
            try{
               _context.Entry(hotel).State=EntityState.Added;
                _context.SaveChanges();
                return "1"; 
            }
            catch(DbUpdateException E){
                SqlException ex=(SqlException)E.GetBaseException();
                if(ex.Message.Contains("PK_Hotelstbl4"))
                return " Hotel id cannot be duplicate";
                else
                return "Cloud not insert";
            } 
        }
         public Hotel? GetHotelbyId(string id)
         {
            return _context.hotels.Where(x=>x.HotelId==id).FirstOrDefault();
         }
        public string updateHotel(Hotel hotel,string id)
        {
            try{
            Hotel? existing=GetHotelbyId(id);
            if(existing!=null)
            {
                existing.HotelName=hotel.HotelName;
                existing.Description=hotel.Description;
                existing.Area=hotel.Area;
                existing.State=hotel.State;
                existing.City=hotel.City;
                existing.Country=hotel.Country;
                existing.NoOfACRooms=hotel.NoOfACRooms;
                existing.CostPerDay=hotel.CostPerDay;
                existing.NoOfNonACRooms=hotel.NoOfNonACRooms;
                _context.Entry(existing).State=EntityState.Modified;
                _context.SaveChanges();
                return "1";
            }
            else{
                return "No Hotel Found With Id "+id;
            }
            }
            catch(DbUpdateException E){
                SqlException ex=(SqlException)E.GetBaseException();
                if(ex.Message.Contains("PK_Hotelstbl4"))
                return " Hotel id cannot be duplicate";
                else
                return "Cloud not insert"+ex.Message;
            }
        }
        public string DeleteHotel(String id)
        {
            Hotel? hotel=_context.hotels.Where(x=>x.HotelId==id).FirstOrDefault();
            if(hotel!=null)
            {
                _context.hotels.Remove(hotel);
                _context.SaveChanges();
                return "1";
            }
            else{
                return "No Hotel Exist With Id "+id;
            }
        }

        //  public string GenerateRandomhotelId(int HotelId)
        // {
        //     const string chars = "0123456789";
        //     Random random = new Random();
        //     StringBuilder stringBuilder = new StringBuilder();
        //     for (int i = 0; i < HotelId; i++)
        //     {
        //         stringBuilder.Append(chars[random.Next(chars.Length)]);
        //     }
        //     return stringBuilder.ToString();
        // }
    }
}