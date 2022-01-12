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


        //called from userdetails.js
        public async Task<ActionResult> GetAllUserDetails()
        {

            userDetails.Add(new UserDetails() { UserId = 1, FirstName = "Shubham", LastName = "Sharma", Mobile = 98765, Email = "ss@gmail.com", PackageId = 101 });
            userDetails.Add(new UserDetails() { UserId = 2, FirstName = "Shivam", LastName = "Shukla", Mobile = 98765, Email = "ss@gmail.com", PackageId = 102 });
            userDetails.Add(new UserDetails() { UserId = 3, FirstName = "Ankur", LastName = "Sharma", Mobile = 98765, Email = "ss@gmail.com", PackageId = 103 });
            userDetails.Add(new UserDetails() { UserId = 4, FirstName = "Ajay", LastName = "Singh", Mobile = 45664, Email = "ss@gmail.com", PackageId = 104 });
            userDetails.Add(new UserDetails() { UserId = 5, FirstName = "Arvind", LastName = "Nirav", Mobile = 98765, Email = "ss@gmail.com", PackageId = 106 });
            userDetails.Add(new UserDetails() { UserId = 5, FirstName = "Bhaskar", LastName = "Sharma", Mobile = 3445566, Email = "ss@gmail.com", PackageId = 107 });
            userDetails.Add(new UserDetails() { UserId = 6, FirstName = "Garima", LastName = "Pandey", Mobile = 98765, Email = "ss@gmail.com", PackageId = 108 });
            userDetails.Add(new UserDetails() { UserId = 7, FirstName = "Gaurav", LastName = "Kishore", Mobile = 67544, Email = "ss@gmail.com", PackageId = 109 });
            userDetails.Add(new UserDetails() { UserId = 8, FirstName = "Sanjay", LastName = "Patil", Mobile = 455665, Email = "ss@gmail.com", PackageId = 110 });
            userDetails.Add(new UserDetails() { UserId = 9, FirstName = "Jay", LastName = "Billa", Mobile = 345566, Email = "ss@gmail.com", PackageId = 106 });
            userDetails.Add(new UserDetails() { UserId = 10, FirstName = "Vikas", LastName = "Lal", Mobile = 76544, Email = "ss@gmail.com", PackageId = 104 });
            userDetails.Add(new UserDetails() { UserId = 11, FirstName = "Bhairav", LastName = "Das", Mobile = 23455, Email = "ss@gmail.com", PackageId = 105 });
            userDetails.Add(new UserDetails() { UserId = 12, FirstName = "Ansi", LastName = "Block", Mobile = 6676788, Email = "ss@gmail.com", PackageId = 110 });

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
            return Json(userDetails);
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