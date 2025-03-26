using System.ComponentModel.DataAnnotations;
using Hotel_Management.Data;
using Hotel_Management.Models.DAO;
using Hotel_Management.Models.ENTITY;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Models.BAO
{
    public class LoginDAO : ILoginDAO

    {

        private HotelDb context;

        public LoginDAO(HotelDb context)
        {
            this.context = context;
        }

        public string InsertLogin(String Email, String Password)
        {

            var v = (from v1 in context.logins
                     where v1.Email == Email
                     select v1).FirstOrDefault();
                
            if (v == null)
            {
                return "Invalid Data";
            }
            else{
                bool b=BCrypt.Net.BCrypt.Verify(Password,v.Password);
                if (b)
                return v.UserType;
                else
                return "Invalid Credentials";
            }
                
            
        }


        public string ForgotPassword(string Email, string MobileNo)
        {
            var v = (from v1 in context.forgots
                     where v1.Email == Email && v1.MobileNo == MobileNo
                     select v1).FirstOrDefault();

            if (v == null)
            {
                return "Invalid Data";
            }
            else
                return v.FPassword1;
        }

    }
}

