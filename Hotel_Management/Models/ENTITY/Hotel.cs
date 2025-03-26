using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    [Table(name:"Hotelstbl45")]
    public class Hotel
    {
        private string hotelId;
        private string hotelName;
        private string description;
        private string area;
        private string state;
        private string city;
        private string country;
        private int noOfACRooms;
        private double costPerDay;
        private int noOfNonACRooms;
        private double costPerDayNonAc;

        public Hotel()
        {
        }

        public Hotel(string hotelId, string hotelName,string description, string area,string state, string city, string country, int noOfACRooms, double costPerDay, int noOfNonACRooms, double costPerDayNonAc)
        {
            this.HotelId = hotelId;
            this.HotelName = hotelName;
            this.Description=description;
            this.Area = area;
            this.state=state;
            this.City = city;
            this.Country = country;
            this.NoOfACRooms = noOfACRooms;
            this.CostPerDay = costPerDay;
            this.NoOfNonACRooms = noOfNonACRooms;
            this.CostPerDayNonAc = costPerDayNonAc;
        }

        [Key]
        [StringLength(7)]
        public string HotelId { get => hotelId; set => hotelId = value; }
        public string HotelName { get => hotelName; set => hotelName = value; }
        public string Description{get=>description;set=>description=value;}
        public string Area { get => area; set => area = value; }
        public string State { get => state; set => state = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public int NoOfACRooms { get => noOfACRooms; set => noOfACRooms = value; }
        public double CostPerDay { get => costPerDay; set => costPerDay = value; }
        public int NoOfNonACRooms { get => noOfNonACRooms; set => noOfNonACRooms = value; }
        public double CostPerDayNonAc { get => costPerDayNonAc; set => costPerDayNonAc = value; }
    }
}