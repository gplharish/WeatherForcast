using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherForcast.Models;

namespace WeatherForcast.Controllers
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

        [Authorize]
        public ActionResult Weather()
        {
            string sourceURL = "https://www.metaweather.com/api/location/44544/";
            string responseFromServer = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create(sourceURL);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:24.0)";

            WeatherViewModel weatherResponse = null;
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                using (Stream dataStream = response.GetResponseStream())
                using (var reader = new StreamReader(dataStream ?? throw new InvalidOperationException("Response Stream was null")))
                {
                    responseFromServer = reader.ReadToEnd();
                    weatherResponse = JsonConvert.DeserializeObject<WeatherViewModel>(responseFromServer);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            IList<consolidated_weather> consolidatedWeather = weatherResponse.consolidated_weather;
            consolidatedWeather = consolidatedWeather.Take(5).ToList();
            return View(consolidatedWeather);
        }
    }
}