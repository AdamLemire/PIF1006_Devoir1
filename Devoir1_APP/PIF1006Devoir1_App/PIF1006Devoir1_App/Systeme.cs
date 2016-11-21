using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIF1006Devoir1
{
    class Systeme
    {
        //initialisation
        private Matrice _matriceCarree, _matrice1N;

        //constructeur
        public Systeme(Matrice matriceCarree, Matrice matrice1N)
        {
            if (matriceCarree.EstCarree && matrice1N.GetLength(1) == 1 && matriceCarree.GetLength(0) == matrice1N.GetLength(0))
            {
                _matriceCarree = matriceCarree;
                _matrice1N = matrice1N;
            }
            else
            {
                Console.WriteLine("Format de matrice incorrect");
            }


        }

        //propriété de _matriceCarree
        public Matrice MatriceCarree
        {
            get { return _matriceCarree; }
            set { _matriceCarree = value; }
        }

        //propriété de _matrice1N
        public Matrice Matrice1N
        {
            get { return _matrice1N; }
            set { _matrice1N = value; }
        }

        //Méthode de Cramer
        public Matrice TrouverXParCramer()
        {
            if (_matriceCarree.Determinant != 0)
            {
                int n = _matriceCarree.GetLength(0);
                Matrice X = new Matrice((new double[n, 1]));
                Matrice AN = new Matrice(new double[n, n]);

                for (int i = 0; i < n; i++)
                {
                    AN = _matriceCarree.CopierMatrice();
                    for (int j = 0; j < n; j++)
                    {
                        AN[j, i] = _matrice1N[j, 0];
                    }
                    X[i, 0] = AN.Determinant / _matriceCarree.Determinant;
                }
                return X;
            }

            else
            {
                Console.WriteLine("Déterminant de la matrice = 0, donc impossible d'utiliser la méthode de Cramer");
                return new Matrice(new double[0, 0]);
            }
        }

        //Méthode d'inversion matricielle
        public Matrice TrouverXParInversionMatricielle()
        {
            if (_matriceCarree.Determinant != 0)
            {
                int n = _matriceCarree.GetLength(0);
                Matrice X = new Matrice((new double[n, 1]));
                X = (_matriceCarree.MatriceInverse).FaireProduitMatriciel(_matrice1N);
                return X;
            }
            else
            {
                Console.WriteLine("Déterminant de la matrice = 0, donc impossible d'utiliser la méthode de d'inversion matricielle");
                return new Matrice(new double[0, 0]);
            }
        }

        //Méthode de Jacobi
        public Matrice TrouverXParJacobi(double epsilon)
        {
            int n = _matriceCarree.GetLength(0);
            Matrice d = new Matrice((new double[n, 1]));
            Matrice xDroite = new Matrice((new double[n, n + 1])); //
            Matrice xGauche = new Matrice((new double[n, 1]));
            Matrice xGaucheAvant = new Matrice((new double[n, 1]));
            bool continuer = true;

            //création de la matrice colonne des valeurs de la diagonale et instanciation de matrice x gauche
            for (int i = 0; i < n; i++)
            {
                d[i, 0] = _matriceCarree[i, i];
                xGauche[i, 0] = 0;
            }

            //création de la matrice des formules X
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        xDroite[i, j] =  - _matriceCarree[i, j]/d[i, 0];
                    }
                    else
                    {
                        xDroite[i, j] = 0;
                    }
                    
                }
                xDroite[i, n] = _matrice1N[i, 0]/d[i, 0];
            }


            //itération pour trouver X 
            while (continuer)
            {
                bool continuerTemp = false;
                for (int i = 0; i < n; i++)
                {
                    xGaucheAvant[i, 0] = xGauche[i, 0];
                    xGauche[i, 0] = 0;
                    

                    for (int j = 0; j < n; j++)
                    {
                        xGauche[i, 0] += xDroite[i, j] * xGaucheAvant[j, 0];
                    }
                    xGauche[i, 0] += xDroite[i, n];
                    Console.WriteLine(xGauche[i, 0]);
                    if (Math.Abs(xGauche[i, 0] - xGaucheAvant[i, 0]) >= epsilon || continuerTemp)
                    {
                        continuerTemp = true;
                    }
                    //else continuerTemp = false;
                }
                continuer = continuerTemp;

            }
            return xGauche;
        }

        //propriété strictement dominante diagonalement
        private bool DominanteDiag
        {
            get
            {
                double somme = 0; //somme des a(i,j) pour j!= i
                for (int i = 0; i < _matriceCarree.GetLength(0); i++)
                {
                    for (int j = 0; j < _matriceCarree.GetLength(0); j++)
                    {
                        if (i != j)
                        {
                            somme += Math.Abs(_matriceCarree[i, j]);
                        }
                    }
                }
                for (int i = 0; i < _matriceCarree.GetLength(0); i++)
                {
                    if (Math.Abs(_matriceCarree[i, i]) > somme) { return true; }
                }
                return false;
            }
        }

        //propriété irréductiblement dominante diagonalement


    }
}
