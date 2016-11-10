using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIF1006Devoir1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matriceA = new double[,] { { 1, 2, 5, 4 }, { 3, 4 ,3 ,4 }, { 5, 6 ,3 ,7 }, { 7, 3, 5, 8 } };
            matriceA.EstCarree();
        }
    }
}
