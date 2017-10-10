using CedacriData.DS;
using CedacriData.Models;
using Newtonsoft.Json;
using SportelloWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public async Task<ActionResult> Detail(int id, Movimento mov)
        {
            //CedacriData.Models.Client cli = ds.GetClientByID(id);
            //ds.Deposit(cli.IDClient, Double.Parse(import));
            //return View(cli);
            var api_url = "";
            if (mov.Segno == "+")
               api_url = "api/deposit?id=" + id + "&import=" + mov.Importo;
            else
                api_url = "api/withdraw?id=" + id +"&import=" + mov.Importo;
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
        
        [HttpGet]
        public ActionResult OpenAccount(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> OpenAccount(int id, ContoCorrente account)
        {
            var api_url = "api/createaccount?id=" + id;
            var model = new Client();

            String jsonAccount = JsonConvert.SerializeObject(account);
            var httpContent = new StringContent(jsonAccount, Encoding.UTF8, "application/json");
            HttpResponseMessage egsResponse = await client.PostAsync(api_url, httpContent);

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
            return RedirectToAction("Detail", new { id = id });
        }

    }
}