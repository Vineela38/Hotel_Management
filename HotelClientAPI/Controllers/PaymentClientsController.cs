using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HotelClientAPI.Models.Entites;
using HotelClientAPI.Models.APIServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using HotelClientAPI.Models.Entities;

namespace HotelClientAPI.Controllers
{
    [Route("[controller]")]
    public class PaymentClientsController : Controller
    {
        List<Bank> list=new List<Bank>();
        private readonly HotelAPIServices hotelBookingsAPIService;
 
        public PaymentClientsController (HotelAPIServices hotelApiService)
        {
            this.hotelBookingsAPIService = hotelApiService;
        }
        // public List<Bank> getpaymentHotels(){
        //     HttpResponseMessage response =hotelApiService.fetchpayments();
        //     if(response.IsSuccessStatusCode){
        //         String data = response.Content.ReadAsStringAsync().Result;
        //         list=JsonConvert.DeserializeObject<List<Bank>>(data);
        //     }
        //     return list;
        // }
        [HttpGet]
        [Route("getall")]
        public ActionResult getall(){
            return View();
        }
         [HttpPost]
        [Route("getallProjects")]
        public ActionResult getallPayments(){
            List<HotelPayment>list=null;
            HttpResponseMessage response=hotelBookingsAPIService.fetchpayments();
            if(response.IsSuccessStatusCode){
                string data=response.Content.ReadAsStringAsync().Result;
                //Serialization-Converting class objects to Json format
                //converting json data into objects is called DeserializeObject
                List<HotelPayment>plist=JsonConvert.DeserializeObject<List<HotelPayment>>(data);
                ViewBag.plist=plist;
            }
            else{
                string str=response.Content.ReadAsStringAsync().Result;
               
            }
            return View("getall");
        }
        [HttpGet]
        [Route("insertpayment")]
        public ActionResult Insert(){
            HotelPayment p=new HotelPayment();
            //ViewBag.payment=list;
            return View(p);
        }
        [HttpPost]
        [Route("insertpayment")]
        public ActionResult Insert(HotelPayment hotelPayment){
            //ViewBag.payment=list;
            if(ModelState.IsValid){
            HttpResponseMessage response = hotelBookingsAPIService.InsertPayment(hotelPayment);
            if(response.IsSuccessStatusCode){
                string data=response.Content.ReadAsStringAsync().Result;
                ViewBag.msg=JsonConvert.DeserializeObject<string>(data);
            }
            else{
                string s=response.Content.ReadAsStringAsync().Result;
                ViewBag.msg=JsonConvert.DeserializeObject<string>(s);
            }
        }
            return View();
        }

        // [HttpGet]
        // [Route("{id}")]
        // public IActionResult fetchById(string id){
        //     Bank h=new Bank();
        //     HttpResponseMessage response =hotelApiService.fetchPaymentById(id);
        //     if(response.IsSuccessStatusCode){
        //         String data = response.Content.ReadAsStringAsync().Result;
        //         h=JsonConvert.DeserializeObject<Bank>(data);
        //         ViewBag.hotels=getpaymentHotels();
        //     }
           
        //     return View("insertpayment",h);
        // }
        

        //  [HttpGet]
        // [Route("Delete")]
        // public ActionResult Delete()
        // {
           
        //     HttpResponseMessage response =hotelApiService.GetAllPayment();
        //     if(response.IsSuccessStatusCode){
        //         String data = response.Content.ReadAsStringAsync().Result;
        //         list=JsonConvert.DeserializeObject<List<HotelPayment>>(data);
        //         ViewBag.hotels=list;
        //     }
           
        //     return View();
        // }
        //  [HttpPost]
        // [Route("Delete")]
        // public ActionResult Delete(HotelPayment hotelPayment,int  id){
        //     HttpResponseMessage response = hotelApiService.deletepaymentbyid(hotelPayment,id);
        //     if(response.IsSuccessStatusCode){
        //         string data=response.Content.ReadAsStringAsync().Result;
        //         ViewBag.msg=data;
        //     }
        //     else{
        //         string s=response.Content.ReadAsStringAsync().Result;
        //         ViewBag.msg=s;
        //     }
        //     return View();
        // }
    }
}
