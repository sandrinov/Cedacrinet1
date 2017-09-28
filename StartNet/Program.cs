using System;

namespace StartNet
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = 20;
            String z = "Risultato somma: ";
            //int somma = Sum(x, y);
            CedacriMath.Math math = new CedacriMath.Math();
            int somma = math.Somma(x, y);
            Console.WriteLine(z + somma);
        }
        private static int Sum(int add1, int add2)
        {
            return add1 + add2;
        }
    }
}
