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
            Matrice matrice1 = new Matrice(new double[3,3]{{3,4,1},{4,1,2},{4,0,2}}) ;
            Matrice matrice2 = new Matrice(new double[2, 2] { { 1, 2}, { 1, 2} });
            Matrice matrice3 = new Matrice(new double[2, 2] { { 3, 2 }, { 1, 2 } });

            double a = matrice2.CalculDeterminant();
            double b = matrice3.CalculDeterminant();
            
            double c = matrice1.Determinant;
            Console.WriteLine("matrice 2)" + a + " , matrice 3)" + b + " , matrice 1)" + c);
            Console.WriteLine("Appuyer sur Enter pour fermer");

            Console.ReadLine();

        }
    }
}
