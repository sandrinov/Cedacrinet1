using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedacriData.DS
{
    public class CedacriWebServiceDataSource : ICedacriDataSource
    {
        Bank.services.HRService proxy;
        public CedacriWebServiceDataSource()
        {
            proxy = new Bank.services.HRService();
        }
        public List<Models.Client> GetAllClients()
        {
            List<Models.Client> resultList = new List<Models.Client>();
            Bank.services.BankClient[] bankClients = proxy.GetAllClients();
            foreach (Bank.services.BankClient bankClient in bankClients)
            {
                String[] clientName = bankClient.ClientName.Split(new char[] { ',' });
                Models.Client client = new Models.Client()
                {
                    IDClient = bankClient.ClientID,
                    FirstName = clientName[0],
                    LastName = clientName[1]
                };
                resultList.Add(client);
            }
            return resultList;
        }
    }
}
