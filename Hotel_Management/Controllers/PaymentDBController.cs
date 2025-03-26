using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Management.Data;
using Hotel_Management.Models;
using Hotel_Management.Models.BAO;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentDBController : ControllerBase
    {
         private readonly HotelDb _context;
        private PaymentBAO paymentBAO=null;
        public PaymentDBController(HotelDb context)
        {
           
            _context = context; 
            paymentBAO =new PaymentBAO(_context);
        }
        

        [HttpGet]
        public IActionResult getall()
        {
            List<PaymentDetails> Plist = paymentBAO.getall();
            if (Plist.Count != 0)
                return Ok(Plist);
            else
                return NotFound("No Records found");
 
        }
        [HttpPost]
        public IActionResult insertpaymentdetails([FromBody] PaymentDetails paymentDetails)
        {
            string S=paymentBAO.insertpaymentdetails(paymentDetails);
            if(S.Equals("1"))
                return Ok("1 Row Inserted");
            else
                return BadRequest(S);
        }
        
        // [HttpDelete("{id}")]
        // public IActionResult deletepaymentdetails(int id)
        // {
        //     string s=paymentBAO.deletepaymentdetails(id);
        //     if(s.Equals("1"))
        //     {
        //         return Ok("1 Row Deleted");
        //     }
        //     else{
        //         return NotFound(s);
        //     }
        // }
    }
}