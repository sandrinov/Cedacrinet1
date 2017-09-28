using CedacriData.Models;
using System;
using System.Collections.Generic;


namespace CedacriData.DS
{
    public class CedacriInMemoryDataSource : ICedacriDataSource
    {
        public List<Client> GetAllClients()
        {
            List<Client> lst = new List<Client>();
            Client c1 = new Client() { IDClient = 1, FirstName = "Mario", LastName="Rossi" };
            Client c2 = new Client() { IDClient = 2, FirstName = "Maria", LastName = "Verdi" };
            Client c3 = new Client() { IDClient = 3, FirstName = "Mariotto", LastName = "Bianchi" };
            Client c4 = new Client() { IDClient = 4, FirstName = "Mariolina", LastName = "Gialli" };

            lst.Add(c1);
            lst.Add(c2);
            lst.Add(c3);
            lst.Add(c4);

            return lst;

        }
    }
}
