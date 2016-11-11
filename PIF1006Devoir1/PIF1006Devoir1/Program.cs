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
            Matrice matrice1 = new Matrice(new double[3,3]{{3,4,1},{4,1,2},{4,0,2}}) ; //det -2
            Matrice matrice2 = new Matrice(new double[2, 3] { { 1, 2, 1}, { 1, 2, 1} });
            Matrice matrice3 = new Matrice(new double[3, 2] { { 3, 2 }, { 1, 2 }, {1,1} });
            Matrice matrice4 = new Matrice(new double[2, 2] { { 3, 2}, { 4, 5 } }); //det -14
            Matrice matrice5 = new Matrice(new double[4, 4] { {4,2,8,3}, { 5,1,7,5 }, {8,0,8,5}, {3,2,3,8} }); //det=104
            Matrice matrice6 = new Matrice(new double[3, 3] { { 1, 2, -1 }, { -2, 1, 1 }, { 0, 3,-3 } });

            //double a = matrice2.CalculDeterminant();
            //double b = matrice3.CalculDeterminant();
            int a = 0;
            (matrice2.FaireProduitMatriciel(out a, matrice3, matrice4)).AfficheMatrice();
            Console.WriteLine(a);
            double c = matrice5.Determinant;
            //double d = Matrice.DetTest(matrice5, 4);
            //double mineure = (matrice1.Mineure(0, 0)).CalculDeterminant();
            Console.WriteLine(c);
            Console.WriteLine("Matrice 2");
            matrice2.AfficheMatrice();
            Console.WriteLine("2 * Matrice 2");
            (matrice2.FaireProduitScalaire(2)).AfficheMatrice();
            Console.WriteLine("Matrice 5");
            matrice5.AfficheMatrice();
            Console.WriteLine("Matrice 2 * matrice 3");
            (matrice2.FaireProduitMatriciel(matrice3)).AfficheMatrice();
            Console.WriteLine("comatrice de matrice 4");
            Matrice matricex = matrice2.Comatrice;//.AfficheMatrice();
            Console.WriteLine("matrice inverse de matrice 6");
            (matrice5.MatriceInverse).AfficheMatrice();

            Console.WriteLine("matrice 6 comatrice");
            (matrice6.Comatrice).AfficheMatrice();

            Console.WriteLine("matrice 6 case 0,0 modifiee");
            matrice6[0, 0] = 55;
            Console.WriteLine(matrice6[2, 2]);
            matrice6.AfficheMatrice();
            
            Console.WriteLine("Appuyer sur Enter pour fermer");

            Console.ReadLine();

        }
    }
}
