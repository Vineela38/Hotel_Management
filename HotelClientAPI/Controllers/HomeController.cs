using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HotelClientAPI.Models;

namespace HotelClientAPI.Controllers;

public class HomeController : Controller
{
     [Route("Home")]
        public IActionResult Home()
        {
            return View();
        }
 
     
        [Route("About")]
        public IActionResult About()
        {
            return View();
        }
 
        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }
 
        [Route("Highlights")]
        public IActionResult Highlights()
        {
            return View();
        }
}
