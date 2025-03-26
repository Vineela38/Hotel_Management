using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HotelClientAPI.Models.APIServices;
using HotelClientAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HotelClientAPI.Controllers
{
    [Route("[controller]")]
    public class HotelClientController : Controller
    {
        List<Hotel> hlist=new List<Hotel>();
        private readonly HotelAPIServices hotelAPIServices;
        public HotelClientController(HotelAPIServices hotelAPIServices){
            this.hotelAPIServices=hotelAPIServices;
        }

        [Route("Admin")]
        [HttpGet]
        public ActionResult Admin(){
        return View();
        }
        [HttpGet]
        [Route("getall")]
        public ActionResult getall(){
            return View();
        }
        // public List<Hotel>getallHotels(){
        
        // }

        [HttpPost]
        [Route("getallProjects")]
        public ActionResult getallProjects(){
            List<Hotel>list=null;
            HttpResponseMessage response=hotelAPIServices.fetchHotels();
            if(response.IsSuccessStatusCode){
                string data=response.Content.ReadAsStringAsync().Result;
                //Serialization-Converting class objects to Json format
                //converting json data into objects is called DeserializeObject
                List<Hotel>plist=JsonConvert.DeserializeObject<List<Hotel>>(data);
                ViewBag.plist=plist;
            }
            else{
                string str=response.Content.ReadAsStringAsync().Result;
                
            }
            return View("getall");
        }

        [HttpGet]
        [Route("insert")]
        public ActionResult insertHotel(){
            Hotel hotel=new Hotel();
            return View(hotel);
        }
        [HttpPost]
        [Route("insert")]
        public ActionResult insertHotel(Hotel hotel){
            if(ModelState.IsValid){
            //hotel.hotelId=GenerateHotelId(hotel.hotelName);
            HttpResponseMessage response = hotelAPIServices.InsertHotel(hotel);
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

        [HttpGet]
        [Route("fetch/{id}")]
        public IActionResult fetchById(string id){
            Hotel h=new Hotel();
            HttpResponseMessage response =hotelAPIServices.fetchHotelById(id);
            if(response.IsSuccessStatusCode){
                String data = response.Content.ReadAsStringAsync().Result;
                h=JsonConvert.DeserializeObject<Hotel>(data);
                ViewBag.hotels=getHotels();
            }
            
            return View("Update",h);
        }

        public List<Hotel> getHotels(){
            HttpResponseMessage response =hotelAPIServices.fetchHotels();
            if(response.IsSuccessStatusCode){
                String data = response.Content.ReadAsStringAsync().Result;
                hlist=JsonConvert.DeserializeObject<List<Hotel>>(data);
            }
            return hlist;
        }

        [HttpGet]
        [Route("Update")]
        public ActionResult Update()
        {
            
            HttpResponseMessage response =hotelAPIServices.fetchHotels();
            if(response.IsSuccessStatusCode){
                String data = response.Content.ReadAsStringAsync().Result;
                hlist=JsonConvert.DeserializeObject<List<Hotel>>(data);
                ViewBag.hotels=hlist;
            }
            
            return View();
        }
        [HttpPost]
        [Route("Update")]
        public ActionResult Update(Hotel hotel, string hotelId)
        {
            if(ModelState.IsValid){
            
            HttpResponseMessage response = hotelAPIServices.UpdateHotel(hotel,hotelId);
            if(response.IsSuccessStatusCode)
            {
                String data = response.Content.ReadAsStringAsync().Result;
                string s=JsonConvert.DeserializeObject<string>(data);
                if(s=="1")
                {
                    ViewBag.msg="Hotel details updated successfully";
                }
            }
            else{
                String S = response.Content.ReadAsStringAsync().Result;
                ViewBag.msg=S;
            }
            
            }
            ViewBag.hotels=getHotels();
 
            return View();
        }
        [HttpGet]
        [Route("fetchid/{id}")]
        public IActionResult fetchhotelById(string id){
            Hotel h=new Hotel();
            HttpResponseMessage response =hotelAPIServices.fetchHotelById(id);
            if(response.IsSuccessStatusCode){
                String data = response.Content.ReadAsStringAsync().Result;
                h=JsonConvert.DeserializeObject<Hotel>(data);
                ViewBag.hotels=getHotels();
            }
            
            return View("Delete",h);
        }

        [HttpGet]
        [Route("Delete")]
        public ActionResult Delete()
        {
            HttpResponseMessage response =hotelAPIServices.fetchHotels();
            if(response.IsSuccessStatusCode){
                String data = response.Content.ReadAsStringAsync().Result;
                hlist=JsonConvert.DeserializeObject<List<Hotel>>(data);
                ViewBag.hotels=hlist;
            }
            
            return View();
        }
         [HttpPost]
        [Route("Delete")]
        public ActionResult Delete(Hotel hotel, string hotelId)
        {
             ViewBag.hotels=hlist;
            HttpResponseMessage response = hotelAPIServices.deleteHotelById(hotel,hotelId);
            if(response.IsSuccessStatusCode)
            {
                String data = response.Content.ReadAsStringAsync().Result;
                ViewBag.hlist=getallProjects();
            }
            else{
                String S = response.Content.ReadAsStringAsync().Result;
                ViewBag.msg=S;
            }
            return View();
        }

    }
}