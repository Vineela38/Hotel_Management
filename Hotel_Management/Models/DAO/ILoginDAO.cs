using Hotel_Management.Models.ENTITY;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Hotel_Management.Models.DAO
{
    public interface ILoginDAO
    {
        public string InsertLogin(string email,string password);

        public string ForgotPassword(string email, string mobileNo);
        
        
    }
}