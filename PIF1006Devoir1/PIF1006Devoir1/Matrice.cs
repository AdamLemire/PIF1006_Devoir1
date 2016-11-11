using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        //length de _matrice
        public int GetLength(int dimension)
        {
            return _matrice.GetLength(dimension);
        }

        //getter et setter de _matrice
        public double this[int i, int j]
        {
            get { return _matrice[i, j]; }
            set { _matrice[i, j] = value; }
        }

        //méthode de vérification même format de matrice
        public bool VerifierFormatMatrice(Matrice matrice)
        {
            if (_matrice.GetLength(0) == matrice.GetLength(0) && _matrice.GetLength(1) == matrice.GetLength(1))
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
                var addition = new Matrice(new double[_matrice.GetLength(0), _matrice.GetLength(1)]);
                for (var i = 0; i < matrice.GetLength(0); i++)
                    for (var j = 0; j < matrice.GetLength(1); j++)
                        addition[i, j] = matrice[i, j] + matrice[i, j];

                return addition;
            }
            else
            {
                Console.WriteLine("Format de matrice incorrect");
                return new Matrice(new double[0, 0]);
            }
        }

        //méthode du produit scalaire
        public Matrice FaireProduitScalaire(double scalaire)
        {
            int x = _matrice.GetLength(0);
            int y = _matrice.GetLength(1);
            Matrice produitScalaire = new Matrice(new double[x, y]);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    produitScalaire[i, j] = _matrice[i, j]*scalaire;
                }
            }

            return produitScalaire;
        }

        //méthode du produit matriciel
        public Matrice FaireProduitMatriciel(Matrice matrice)
        {
            //si le nombre de colonnes de A est égal au nombre de lignes de B
            if (VerifierColonneAcommeLigneB(matrice))
            {
                
                var n = _matrice.GetLength(0);
                var p = matrice.GetLength(1);

                var produitMatriciel = new Matrice(new double[n, p]);

                for (var i = 0; i < n; i++)
                    for (var j = 0; j < p; j++)
                    {
                        produitMatriciel[i, j] = 0;
                        for (var z = 0; z < n; z++)
                        { 
                            produitMatriciel[i, j] += _matrice[i, z]*matrice[z, j];
                           
                        }
                }
                return produitMatriciel;
            }
            else
            {
                Console.WriteLine("Format de matrice incorrect");
                return new Matrice(new double[0, 0]);
            }

        }

        //méthode du produit matriciel multiple
        public Matrice FaireProduitMatriciel(out int operations, params Matrice[] matrices)
        {
            operations = 0;
            Matrice temp = this;
            for (int i = 0; i < matrices.Length; i++)
            {
                operations += temp.GetLength(0) * temp.GetLength(1) * matrices[i].GetLength(1);
                temp = temp.FaireProduitMatriciel(matrices[i]);
                
            }
            return temp;
        }

        //méthode vérification si triangulaire
        /// <summary>
        /// Vérifie si la matrice est triangulaire
        /// </summary>
        /// <param name="triangulaire">0 = inférieure, 1= supérieure, 2 = peu importe</param>
        /// <param name="estStricte">true = stricte</param>
        /// <returns></returns>
        public bool EstTriangulaire(int triangulaire, bool estStricte)
        {
            bool inferieure = true;
            bool superieure = true;
            bool stricte = true;

            for (var i = 0; i < this.GetLength(0); i++)
            {
                for (var j = 0; j < this.GetLength(1); j++)
                {
                    if (i > j && (this[i, j] != 0))
                    {
                        superieure = false;
                    }
                    if (i < j && (this[i, j] != 0))
                    {
                        inferieure = false;
                    }
                    if (i == j && (this[i, j] != 0))
                    {
                        stricte = false;
                    }
                }

            }
            if (estStricte == true)
            {
                if (stricte == false) return false;
                else if (inferieure == true && (triangulaire == 0 || triangulaire == 2)) return true;
                else if (superieure == true && (triangulaire == 1 || triangulaire == 2)) return true;
                else return false;
            }
            else
            {
                if (inferieure == true && (triangulaire == 0 || triangulaire == 2)) return true;
                else if (superieure == true && (triangulaire == 1 || triangulaire == 2)) return true;
                else return false;
            }

        }

        //propriété trace
        public double Trace
        {
            get
            {
                if (EstCarree)
                {
                    double trace = 0;
                    for (int i = 0; i < _matrice.GetLength(0); i++)
                    {
                        trace += _matrice[i, i];
                    }
                    return trace;
                }
                else
                {
                     Console.WriteLine("Format de matrice incorrect");
                     return 0;
                }
                


            }

        }
 
        //vérifie si complement doit être positif
        public bool SigneComplement(int i, int j)
        {
            bool positif = (((i + j)%2) == 0 ? true : false);
            return positif;
        }

        //méthode d'affichage d'une matrice
        public void AfficheMatrice()
        {
                for (int i = 0; i < this.GetLength(0); i++)
                {
                    for (int j = 0; j < this.GetLength(1); j++)
                    {
                        if (j == 0) Console.Write(" |  ");
                        Console.Write(this[i, j] + "  ");
                        if (j == this.GetLength(1) - 1) Console.Write("| ");
                    }
                    Console.WriteLine();
                }
        }

        //méthode d'obtebtention de la mineure
        public Matrice Mineure(int i, int j)
        {
            Matrice mineure = new Matrice(new double[this.GetLength(0) - 1, this.GetLength(1) - 1]);
            Matrice mineureTmp = new Matrice(new double[this.GetLength(0), this.GetLength(1)]);
            for (int k = 0; k < this.GetLength(0); k++)
            {
                for (int l = 0; l < this.GetLength(1); l++)
                {
                    mineureTmp[k, l] = this[k, l];
                    if (l > j && k > i)
                    {
                        mineureTmp[k - 1, l - 1] = this[k, l];
                    }
                    else if (l > j)
                    {
                        mineureTmp[k, l - 1] = this[k, l];
                    }
                    else if (k > i)
                    {
                        mineureTmp[k - 1, l] = this[k, l];
                    }

                }
            }
            for (int k = 0; k < mineure.GetLength(0); k++)
            {
                for (int l = 0; l < mineure.GetLength(1); l++)
                {
                    mineure[k, l] = mineureTmp[k, l];
                }
            }
            return mineure;
        }

        //méthode de calcul du determinant
        private double CalculDeterminant(Matrice a, int n)
        {
            {  
                int p, h, k, i, j;
                double det=0;
                Matrice temp = new Matrice(new double[n, n]);

                if (n == 1)
                {
                    return a[0,0];
                }
                else if (n == 2)
                {
                    det = (a[0, 0] * a[1, 1] - a[0, 1] * a[1, 0]);
                    return det;
                }
                else
                {
                    for (p = 0; p < n; p++)
                    {
                        h = 0;
                        k = 0;
                        for (i = 1; i < n; i++)
                        {
                            for (j = 0; j < n; j++)
                            {
                                if (j == p)
                                {
                                    continue;
                                }
                                temp[h,k] = a[i,j];
                                k++;
                                if (k == n - 1)
                                {
                                    h++;
                                    k = 0;
                                }
                            }
                        }
                        det = det + a[0,p]*Math.Pow(-1, p)*CalculDeterminant(temp, n - 1);
                    }
                    return det;
                }
            }
        }

        //propriété determinant
        public double Determinant {
            get
            {
                if (EstCarree == true)
                {
                    return CalculDeterminant(this, this.GetLength(0));
                }
                    
                else  Console.WriteLine("La matrice n'est pas carrée");
                    return 0;
                }
        }

        //propriété transposée
        public Matrice Transposee
        {
            get
            {
                Matrice transposee = new Matrice(new double[this.GetLength(1), this.GetLength(0)]);
                for (int i = 0; i < this.GetLength(0); i++)
                {
                    for (int j = 0; j < this.GetLength(1); j++)
                    {
                        transposee[j, i] = this[i, j];
                    }
                }
                return transposee;
            }
        }

        //propriété Comatrice
        public Matrice Comatrice
        {
            get
            {
                if (EstCarree)
                {
                    Matrice comatrice = new Matrice(new double[this.GetLength(0), this.GetLength(1)]);
                    for (int i = 0; i < this.GetLength(0); i++)
                    {
                        for (int j = 0; j < this.GetLength(1); j++)
                        {
                            if ((i + j)%2 == 0)
                            {
                                comatrice[i, j] = (this.Mineure(i, j)).Determinant;
                            }
                            else
                            {
                                comatrice[i, j] = -(this.Mineure(i, j)).Determinant;
                            }
                        }
                    }
                    return comatrice;
                }
                else
                {
                    Console.WriteLine("Format de matrice incorrect");
                    return new Matrice(new double[ 0,0]);                 
                }
              
            }
        }

        //propriété MatriceInverse
        public Matrice MatriceInverse {
            get
            {
                if (EstCarree == true)
                {
                    if (this.EstReguliere == true)
                    {
                        Matrice inverse = new Matrice(new double[this.GetLength(0), this.GetLength(1)]);
                        inverse = ((this.Comatrice).Transposee).FaireProduitScalaire(1/this.Determinant);
                        return inverse;
                    }
                    else
                    {
                        Console.WriteLine("Le déterminant de la matrice est 0, donc impossible d'inverser la matrice");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("La matrice n'est pas carrée");
                    return null;
                }
            }
        }

        public bool EstCarree
        {
            get
            {
                if (_matrice.GetLength(0) == _matrice.GetLength(1))
                    return true;
                return false;
            }
        }

        public bool EstReguliere {
            get
            {
                if (this.Determinant != 0) return true;
                return false;
            }
        }


    }
}
