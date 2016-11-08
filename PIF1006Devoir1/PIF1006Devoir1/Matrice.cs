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

        public int GetLength(int dimension)
        {
            return _matrice.GetLength(dimension);
        }

        public double this[int i, int j]
        {
            get { return this[i, j];}
            set { this[i, j] = value; }
        }

        //méthode de vérification même format de matrice
        public bool VerifierFormatMatrice(Matrice matrice)
        {
            if ( _matrice.GetLength(0) == matrice.GetLength(0) && _matrice.GetLength(1) == matrice.GetLength(1))
            {
                return true;
            }

            else return false;
        }

        //méthode vérification prérequis multiplication
        public bool VerifierColonneAcommeLigneB(Matrice matrice)
        {
            if (_matrice.GetLength(1) == matrice.GetLength(0))
            return true;
            else
            return false;
        }


        //méthode d'addition de matrice
        public Matrice Additionner(Matrice matrice)
        {
            if (VerifierFormatMatrice(matrice) == true)
            {
                Matrice addition = new Matrice(new double[_matrice.GetLength(0) ,_matrice.GetLength(1)]);
                for (int i = 0; i < matrice.GetLength(0); i++)
                {
                    for (int j = 0; j < matrice.GetLength(1); j++)
                    {
                        addition[i, j] = matrice[i, j] + matrice[i, j];
                    }
                }
                return addition;
            }
            else
            {
                return null;
            }
        }

        //méthode du produit scalaire
        public Matrice FaireProduitScalaire(double scalaire)
        {
            int x = _matrice.GetLength(0);
            int y = _matrice.GetLength(1);
            Matrice produitScalaire = new Matrice(new double[x,y]);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    produitScalaire[i, j] = _matrice[i, j] * scalaire;
                }
            }

            return produitScalaire;
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
        public double Trace
        {
            get
            {
                return 0;
            }
        }

        //determinant
        public double Determinant {
            get
            {
                return 0;
            }
        }

        public Matrice Transposee
        {
            get
            {
                return null;
            }
        }

        public Matrice CoMatrice
        {
            get
            {
                return null;
            }
        }

        public Matrice MatriceInverse {
            get
            {
                return null;
            }
        }

        public bool EstCarree
        {
            get
            {
                return false;
            }
        }

        public bool EstReguliere {
            get
            {
                return false;
            }
        }


    }
}
