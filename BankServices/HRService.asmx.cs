using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BankServices
{
    /// <summary>
    /// Summary description for HRService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HRService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<BankClient> GetAllClients()
        {
            List<BankClient> resultList = new List<BankClient>() {
                new BankClient(){ ClientID=1, ClientName="Norma,W. Castillo" },
                new BankClient(){ ClientID=2, ClientName="Amanda,R. Anderson" },
                new BankClient(){ ClientID=3, ClientName="Patrick,L. Eley" },
                new BankClient(){ ClientID=4, ClientName="Gwendolyn,S. Brooks" },
                new BankClient(){ ClientID=5, ClientName="Brenda,L. Owens" },
                new BankClient(){ ClientID=6, ClientName="Joyce,S. Scheibero" },
                new BankClient(){ ClientID=7, ClientName="Chris,M. Stinson" }
            };
            return resultList;
        }
    }
}
