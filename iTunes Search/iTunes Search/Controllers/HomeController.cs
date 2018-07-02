using iTunes_Search.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace iTunes_Search.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //dropdown list of media types that are searchable
            ViewData["media"] =
                new SelectList(new[]{
                  new SelectListItem{ Text="all", Value="All"},
                  new SelectListItem{ Text="movie", Value="Movie"},
                  new SelectListItem{ Text="podcast", Value="Podcast"},
                  new SelectListItem{ Text="music", Value="Music"},
                  new SelectListItem{ Text="musicVideo", Value="Music Video"},
                  new SelectListItem{ Text="audiobook", Value="Audiobook"},
                  new SelectListItem{ Text="shortFilm", Value="Short Film"},
                  new SelectListItem{ Text="tvShow", Value="TV Show"},
                  new SelectListItem{ Text="software", Value="Software"},
                  new SelectListItem{ Text="ebook", Value="E-book"}
                }, "Text", "Value", "All");

            return View();
        }

        public ActionResult Search()
        {
            //in case we accidentally get to here without running a search
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string query, string media)
        {
            ViewBag.Query = query;

            //make sure we format it for the query string
            string cleanQuery = Uri.EscapeDataString(query);

            string url = $"https://itunes.apple.com/search?media={media}&term={cleanQuery}";

            WebClient client = new WebClient();
            string data = client.DownloadString(url);            

            ResultObject model = JsonConvert.DeserializeObject<ResultObject>(data);

            return View(model);
        }

        public ActionResult Report()
        {
            TrackingDBEntities db = new TrackingDBEntities();

            //for now just get all results, but we could do some fancy 
            //queries here to structure the data as needed
            var data = db.Trackings;
            
            return View(data.ToList());
        }
    }
}