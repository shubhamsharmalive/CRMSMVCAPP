using CRMSMVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//QR Code Generator
using QRCoder;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace CRMSMVCAPP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AutoCompleteCity()
        {
            ViewBag.Message = "Your contact page.";

            CityDetails cityDetails = new CityDetails();

            List<ValueNamePair> CountryList = new List<ValueNamePair>
        {
            new ValueNamePair { Value = "IND", Name ="India"},
            new ValueNamePair { Value = "PKN", Name ="Pakistan"},
            new ValueNamePair { Value = "JPN", Name ="Japan"},
            new ValueNamePair { Value = "RSA", Name ="Russia"},
            new ValueNamePair { Value = "FR", Name ="France"},
            new ValueNamePair { Value = "USA", Name ="America"},
            new ValueNamePair { Value = "AUS", Name ="Australia"},
            new ValueNamePair { Value = "BNG", Name ="Bangladesh"},
            new ValueNamePair { Value = "CHI", Name ="China"},
            new ValueNamePair { Value = "CAN", Name ="Canada"},
            new ValueNamePair { Value = "BRZ", Name ="Brazil"},

        };

            cityDetails.CoutryList = new SelectList(CountryList, "Value", "Name", "");

            return View(cityDetails);
        }

        [HttpPost]
        public JsonResult GetCityDetails(string Prefix)
        {
            //Note : you can bind same list from database  
            List<CityDetails> ObjList = new List<CityDetails>()
            {

                new CityDetails {Id=3,Name="Pune" },
                new CityDetails {Id=4,Name="Delhi" },
                new CityDetails {Id=5,Name="Dehradun" },
                new CityDetails {Id=6,Name="Noida" },
                new CityDetails {Id=7,Name="New Delhi" },
                new CityDetails {Id=1,Name="Latur" },
                new CityDetails {Id=2,Name="Mumbai" },
                new CityDetails {Id=13,Name="Indore" },
                new CityDetails {Id=14,Name="Bhopal" },
                new CityDetails {Id=15,Name="Ranchi" },
                new CityDetails {Id=16,Name="Patna" },
                new CityDetails {Id=17,Name="Kolkata" },
                new CityDetails {Id=11,Name="Banglore" },
                new CityDetails {Id=12,Name="Hyderabad" },
                new CityDetails {Id=24,Name="Jaipur" },
                new CityDetails {Id=25,Name="Shimla" },
                new CityDetails {Id=26,Name="Gurgaon" },
                new CityDetails {Id=27,Name="Nagpur" },
                new CityDetails {Id=21,Name="Andman" },
                new CityDetails {Id=22,Name="Gangtok" },
                new CityDetails {Id=23,Name="Gujrat" }

            };

            //Searching records from list using LINQ query  
            var Name = (from N in ObjList
                        where N.Name.Contains(Prefix.ToLower()) || N.Name.Contains(Prefix.ToUpper()) //StartsWith
                        select new { N.Name });
            return Json(Name, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewPDF()
        {
            return View();
        }

        public PartialViewResult _PDFView(string name)
        {
            return PartialView("_PDFView");

        }

        public ActionResult Charts()
        {
            return View();
        }

        public ActionResult SessionStorage()
        {
            return View();
        }

        public ActionResult GenerateQRCode()
        {
            return View();
        }

        [HttpPost]
        public ViewResult GenerateQRCode(QRCodeModel model)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(model.qrcode, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    bitMap.Save(ms, ImageFormat.Png);
                    ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }

            return View("GenerateQRCode");
        }

        public ActionResult TextToSpeech()
        {
            return View();
        }

    }
}