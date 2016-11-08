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
            if(_matrice.GetLength(0)==matrice.GetLenght(0) && _matrice.GetLength(1) == matrice.GetLenght(1))
            {
                double[,] matriceResultante = new double[matrice.GetLenght(0), matrice.GetLenght(1)];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matriceResultante[i, j] = _matrice[i, j] + matrice[i, j];
                    }
                }
                return matriceResultante;
            }
            else
            {
                Console.WriteLine("Les deux matrice ne sont pas de meme dimension.");
            }
            
        }

        //savoir si deux methodes sont de memes dimensions
        public int GetLenght(int dimension)
        {
            return matrice.GetLenght(dimension);
        }


        //méthode du produit scalaire
        public Matrice FaireProduitScalaire(double scalaire)
        {
            int n = _matrice.GetLength(0);
            int m = _matrice.GetLength(1);

            double[,] matriceResultante = new double[n, m];

            for(int i = 0; i < n; i++)
            {
                for (int j=0; j<m;j++)
                {
                    matriceResultante[i, j] = _matrice[i, j] * scalaire; 
                }
            }

    
            return matriceResultante;
        }

        //méthode du produit matriciel
        public Matrice FaireProduitMatriciel(Matrice matrice)
        {
            //si le nombre de colonnes de A est égal au nombre de lignes de B
            if (_matrice.GetLength(1) == matrice.GetLength(0))
            {
                int n = _matrice.GetLength(0);
                int p = matrice.GetLength(1);
                double[,] matriceResultante = new double[n, p];


                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < p; j++)
                    {
                        matriceResultante[i, j] = 0;
                        for (int z = 0; z < n; z++)
                            matriceResultante[i, j] += _matrice[i][z] * matrice[z][j];

                    }
                }
                return matriceResultante;
            }
            else
            {
                Console.WriteLine("Produit de ces deux matrices non possible");
            }
            
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


       /* //affichage du tableau final
        public void afficheSeparateur(int n)
        {
            for (int i = 0; i < n; i++)
                console.WriteLine("+---+");
        }

        public void afficheTab(int tab[n, m])
        {
            int i, j;

            for (i = 0; i < H; i++)
            {
                afficheSeparateur(m);
                for (j = 0; j < W; j++)
                {
                    console.WriteLine("| " + tab[i][j]) + " |";
                }
            }
            afficheSeparateur(m);
        }*/
    }
}
