using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HotelClientAPI.Models.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using HotelClientAPI.Models.APIServices;
using HotelClientAPI.Models.Entities;

namespace HotelClientAPI.Controllers
{
    [Route("[controller]")]
    public class HotelBookingsController : Controller
    {
        List<HotelBooking> hlist = new List<HotelBooking>();
        List<Hotel>? Hotels=null;
        BookingProccesing bookingProccesing=new BookingProccesing();
        private readonly HotelAPIServices hotelBookingAPIservices;

        public HotelBookingsController(HotelAPIServices hotelBookingAPIservices)
        {
            this.hotelBookingAPIservices= hotelBookingAPIservices;
        }

        [HttpGet]
        [Route("InsertDetails")]
        public ActionResult InsertDetails()
        {
            BookingProccesing hotelProcessing = new BookingProccesing();
            HttpResponseMessage response = hotelBookingAPIservices.fetchHotels();
            var model = new HotelBooking
            {
                bookingDate = DateTime.Now // Set the BookingDate to the current date
            };
            ViewBag.FormattedBookingDate = model.bookingDate.ToString("dd-MM-yyyy");
            if (response.IsSuccessStatusCode)
            {
                string Value = response.Content.ReadAsStringAsync().Result;
                Hotels = JsonConvert.DeserializeObject<List<Hotel>>(Value);
                ViewBag.hotels = Hotels;
            }
            if(TempData["hotelName"]!=null)
                ViewBag.Hotelname=TempData["hotelName"].ToString();
            if(TempData["hotelId"]!=null)
                bookingProccesing.hotelBooking.hotelId=TempData["hotelId"].ToString();
            return View(bookingProccesing);
        }
        [HttpPost]
        [Route("InsertDetails")]
        public ActionResult InsertDetails(BookingProccesing bookingProccesing)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = hotelBookingAPIservices.InsertPayment(bookingProccesing.hotelPayment);
                if (response.IsSuccessStatusCode)
                {
                    if(TempData["hotelName"]!=null)
                         ViewBag.Hotelname=TempData["hotelName"].ToString();
                    ViewBag.hotels = GetAllHotelsByCity();
                    string Accept = response.Content.ReadAsStringAsync().Result;
                    string bookingId = JsonConvert.DeserializeObject<string>(Accept);
                    bookingProccesing.hotelBooking.bookingId = bookingId;
 
                    HttpResponseMessage res = hotelBookingAPIservices.InsertHotelBooking(bookingProccesing.hotelBooking);
                    if (res.IsSuccessStatusCode)
                    {
                        ViewBag.hotels = GetAllHotelsByCity();
                        string data = res.Content.ReadAsStringAsync().Result;
                        string Done = JsonConvert.DeserializeObject<string>(data);
                        ViewBag.msg = Done + " Booking ID: " + bookingProccesing.hotelBooking.bookingId;
                    }
                }
                else
                {
                    string Not = response.Content.ReadAsStringAsync().Result;
                    ViewBag.msg = Not;
                }
            }
            return View();
        }
        //Calculating Total price 
         [Route("GetCalculation")]
        public ActionResult GetCalculation(HotelBooking hotelBooking,string hotelName)
        {
            HttpResponseMessage response = hotelBookingAPIservices.fetchHotelById(hotelBooking.hotelId);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.hotels = GetAllHotelsByCity();
                ViewBag.hotelName=hotelName;
                string data = response.Content.ReadAsStringAsync().Result;
                Hotel hotel = JsonConvert.DeserializeObject<Hotel>(data);
 
                double? totalPrice = 0;
                if (hotelBooking.roomType == "AC")
                {
                    if (hotelBooking.noOfAdults > 0 || hotelBooking.noOfchild > 0)
                    {
                        totalPrice = (hotelBooking.noOfDays * hotelBooking.noOfAdults * hotel.costPerDay) +
                                      (hotelBooking.noOfDays * hotelBooking.noOfchild * hotel.costPerDay);
                    }
                    ViewBag.TotalPrice = totalPrice;
                }
                else
                {
                    if (hotelBooking.noOfAdults > 0 || hotelBooking.noOfchild > 0)
                    {
                        totalPrice = (hotelBooking.noOfDays * hotelBooking.noOfchild * hotel.costPerDay) +
                                        (hotelBooking.noOfDays * hotelBooking.noOfchild * hotel.costPerDay);
                    }
                    ViewBag.TotalPrice = totalPrice;
                }
            }
            else
            {
                string errorMessage = response.Content.ReadAsStringAsync().Result;
                ViewBag.msg = $"Error: {errorMessage}";
            }
            BookingProccesing H = new BookingProccesing();
            H.hotelBooking = hotelBooking;
            H.hotelBooking.bookingDate=DateTime.Now;
            // ViewBag.FormattedBookingDate = H.hotelBooking.bookingDate.ToString("dd-MM-yyyy");
            return View("InsertDetails", H);
        }
        [HttpGet]
        [Route("getall")]
        public ActionResult getall()
        {
            return View();
        }
        [HttpPost]
        [Route("getallHotelBooking")]
        public ActionResult getallHotelBooking()
        {
            List<HotelBooking> list = null;
            HttpResponseMessage response = hotelBookingAPIservices.fetchHotels();
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                //Serialization-Converting class objects to Json format
                //converting json data into objects is called DeserializeObject
                List<HotelBooking> plist = JsonConvert.DeserializeObject<List<HotelBooking>>(data);
                ViewBag.plist = plist;
            }
            else
            {
                string str = response.Content.ReadAsStringAsync().Result;

            }
            return View("getall");
        }
        public List<HotelBooking> GetHotelBookings()
        {
            HttpResponseMessage response = hotelBookingAPIservices.fetchHotels();
            if (response.IsSuccessStatusCode)
            {
                String data = response.Content.ReadAsStringAsync().Result;
                hlist = JsonConvert.DeserializeObject<List<HotelBooking>>(data);
            }
            return hlist;
        }

        [HttpGet]
        [Route("fetch/{bookingId}")]
        public IActionResult fetchById(string bookingId)
        {
             HttpResponseMessage response = hotelBookingAPIservices.fetchHotelBookings();
            if (response.IsSuccessStatusCode)
            {
                String data = response.Content.ReadAsStringAsync().Result;
                hlist = JsonConvert.DeserializeObject<List<HotelBooking>>(data);
                ViewBag.bookinghotels = hlist;
            }
 
            HotelBooking h = new HotelBooking();
            HttpResponseMessage resp = hotelBookingAPIservices.fetchHotelByBookingId(bookingId);
            if (response.IsSuccessStatusCode)
            {
                String data = resp.Content.ReadAsStringAsync().Result;
                h = JsonConvert.DeserializeObject<HotelBooking>(data);
            }
 
            return View("Update", h);
        }
        [HttpGet]
        [Route("Update")]
        public ActionResult Update()
        {
 
            HttpResponseMessage response = hotelBookingAPIservices.fetchHotelBookings();
            if (response.IsSuccessStatusCode)
            {
                String data = response.Content.ReadAsStringAsync().Result;
                hlist = JsonConvert.DeserializeObject<List<HotelBooking>>(data);
                ViewBag.bookinghotels = hlist;
            }
 
            return View();
        }
        [HttpPost]
        [Route("Update")]
        public ActionResult Update(HotelBooking P, string BookingId)
        {
            //ViewBag.bookinghotels = hlist;
            HttpResponseMessage response = hotelBookingAPIservices.fetchHotelBookings();
            if (response.IsSuccessStatusCode)
            {
                String data = response.Content.ReadAsStringAsync().Result;
                hlist = JsonConvert.DeserializeObject<List<HotelBooking>>(data);
                ViewBag.bookinghotels = hlist;
            }
 
            HttpResponseMessage resp = hotelBookingAPIservices.UpdateHotelBooking(P, BookingId);
            if (response.IsSuccessStatusCode)
            {
                String data = resp.Content.ReadAsStringAsync().Result;
                ViewBag.msg=JsonConvert.DeserializeObject<string>(data);
                ViewBag.hlist = getallHotelBooking();
            }
            else
            {
                String S = resp.Content.ReadAsStringAsync().Result;
                ViewBag.msg = JsonConvert.DeserializeObject<string>(S);
            }
            return View();
        }

          [HttpGet]
        [Route("fetchid/{bookingId}")]
        public IActionResult fetchhotelById(string bookingid)
        {
            HttpResponseMessage response = hotelBookingAPIservices.fetchHotelBookings();
            if (response.IsSuccessStatusCode)
            {
                String data = response.Content.ReadAsStringAsync().Result;
                hlist = JsonConvert.DeserializeObject<List<HotelBooking>>(data);
                ViewBag.bookinghotels = hlist;
            }
 
            HotelBooking h = new HotelBooking();
            HttpResponseMessage resp = hotelBookingAPIservices.fetchHotelByBookingId(bookingid);
            if (response.IsSuccessStatusCode)
            {
                String data = resp.Content.ReadAsStringAsync().Result;
                h = JsonConvert.DeserializeObject<HotelBooking>(data);
            }
 
            return View("Delete", h);
        }
 
        [HttpGet]
        [Route("Delete")]
        public ActionResult Delete()
        {
            HttpResponseMessage response = hotelBookingAPIservices.fetchHotelBookings();
            if (response.IsSuccessStatusCode)
            {
                String data = response.Content.ReadAsStringAsync().Result;
                hlist = JsonConvert.DeserializeObject<List<HotelBooking>>(data);
                ViewBag.bookinghotels = hlist;
            }
 
            return View();
        }
        [HttpPost]
        [Route("Delete")]
        public ActionResult Delete(HotelBooking p, string bookingid)
        {
            ViewBag.bookinghotels = hlist;
            HttpResponseMessage response = hotelBookingAPIservices.fetchHotelBookings();
            if (response.IsSuccessStatusCode)
            {
                String data = response.Content.ReadAsStringAsync().Result;
                hlist = JsonConvert.DeserializeObject<List<HotelBooking>>(data);
                ViewBag.bookinghotels = hlist;
            }
            HttpResponseMessage res = hotelBookingAPIservices.deleteHotelById(p, bookingid);
            if (response.IsSuccessStatusCode)
            {
                String data = res.Content.ReadAsStringAsync().Result;
                ViewBag.msg=JsonConvert.DeserializeObject<string>(data);
                ViewBag.hlist = getallHotelBooking();
            }
            else
            {
                String S = res.Content.ReadAsStringAsync().Result;
                ViewBag.msg= JsonConvert.DeserializeObject<string>(S);
            }
            return View();
        }

        //Search Hotels

        [HttpGet]
        [Route("GetByCity")]
        public ActionResult GetByCity()
        {
            List<string> Cities=new List<string>(){
                "Hyderabad","Chennai","Vizag","Banglore"
            };
            ViewBag.City=Cities;
            return View();
        }
        [HttpPost]
        [Route("GetByCity")]
        public ActionResult GetByCity(string City)
        {
            //hlist = new List<HotelBooking>();
             List<string> Cities=new List<string>(){
                "Hyderabad","Chennai","Vizag","Banglore"
            };
            ViewBag.City=Cities;
            // ViewBag.List = GetAllHotelsByCity();
            HttpResponseMessage response = hotelBookingAPIservices.getbycity(City);
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Hotels = JsonConvert.DeserializeObject<List<Hotel>>(data);
                ViewBag.msg = data;
 
            }
            else
            {
 
                string Not = response.Content.ReadAsStringAsync().Result;
                ViewBag.msg = Not;
 
            }
            return View(Hotels);
        }
 
        public List<Hotel> GetAllHotelsByCity()
        {
            HttpResponseMessage response = hotelBookingAPIservices.fetchHotels();
            if (response.IsSuccessStatusCode)
            {
                string Value = response.Content.ReadAsStringAsync().Result;
                List<Hotel> HotelList = JsonConvert.DeserializeObject<List<Hotel>>(Value);
                Hotels = HotelList;
            }
            return Hotels;
        }
 
 
        [HttpPost]
        public ActionResult SelectHotel(string HotelId)
        {
            HttpResponseMessage response= hotelBookingAPIservices.fetchHotelById(HotelId);
            if(response.IsSuccessStatusCode)
            {
                string Value=response.Content.ReadAsStringAsync().Result;
                Hotel H=JsonConvert.DeserializeObject<Hotel>(Value);
                TempData["HotelName"]=H.hotelName;
                TempData["HotelId"]=H.hotelId;
            }
            return RedirectToAction("InsertDetails");
        }
    }
}