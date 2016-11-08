using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIF1006Devoir1
{
    class Matrice
    {
        //initialisation
        private double[,] _matrice;

        //constructeur
        public Matrice(double[,] matrice)
        {
            this._matrice = matrice;
        }

        //méthode d'addition de matrice
        public Matrice Additionner(Matrice matrice)
        {
            return null;
        }

        //méthode du produit scalaire
        public Matrice FaireProduitScalaire(double scalaire)
        {
            return null;
        }

        //méthode du produit matriciel
        public Matrice FaireProduitMatriciel(Matrice matrice)
        {
            return null;
        }

        //méthode vérification si triangulaire
        public bool EstTriangulaire(Matrice matrice)
        {
            return false;
        }

        //trace
        public double Trace()
        {
            get (0);
        }

        //determinant
        public double Determinant() { }

        public Matrice Transposee()
        {
        }

        public Matrice CoMatrice()
        {
        }

        public Matrice MatriceInverse() { }

        public bool EstCarree()
        {
            
        }

        public bool EstReguliere() { }


    }
}
