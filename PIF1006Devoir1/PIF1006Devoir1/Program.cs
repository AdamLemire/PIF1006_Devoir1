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
   
                Matrice matrice1 = new Matrice(new double[3, 3] {{3, 4, 1}, {4, 1, 2}, {4, 0, 2}}); 
                Matrice matrice2 = new Matrice(new double[2, 3] {{1, 2, 1}, {1, 2, 1}});
                Matrice matrice3 = new Matrice(new double[3, 2] {{3, 2}, {1, 2}, {1, 1}});
                Matrice matrice4 = new Matrice(new double[2, 2] {{3, 2}, {4, 5}}); 
                Matrice matrice5 = new Matrice(new double[4, 4] {{4, 2, 8, 3}, {5, 1, 7, 5}, {8, 0, 8, 5}, {3, 2, 3, 8}});
                   
                Matrice matrice6 = new Matrice(new double[3, 3] {{1, 2, -1}, {-2, 1, 1}, {0, 3, -3}});
                Matrice matrice7 = new Matrice(new double[4, 4] { { 0, 2, 8, 3 }, { 0, 0, 7, 5 }, { 0, 0,0, 5 }, { 0, 0, 0, 0 } });



            //Additionner
            Console.WriteLine("--------------Addition----------------");

            (matrice1.Additionner(matrice6)).AfficheMatrice();
            Console.WriteLine();
            //Produit Scalaire
            Console.WriteLine("----------Produit Scalaire----------------");
            matrice1.FaireProduitScalaire(6).AfficheMatrice();
            Console.WriteLine();
            //Produit de matrices
            Console.WriteLine("--------------Produit----------------");
            int a = 0;
            (matrice2.FaireProduitMatriciel(out a, matrice3, matrice4)).AfficheMatrice();
            Console.WriteLine("Nombre de produits effectues : "+a);
            Console.WriteLine();
            //Triangulaire ?
            Console.WriteLine("--------------Triangulaire?----------------");
            bool m = matrice7.EstTriangulaire(1, true);
            matrice7.AfficheMatrice();
            Console.WriteLine("La matrice 7 est elle superieure strict ? " +m);
            Console.WriteLine();
            Console.WriteLine();
            //Trace
            Console.WriteLine("--------------Trace----------------");
            double n =  matrice5.Trace;
            matrice5.AfficheMatrice();
            Console.WriteLine("La matrice 5 a une trace equivalent à " + n);
            Console.WriteLine();
            //Determinant
            Console.WriteLine("--------------Determinant----------------");
            double c = matrice5.Determinant;
            Console.WriteLine("Le determinant de la matrice 5 est de "+c);
            Console.WriteLine();

            //Transposee
            Console.WriteLine("------------Transposee----------------");
            Console.WriteLine("matrice 6 avant");
            matrice6.AfficheMatrice();
            Console.WriteLine("matrice 6 apres");
            matrice6.Transposee.AfficheMatrice();
            Console.WriteLine();
            //Comatrice
            Console.WriteLine("------------Comatrice----------------");
            Console.WriteLine("matrice 4 avant operation");
            matrice4.AfficheMatrice();
            Console.WriteLine("Apres");
            matrice4.Comatrice.AfficheMatrice();
            Console.WriteLine();

            //Matrice inverse
            Console.WriteLine("------------Matrice Inverse----------------");
            Console.WriteLine("matrice 5 avant operation");
            matrice5.AfficheMatrice();
            Console.WriteLine("Apres operation");
            matrice5.MatriceInverse.AfficheMatrice();

            Console.WriteLine();

            //Est reguliere ?
            Console.WriteLine("--------------Matrice Reguliere?----------------");
            bool o = matrice3.EstReguliere;
            double p = matrice3.Determinant;
            Console.WriteLine("Le determinant de la matrice 3 est de " + p);
            Console.WriteLine("La matrice 3 est elle reguliere ? " + o);
            Console.WriteLine();


            Console.WriteLine("Appuyer sur Enter pour fermer");

                Console.ReadLine();
            

        }
    }
}
