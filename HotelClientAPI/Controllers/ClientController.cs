using HotelClientAPI.Models.APIServices;
using HotelClientAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace HotelClientAPI.Controllers;
[Route("[controller]")]
public class ClientController : Controller
{
    private readonly HotelAPIServices customerAPI;
    private IHttpContextAccessor Accessor;
    public ClientController(HotelAPIServices customerAPI,IHttpContextAccessor _accessor)
    {
        this.customerAPI = customerAPI;
        Accessor=_accessor;
    }

    [HttpGet]
    [Route("Signup")]
    public ActionResult Signup()
    {
        SignUp s = new SignUp();
        return View(s);
    }

    [HttpPost]
    [Route("Signup")]
    public ActionResult signup(SignUp S)
    {
        HttpResponseMessage response = customerAPI.insertHotel(S);


        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            string? s = JsonConvert.DeserializeObject<string>(data);
            TempData["PopUpMessage"] = "Customer Registered Successfully";
           
        }
        else
        {
            string data = response.Content.ReadAsStringAsync().Result;
            string? s = JsonConvert.DeserializeObject<string>(data);
            TempData["PopUpMessage"] = "Check your inputs";

        
        }
        return View();
    }


    [HttpGet]
    [Route("Login")]
    public ActionResult login()
    {

        Login l = new Login();
        return View(l);
    }

    [HttpPost]
    [Route("Login")]
    public IActionResult login(Login login)
    {
        HttpResponseMessage response = customerAPI.Login(login);

        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            string str = JsonConvert.DeserializeObject<String>(data);

            if (str == "Admin")
            {
                HttpContext.Session.SetString("usertype","Admin");
                return RedirectToAction("insert","HotelClient");
                TempData["PopUpMessage"] = "Welcome to Admin Page";
            }
            else if (str == "Customer")
            {
                HttpContext.Session.SetString("usertype","Customer");
                return RedirectToAction("GetByCity","HotelBookings");
                TempData["PopUpMessage"] = "Welcome to Customer Page";

            }
        }

        else
        {
            string str = response.Content.ReadAsStringAsync().Result;
            TempData["PopUpMessage"] = "Check your inputs";
           

        }
        ModelState.Clear();
        return View();
    }

    
    [HttpGet]
    [Route("Logout")]
    public IActionResult Logout(Login login)
    {
        HttpContext.Session.Remove("usertype");
      //  Response.Cookies.Delete("usertype",utype);
       // string name =HttpContext.Session.GetString("usertype").ToString();
 
        return RedirectToAction("Login", "Client");
    }
    

    [HttpGet]
    [Route("ForgotPassword")]
    public ActionResult ForgotPassword()
    {
        ForgotPassword forgotPassword = new ForgotPassword();
        return View(forgotPassword);

    }

    [HttpPost]
    [Route("ForgotPassword")]

    public IActionResult ForgotPassword(string Email, string MobileNo)
    {

        HttpResponseMessage response = customerAPI.Forgotpassword(Email, MobileNo);

        if (response.IsSuccessStatusCode)
        {

            string data = response.Content.ReadAsStringAsync().Result;
            string str = JsonConvert.DeserializeObject<String>(data);

            ViewBag.msg = str;

        }

        else
        {
            string data = response.Content.ReadAsStringAsync().Result;
            string s = JsonConvert.DeserializeObject<String>(data);

            ViewBag.msg = s;

        }

        return View();


    }


    








    [Route("Admin")]
    public ActionResult Admin()
    {

        return View();
    }

    [Route("Customer")]
    public ActionResult Customer()
    {

        return View();
    }




}


