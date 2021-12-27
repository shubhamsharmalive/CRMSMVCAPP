using CRMSMVCAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CRMSMVCAPP.Controllers
{
    public class UserDetailsController : Controller
    {
        List<UserDetails> userDetails = new List<UserDetails>();
        // GET: UserDetails
        public ActionResult Index()
        {
            return View();
        }

      
        // GET: UserDetails
        public async Task<ActionResult> GetUserDetails()
        {

            //userDetails.Add(new UserDetails() { UserId = 1, FirstName = "Shubham", LastName = "Sharma", Mobile = 98765, Email = "ss@gmail.com", PackageId = 101 });
            //userDetails.Add(new UserDetails() { UserId = 2, FirstName = "Shubham", LastName = "Sharma", Mobile = 98765, Email = "ss@gmail.com", PackageId = 102 });
            //userDetails.Add(new UserDetails() { UserId = 3, FirstName = "Shubham", LastName = "Sharma", Mobile = 98765, Email = "ss@gmail.com", PackageId = 103 });

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("https://localhost:5001/api/User/GetUserDetails");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    userDetails = JsonConvert.DeserializeObject<List<UserDetails>>(EmpResponse);
                }

            }
            return View(userDetails);
        }

        // Post: CreateUserDetails
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserDetails obj)
        {
            if (ModelState.IsValid)
            {
                //UserDetails userDetails = new UserDetails();
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    var myContent = JsonConvert.SerializeObject(obj);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage Res = await client.PostAsync("https://localhost:5001/api/User/CreateCRMSUser", byteContent);
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list

                    }
                }
            }
            return View(obj);
        }

        public ActionResult PackageDetails(PackageDetails obj)
        {
            PackageService.Service1Client packageServiceClient = new PackageService.Service1Client();
            PackageService.PackageDetails packageDetails =  packageServiceClient.GetPackageData(obj.PackageId);

            return View(packageDetails);
        }

    }
}