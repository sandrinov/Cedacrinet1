using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedacriData.Models
{
    public class Client
    {
        public Client()
        {
            Conto = new ContoCorrente();
        }
        public int IDClient { get; set; }
        public String FirstName { get; set; }
        public String  LastName { get; set; }

        public ContoCorrente Conto { get; set; }
    }
}
