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
    }
}
