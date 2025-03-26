using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Management.Data;
using Hotel_Management.Models;
using Hotel_Management.Models.DAO;

namespace Hotel_Management.Models.BAO
{
    public class PaymentBAO
    {
         private readonly HotelDb _context;
        IPaymentDAO paymentDAO=null;
        public PaymentBAO(HotelDb context)
        {
            _context = context;
            paymentDAO =new PaymentDAO(_context);
            
        }
         public List<PaymentDetails> getall(){
            return paymentDAO.getallpayments();

        }
         public string insertpaymentdetails(PaymentDetails paymentDetails)
        {
           return  paymentDAO.insertpaymentdetails(paymentDetails);
        }
        //  public string insertbankdetails(BankDetails bankDetails)
        // {
        //    return  paymentDAO.insertbankdetails(bankDetails);
        // }
        // public string deletepaymentdetails(int id)
        // {
        //     return paymentDAO.deletepaymentdetails(id);
        // }
        // public string deletebankdetails(string id)
        // {
        //     return paymentDAO.deletebankdetails(id);
        // }
    }
}