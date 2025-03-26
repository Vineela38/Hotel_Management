using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Management.Data;
using Hotel_Management.Models.DAO;
using Microsoft.Identity.Client;

namespace Hotel_Management.Models.BAO
{
    public class HotelBAO
    {
        private readonly HotelDb _context;
        IHotelDAO hotelDAO=null;

        public HotelBAO(HotelDb context)
        {
            _context = context;
             hotelDAO=new HotelDAO(_context);
        }
        public string insertHotel(Hotel hotel){
            return hotelDAO.insertHotel(hotel);
        }
        public List<Hotel> getDetails(){
            return hotelDAO.getDetails();
        }
        public Hotel? GetHotelbyid(string id)
        {
            return hotelDAO.GetHotelbyId(id);
        }
        public string updateHotel(Hotel hotel,string id){
            return hotelDAO.updateHotel(hotel,id);
        }
        public string DeleteHotel(string id){
            return hotelDAO.DeleteHotel(id);
        }

        // public string GenerateRandomhotelId(int HotelId){
        //     return hotelDAO.GenerateRandomhotelId(HotelId);
        // }
    }
}