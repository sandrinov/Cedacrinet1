using CedacriData.DS;
using CedacriData.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SportelloWeb.Controllers
{
    public class HomeController : Controller
    {
        ICedacriDataSource ds;
        private HttpClient client = new HttpClient();

        public HomeController()
        {
            ds = new CedacriInMemoryDataSource();
            client.BaseAddress = new Uri("http://localhost:6249/");
        }
        // GET: Home
        public async Task<ActionResult> Index()
        {
            //ViewBag.Greetings = "Hello MVC!";
            //return View(ds.GetAllClients());
            var api_url = "api/allclients";
            var model = new List<Client>();
            HttpResponseMessage egsResponse = await client.GetAsync(api_url);
            if (egsResponse.IsSuccessStatusCode)
            {
                string content = await egsResponse.Content.ReadAsStringAsync();
                // get the paging info from the header
                var clients = JsonConvert.DeserializeObject<List<Client>>(content);

                model = clients;
            }
            else
            {
                return Content("An error occurred.");
            }
            return View(model);
        }

        //GET /Home/Detail/id
        [HttpGet]
        public async Task<ActionResult> Detail(int id)
        {
            //return View(ds.GetClientByID(id));
            var api_url = "api/client?id=" + id;
            var model = new Client();
            HttpResponseMessage egsResponse = await client.GetAsync(api_url);
            if (egsResponse.IsSuccessStatusCode)
            {
                string content = await egsResponse.Content.ReadAsStringAsync();
                // get the paging info from the header
                var client = JsonConvert.DeserializeObject<Client>(content);

                model = client;
            }
            else
            {
                return Content("An error occurred.");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Detail(int id, string import)
        {
            CedacriData.Models.Client cli = ds.GetClientByID(id);
            ds.Deposit(cli.IDClient, Double.Parse(import));
            return View(cli);
        }

        public ActionResult OpenAccount(int id)
        {
            return View();
        }

    }
}