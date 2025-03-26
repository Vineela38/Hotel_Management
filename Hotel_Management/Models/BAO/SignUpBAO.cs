
using Hotel_Management.Data;
using Hotel_Management.Models.DAO;
using Hotel_Management.Models.ENTITY;

namespace Hotel_Management.Models.BAO
{
    public class SignUpBAO
    {
        SignUpDAO dAO=null;

        private readonly HotelDb context;

        public SignUpBAO(HotelDb context)
        {
            this.context = context;
            dAO= new SignUpDAO(context);
        }

        public string InsertHotel(SignUp s){
            return dAO.InsertCustomer(s);
        }

        
        

    }
}