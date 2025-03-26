using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelClientAPI.Models.Entities;
using Newtonsoft.Json;

namespace HotelClientAPI.Models.APIServices
{
    public class HotelAPIServices
    {
        private readonly HttpClient httpClient;

        public HotelAPIServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        //Login
        public HttpResponseMessage inserts()
        {

            HttpResponseMessage response = httpClient.GetAsync(RestUrl.Signup_URL).Result;
            return response;
        }

        public HttpResponseMessage insertHotel(SignUp signUp)
        {
            string data = JsonConvert.SerializeObject(signUp);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(RestUrl.Signup_URL + "InsertHotel", content).Result;
            return response;

        }

        public HttpResponseMessage insertl()
        {

            HttpResponseMessage response = httpClient.GetAsync(RestUrl.Signup_URL).Result;
            return response;

        }


        public HttpResponseMessage Login(Login login)
        {
            HttpResponseMessage response = httpClient.GetAsync(RestUrl.Signup_URL + "Insertlogin/" + login.Email + "/" + login.Password).Result;
            return response;

        }

        public HttpResponseMessage Forgotpassword(string Email, string MobileNo)
        {
            HttpResponseMessage res = httpClient.GetAsync(RestUrl.Signup_URL + "ForgetPassword/" + Email + "/" + MobileNo).Result;
            return res;
        }
        //Admin
        public HttpResponseMessage InsertHotel(Hotel hotel)
        {
            string id=hotel.hotelName.Substring(0,3).ToUpper();
            Random r=new Random();
            hotel.hotelId=id+r.Next(1000,9999);
            string data = JsonConvert.SerializeObject(hotel);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            //getasyn is used to check method is there or not in controller
            HttpResponseMessage response = httpClient.PostAsync(RestUrl.ADMIN_URL, content).Result;
            return response;
        }
        public HttpResponseMessage UpdateHotel(Hotel hotel, string id)
        {
            string data = JsonConvert.SerializeObject(hotel);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            //getasyn is used to check method is there or not in controller
            HttpResponseMessage response = httpClient.PutAsync(RestUrl.ADMIN_URL + id, content).Result;
            return response;
        }
        public HttpResponseMessage fetchHotels()
        {
            HttpResponseMessage response = httpClient.GetAsync(RestUrl.ADMIN_URL).Result;
            return response;
        }

        public HttpResponseMessage fetchHotelById(string id)
        {
            HttpResponseMessage response = httpClient.GetAsync(RestUrl.ADMIN_URL + id).Result;
            return response;
        }
        public HttpResponseMessage deleteHotelById(Hotel hotel, string id)
        {
            //string data=JsonConvert.SerializeObject(hotel);
            //StringContent content=new StringContent(data,Encoding.UTF8,"application/json");
            //getasyn is used to check method is there or not in controller
            HttpResponseMessage response = httpClient.DeleteAsync(RestUrl.ADMIN_URL + id).Result;
            return response;
        }
        //HotelBooking
        public HttpResponseMessage InsertHotelBooking(HotelBooking hotel){
            string data=JsonConvert.SerializeObject(hotel);
            StringContent content=new StringContent(data,Encoding.UTF8,"application/json");
            //getasyn is used to check method is there or not in controller
            // HttpResponseMessage response=httpClient.PostAsync(resultUrl.PROJECT_url,content).Result;
           HttpResponseMessage response=httpClient.PostAsync(RestUrl.BOOKING_URL,content).Result;

            return response;
        }
         public HttpResponseMessage UpdateHotelBooking(HotelBooking hotel,string id){
            string data=JsonConvert.SerializeObject(hotel);
            StringContent content=new StringContent(data,Encoding.UTF8,"application/json");
            //getasyn is used to check method is there or not in controller
            HttpResponseMessage response=httpClient.PutAsync(RestUrl.BOOKING_URL+id,content).Result;
            return response;
        }
        public HttpResponseMessage fetchHotelBookings(){
            HttpResponseMessage response=httpClient.GetAsync(RestUrl.BOOKING_URL).Result;
            return response;
        }
 
        public HttpResponseMessage fetchHotelByBookingId(string id){
            HttpResponseMessage response=httpClient.GetAsync(RestUrl.BOOKING_URL+id).Result;
            return response;
        }
        public HttpResponseMessage deleteHotelById(HotelBooking hotel,string id){
            //string data=JsonConvert.SerializeObject(hotel);
            //StringContent content=new StringContent(data,Encoding.UTF8,"application/json");
            //getasyn is used to check method is there or not in controller
            HttpResponseMessage response=httpClient.DeleteAsync(RestUrl.BOOKING_URL+id).Result;
            return response;
        }
        //Search Hotels
        public HttpResponseMessage getbycity(string city){
            HttpResponseMessage response = httpClient.GetAsync(RestUrl.BOOKING_URL+"search/"+city).Result;
            return response;
        }

        //Payments
        public HttpResponseMessage fetchpayments()
        {
            // List<HotelPayment> list=new List<HotelPayment>();
            //getasyn is used to check method is there or not in controller
            HttpResponseMessage response = httpClient.GetAsync(RestUrl.Payment_url).Result;
            return response;
        }
        public HttpResponseMessage fetchPaymentById(string  name){
            HttpResponseMessage response=httpClient.GetAsync(RestUrl.Payment_url+name).Result;
            return response;
        }
        public HttpResponseMessage InsertPayment(HotelPayment hotelPayment)
        {
            string id1=hotelPayment.Creditcardnumber.ToString().Substring(0,4);

            string id2=DateTime.Now.ToString("dd")+DateTime.Now.ToString("MM");
            Random r=new Random();
            hotelPayment.BookingId=id1+id2+r.Next(10,99);
            string data = JsonConvert.SerializeObject(hotelPayment);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            //getasyn is used to check method is there or not in controller
            HttpResponseMessage response = httpClient.PostAsync(RestUrl.Payment_url, content).Result;
            return response;
        }

        //public HttpResponseMessage deletepaymentbyid(HotelPayment hotelPayment, int id)
        // {
        //     string data = JsonConvert.SerializeObject(hotelPayment);
        //     StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        //     //getasyn is used to check method is there or not in controller
        //     HttpResponseMessage response = httpClient.DeleteAsync(RestUrl.HOTEL_URL).Result;
        //     return }
        

    }
}