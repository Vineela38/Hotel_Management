using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    [Table(name:"Customertbl45")]
    public class Customer
    {
        
        private string emailID;
        private string customerName;
        private string password;
        private long contactNumber;
        private DateTime dateOfBirth;
        private string area;
        private string state;
        private string city;
        private string country;
        private int pincode;

        public Customer()
        {
        }

        public Customer(string emailID, string customerName, string password, long contactNumber, DateTime dateOfBirth, string area, string state, string city, string country, int pincode)
        {
            this.emailID = emailID;
            this.CustomerName = customerName;
            this.Password = password;
            this.ContactNumber = contactNumber;
            this.DateOfBirth = dateOfBirth;
            this.Area = area;
            this.state=state;
            this.City = city;
            this.Country = country;
            this.Pincode = pincode;
        }
        [Key]
        public string EmailID { get => emailID; set => emailID = value; }
        [ForeignKey("EmailID")]
        public Registration registration{set;get;}
        
        public string CustomerName { get => customerName; set => customerName = value; }
        public string Password { get => password; set => password = value; }
        public long ContactNumber { get => contactNumber; set => contactNumber = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Area { get => area; set => area = value; }
        public string State { get => state; set => state = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public int Pincode { get => pincode; set => pincode = value; }
    }
}