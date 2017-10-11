using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedacriData.Models
{
    public class ContoCorrente
    {
        private Random rnd;
        public ContoCorrente()
        {
            rnd = new Random(DateTime.Now.Millisecond);
            Movimenti = new List<Movimento>();
            this.ID = rnd.Next(100);
            //this.Numconto = RandomString(12);
            //this.Balance = 0;
        }
        public int ID { get; set; }
        public String Numconto { get; set; }
        public double Balance { get; set; }
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        public List<Movimento> Movimenti { get; set; }
    }
    
}
