
using Hotel_Management.Data;
using Hotel_Management.Models.ENTITY;

namespace Hotel_Management.Models.BAO
{
    public class LoginBAO
    {

        LoginDAO login = null;
        

        private readonly HotelDb context;

        public LoginBAO(HotelDb context)
        {
            this.context = context;
            login = new LoginDAO(context);
        }
        public string InsertLogin(string Email, string Password)
        {

            return login.InsertLogin(Email,Password);
        }

        public String ForgotPassword(String Email, string MobileNo){
            return  login.ForgotPassword(Email,MobileNo);



        }


        


    }
}