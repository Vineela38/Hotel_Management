using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    [Table(name: "PaymentDetailstbl45")]
    public class PaymentDetails
    {
        
        private long creditcardnumber;
        private string bankname;
        private string cardtype;
        private string nameoncard;
        private DateOnly expirydate;
        private int cvv;
        private int pin;
        string bookingId;
        
        [Key]
        public string BookingId{get=>bookingId;set=>bookingId=value;}

        public long Creditcardnumber { get => creditcardnumber; set => creditcardnumber = value; }
        public string Bankname{get=>bankname;set=>bankname=value;}
        public string Cardtype { get => cardtype; set => cardtype = value; }
        public string Nameoncard { get => nameoncard; set => nameoncard = value; }
        public DateOnly Expirydate { get => expirydate; set => expirydate = value; }
        public int Cvv { get => cvv; set => cvv = value; }
        public int Pin { get => pin; set => pin = value; }
        
        

        public PaymentDetails(long creditcardnumber,string bankname,string cardtype, string nameoncard, DateOnly expirydate, int cvv, int pin,string bookingId)
        { 
            this.Creditcardnumber = creditcardnumber;
            this.Bankname=bankname;
            this.Cardtype = cardtype;
            this.Nameoncard = nameoncard;
            this.Expirydate = expirydate;
            this.Cvv = cvv;
            this.Pin = pin;
            this.BookingId=bookingId;
        }

        public PaymentDetails()
        {
        }
    }
}