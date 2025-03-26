using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Management.Data;

namespace Hotel_Management.Models.DAO
{
    public interface IPaymentDAO
    {
        List<PaymentDetails>getallpayments();
        string insertpaymentdetails(PaymentDetails paymentDetails);
        //string deletepaymentdetails(int id);
        //string deletebankdetails(string id);
    }
}