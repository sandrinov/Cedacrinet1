using CedacriData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CedacriData.DS
{
    public class CedacriInMemoryDataSource : ICedacriDataSource
    {
        private List<Client> lst;
        public CedacriInMemoryDataSource()
        {
            lst = new List<Client>();
            Client c1 = new Client() { IDClient = 1, FirstName = "Mario", LastName = "Rossi" };
            Client c2 = new Client() { IDClient = 2, FirstName = "Maria", LastName = "Verdi" };
            Client c3 = new Client() { IDClient = 3, FirstName = "Mariotto", LastName = "Bianchi" };
            Client c4 = new Client() { IDClient = 4, FirstName = "Mariolina", LastName = "Gialli" };
            lst.Add(c1);
            lst.Add(c2);
            lst.Add(c3);
            lst.Add(c4);
        }

        public void Deposit(int IDClient, double import)
        {
            Client cli = GetClientByID(IDClient);
            cli.Conto.Balance += import;
        }

        public List<Client> GetAllClients()
        {
            return lst;
        }

        public Client GetClientByClientName(string firstName, string lastName)
        {
            return lst.Where(c => c.FirstName == firstName && c.LastName == lastName).FirstOrDefault();
        }

        public Client GetClientByID(int IDClient)
        {
            #region classic method
            //Client client = null;
            //foreach (Client c in lst)
            //{
            //    if (c.IDClient == IDClient)
            //    {
            //        client = c;
            //        break;
            //    }
            //}
            //return client;
            #endregion

            //LINQ to Object
            return lst.Where(c => c.IDClient == IDClient).FirstOrDefault();
        }

        public ContoCorrente GetContoByID(int IDConto)
        {
            throw new NotImplementedException();
        }

        public bool Withdraw(int IDClient, double import)
        {
            bool result = true;
            Client cli = GetClientByID(IDClient);
            if (cli.Conto.Balance > import)
                cli.Conto.Balance -= import;
            else
                result = false;
            return result;
        }
    }
}
