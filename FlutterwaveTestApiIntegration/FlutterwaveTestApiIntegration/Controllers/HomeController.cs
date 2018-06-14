using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using FlutterwaveTestApiIntegration.App_Code;



namespace FlutterwaveTestApiIntegration.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

           
            return View();
        }




      



    public ActionResult Validate(string TransactionId)
        {
            
        var data = new { txref = "rave-123568", SECKEY = "FLWSECK-7766fb06695e63a44f9145fedc89bcb6-X", include_payment_entity = 1 };
        var client = new HttpClient(); /*OH - AAED44*/
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var responseMessage = client.PostAsJsonAsync("https://ravesandboxapi.flutterwave.com/flwv3-pug/getpaidx/api/xrequery", data).Result;
        var responseStr = responseMessage.Content.ReadAsStringAsync().Result;
        var response = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse>(responseStr);
            if (response.data.status == "successful" && response.data.amount == "2000" && response.data.chargecode == "00")
            {

                ViewBag.Status = "Successful";

            }
            else
            {
                ViewBag.Status = "Failed";
            }
            return View();
        }
    }
}
