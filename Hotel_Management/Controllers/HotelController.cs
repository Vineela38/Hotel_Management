using Hotel_Management.Data;
using Hotel_Management.Models.BAO;
using Hotel_Management.Models.ENTITY;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace Hotel_Management.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HotelController : ControllerBase
{
        private readonly HotelDb context;


        LoginBAO login = null;
        SignUpBAO signUp = null;

        public HotelController(HotelDb context)
        {
                this.context = context;
                login = new LoginBAO(context);
                signUp = new SignUpBAO(context);

        }


        [HttpGet]
        [Route("Insertlogin/{Email}/{Password}")]
        public IActionResult Insertlogin(string Email, string Password)
        {
                String s = login.InsertLogin(Email, Password);

                if (s.Equals("Admin"))
                {
                        return Ok("Admin");
                }
                else if (s.Equals("Customer"))
                {
                        return Ok("Customer");

                }
                else
                {
                        return BadRequest("Invalid Credentials");
                }


        }
        [HttpGet]
        [Route("ForgetPassword/{Email}/{MobileNo}")]

        public IActionResult ForgetPassword(String Email, String MobileNo)
        {

                string s = login.ForgotPassword(Email, MobileNo);
                if (s!=null)
                {
                        return Ok(s);
                }
                else
                        return BadRequest("No records");

        }


        [HttpGet]
        [Route("GetHotel")]
        public IActionResult getHotel()
        {

                return Ok(context.signUps.ToList());
        }


        [HttpPost]
        [Route("InsertHotel")]
        public IActionResult InsertHotel([FromBody] SignUp sign)
        {
                String str = signUp.InsertHotel(sign);
                if (str.Equals("1"))
                        return Ok(" Succesfully Created ");
                else
                        return BadRequest("Email exists");
        }
}



 // if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(Password))
                // {
                //         return BadRequest("Email or Password cannot be empty.");
                // }





