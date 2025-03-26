using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Models
{
    [Table(name:"Registrationtbl45")]
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