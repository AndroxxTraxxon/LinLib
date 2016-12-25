using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinLib;

namespace LinLibExec
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector a = new Vector();
            Vector b = new Vector(3);
            double[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Vector c = new Vector(3, 4, values);
            Vector d = new Vector(c.To2DArray());
            Vector e = d.Squared();
            Console.Write("" + a.ToString() + b.ToString() + c.ToString() + d.ToString() + e.ToString());
            Console.WriteLine("Press <ANY> key to continue...");
            Console.ReadKey();
            return;
        }
    }
}
