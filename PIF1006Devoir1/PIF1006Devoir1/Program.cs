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
            Matrice matrice1 = new Matrice(new double[3, 3] { { 3, 4, 1 }, { 4, 1, 2 }, { 4, 0, 2 } });
            Matrice matriceA = new Matrice(new double[,] { { 1, 2, 5, 4 }, { 3, 4, 3, 4 }, { 5, 6, 3, 7 }, { 7, 3, 5, 8 } });


            bool a = matriceA.EstCarree();
            Console.WriteLine("Is matriceA sqaure ?" + a);
            Console.WriteLine("Appuyer sur Enter pour fermer");

            Console.ReadLine();
        }
    }
}
