using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelClientAPI.Models.Entites
{
    public class Registration
    {
        private string emailID;
        private string password;
        private string userType;
 
        public Registration()
        {
        }
 
        public Registration(string emailID, string password, string userType)
        {
            this.EmailID = emailID;
            this.Password = password;
            this.UserType = userType;
        }
        [Key]
        public string EmailID { get => emailID; set => emailID = value; }
        public string Password { get => password; set => password = value; }
        public string UserType { get => userType; set => userType = value; }
        
    }
}