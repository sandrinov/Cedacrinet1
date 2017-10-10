using CedacriData.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;

namespace CedacriAPIService.Controllers
{
    public class ClientManagerController : ApiController
    {
        private List<Client> lst;
        public ClientManagerController()
        {
            lst = new List<Client>();
            var json = File.ReadAllText(
                System.Web.Hosting.HostingEnvironment.MapPath(@"~/Data/clients.json"));
            lst = JsonConvert.DeserializeObject<List<Client>>(json);
        }
        [Route("api/allclients", Name = "ClientsList")]
        public IHttpActionResult GetAll()
        {
            #region oldstyle
            //Client c1 = new Client() { IDClient = 1, FirstName = "Mario", LastName = "Rossi" };
            //Client c2 = new Client() { IDClient = 2, FirstName = "Maria", LastName = "Verdi" };
            //Client c3 = new Client() { IDClient = 3, FirstName = "Mariotto", LastName = "Bianchi" };
            //Client c4 = new Client() { IDClient = 4, FirstName = "Mariolina", LastName = "Gialli" };
            //lst.Add(c1);
            //lst.Add(c2);
            //lst.Add(c3);
            //lst.Add(c4);
            #endregion           
            return Ok(lst);
        }

        [Route("api/client", Name = "GetClientByID")]
        public IHttpActionResult GetClientByID(int id)
        {
            Client cli = lst.Where(c => c.IDClient == id).FirstOrDefault();
            return Ok(cli);
        }

        [Route("api/createaccount", Name = "CreateAccount")]
        [HttpPost]
        public IHttpActionResult CreateAccount(int id, ContoCorrente account)
        {
            Client cli = lst.Where(c => c.IDClient == id).FirstOrDefault();
            cli.Conto = account;
            Persist();
            return Ok(cli);
        }
        [HttpGet]
        [Route("api/deposit", Name = "Deposit")]
        public IHttpActionResult Deposit(int id, double import)
        {
            Client cli = lst.Where(c => c.IDClient == id).FirstOrDefault();
            cli.Conto.Balance += import;
            Persist();
            return Ok(cli);
        }
        [HttpGet]
        [Route("api/withdraw", Name = "Withdraw")]
        public IHttpActionResult Withdraw(int id, double import)
        {
            Client cli = lst.Where(c => c.IDClient == id).FirstOrDefault();
            cli.Conto.Balance -= import;
            Persist();
            return Ok(cli);
        }

        private void Persist()
        {
            File.WriteAllText(HostingEnvironment.MapPath(@"~/Data/clients.json"),
                JsonConvert.SerializeObject(lst));
        }
    }
}
