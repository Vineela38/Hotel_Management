using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models.DAO
{
    public interface IHotelDAO
    {
        string insertHotel(Hotel hotel);
        List<Hotel> getDetails();
        string updateHotel(Hotel hotel,string id);
        Hotel GetHotelbyId(string id);
        string DeleteHotel(string id);
        //string GenerateRandomhotelId(int HotelId);
    }
}