using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LakewoodscoopScraper.data;



namespace LakewoodscoopScraper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var scraper = new Scraper();
            return View(scraper.GetNews());
        }
    }
}