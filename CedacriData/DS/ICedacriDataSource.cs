using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedacriData.DS
{
    public interface ICedacriDataSource
    {
        List<Models.Client> GetAllClients();
        Models.Client GetClientByID(int IDClient);
        Models.Client GetClientByClientName(String firstName, String lastName);
        void Deposit(int IDClient, double import);
        bool Withdraw(int IDClient, double import);
        Models.ContoCorrente GetContoByID(int IDConto);
    }
}
