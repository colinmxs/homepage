using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace kennygreenfingers.com.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var twitter = WebRequest.Create("http://treefortservices.azurewebsites.net/api/twitter?handle=colinmxs");
            var twitterResponse = await twitter.GetResponseAsync();
            using (var stream = twitterResponse.GetResponseStream())
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var serializer = new JavaScriptSerializer();
                        var json = serializer.Deserialize<string[]>(await reader.ReadToEndAsync());

                        ViewBag.Tweet = json[0];

                    }
                }
            }
            return View();
        }                 
    }
}