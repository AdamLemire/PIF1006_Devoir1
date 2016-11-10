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
                
                Matrice produitMatriciel = new Matrice(new double[n, p]);


                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < p; j++)
                    {
                        produitMatriciel[i, j] = 0;
                        for (int z = 0; z < n; z++)
                            produitMatriciel[i, j] += _matrice[i,z] * matrice[z,j];

                    }
                }
                return produitMatriciel;
            }
            else
            {
                Console.WriteLine("Produit de ces deux matrices non possible");
            }
            
        }

        //méthode vérification si triangulaire
        /*retourne vrai ou faux selon si la matrice est triangulaire
        ou non ; 
        comme arguments de la méthode, un premier paramètre doit dire si
        on souhaite vérifier si la méthode est triangulaire inférieure, supérieure ou peu
        importe, et un second paramètre doit indiquer soit on souhaite vérifier si elle
        est triangulaire stricte ou non.
         * */
        public bool EstTriangulaire(String triangulaireInfSup, String triangulaireStrict)
        {
            //triangulaire inferieur strict           
            //
            int n = _matrice();  
            if (triangulaireInfSup == inferieur && triangulaireStrict == strict)
            {
                for (int i; i < n; i++)
                {
                    for (int j; j < m; j++)
                    {
                        if()
                    }
                }     
            }

        }

        //trace
        public double Trace()
        {
            if (_matrice.EstCarre())
            {
                int n = _matrice.GetLength(0);
                double trace = 0;
                for(int i; i < n; i++)
                {
                    trace += _matrice[i,i];
                }
                return trace;            
            }
            else
            {
                Console.WriteLine("Matrice non carre");
            }
        }

        //determinant
        public double Determinant() {
            if (_matrice.EstCarre())
            {
                int n = _matrice.GetLength(0);
                double det;
                for(int i = 0; i < n - 1; i++)
                {
                    for(int j = i + 1; i < n; j++)
                    {
                        det = _matrice[j, i] / _matrice[i,i];
                        for(int k = 1; k < n; k++)
                        {
                            _matrice[j, k] -= det * _matrice[i, k];
                        }
                    }
                }

                det = 0;
                for(int i = 0; i < n; i++)
                {
                    det *= _matrice[i, i];
                }      
            }
        }

        public Matrice Transposee()
        {
        }

        public Matrice CoMatrice()
        {
        }

        public Matrice MatriceInverse() { }

        public bool EstCarree()
        {
                if (_matrice.GetLength(0) == _matrice.GetLength(1))
                    return true;

                else
                    return false;
       }

        public bool EstReguliere() {

        }


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
