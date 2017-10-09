using CedacriData.DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportelloWeb.Controllers
{
    public class HomeController : Controller
    {
        ICedacriDataSource ds;

        public HomeController()
        {
            ds = new CedacriInMemoryDataSource();
        }
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Greetings = "Hello MVC!";
            return View(ds.GetAllClients());
        }

        //GET /Home/Detail/id
        public ActionResult Detail(int id)
        {
            return View(ds.GetClientByID(id));
        }
    }
}