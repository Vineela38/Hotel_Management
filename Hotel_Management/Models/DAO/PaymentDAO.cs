using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Management.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Models.DAO
{
    public class PaymentDAO:IPaymentDAO
    {
         private readonly HotelDb _context;

        public PaymentDAO(HotelDb context)
        {
            _context = context;
        }
         public List<PaymentDetails>getallpayments()
        {
            return _context.paymentDetails.ToList();
        }
         public string insertpaymentdetails(PaymentDetails paymentDetails)
        {
            try{
            _context.Entry(paymentDetails).State=EntityState.Added;
            _context.SaveChanges();
            string id=paymentDetails.BookingId;
            return paymentDetails.BookingId;
            }
            catch(DbUpdateException E)
            {
                SqlException ex=(SqlException)E.GetBaseException();
                if(ex.Message.Contains("PaymentDetailstbl4"))
                return " Payment  id cannot be duplicate";
                else
                return "Cloud not insert";
            }
        }
        // public string insertbankdetails(BankDetails bankDetails)
        // {
        //     try{
        //     _context.Entry(bankDetails).State=EntityState.Added;
        //     _context.SaveChanges();
        //     return "1 ";
        //     }
        //     catch(DbUpdateException E)
        //     {
        //         SqlException ex=(SqlException)E.GetBaseException();
        //         if(ex.Message.Contains("BankDetailstbl4"))
        //         return " Bank id cannot be duplicate";
        //         else
        //         return "Cloud not insert";
        //     }
        // }
        //  public string deletepaymentdetails(int id)
        // {
        //     PaymentDetails? p=_context.paymentDetails.Where(x=>x.Creditcardnumber==id).FirstOrDefault();
           
        //    if(p!=null)
        //    {
        //     //_context.Entry(p).State=EntityState.Deleted;
        //     _context.paymentDetails.Remove(p);
        //     _context.SaveChanges();
        //     return "1";
        //    }else{
        //     return "No Project exist with id"+id;
        //    }
        // }
         //public string deletebankdetails(string id)
        //{
        //     BankDetails? p=_context.bankDetails.Where(x=>x.Bankid==id).FirstOrDefault();
           
        //    if(p!=null)
        //    {
        //     //_context.Entry(p).State=EntityState.Deleted;
        //     _context.bankDetails.Remove(p);
        //     _context.SaveChanges();
        //     return "1";
        //    }else{
        //     return "No Project exist with id"+id;
        //    }
        // }
    }
}