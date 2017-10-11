using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedacriData.Models
{
    public class Movimento
    {
        public DateTime DataMovimento { get; set; }
        public double Importo { get; set; }
        public String Segno { get; set; }
    }
}
