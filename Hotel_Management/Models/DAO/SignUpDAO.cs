using Hotel_Management.Data;
using Hotel_Management.Models.ENTITY;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Models.DAO
{
    public class SignUpDAO : ISignUpDAO
    {
        private HotelDb context;

        public SignUpDAO(HotelDb context)
        {
            this.context = context;
        }

        public string InsertCustomer(SignUp S)
        {

            try
            {
                string pwd=BCrypt.Net.BCrypt.HashPassword(S.Password);
                Login L = new Login(S.Email, pwd, "Customer");
                ForgotPassword F= new ForgotPassword(S.MobileNo,S.Email,pwd);
                context.logins.Add(L);
                context.signUps.Add(S);
                context.forgots.Add(F);
                context.SaveChanges();
                return "1";
            }
            catch (DbUpdateException D)
            {

                SqlException sql = (SqlException)D.GetBaseException();
                if (sql.Message.Contains("PK_SignUp_1"))
                    return "EmailId can't be duplicate";
                else
                    return "Could not insert";
            }
        }

        



    }
}
