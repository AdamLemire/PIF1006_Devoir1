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
            get { return _matrice[i, j];}
            set { _matrice[i, j] = value; }
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
                var addition = new Matrice(new double[_matrice.GetLength(0), _matrice.GetLength(1)]);
                for (var i = 0; i < matrice.GetLength(0); i++)
                    for (var j = 0; j < matrice.GetLength(1); j++)
                        addition[i, j] = matrice[i, j] + matrice[i, j];

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
                                produitMatriciel[i, j] += _matrice[i, z]*matrice[z, j];
                        }
                    return produitMatriciel;  
            }
            else
                {
                    Console.WriteLine("Produit de ces deux matrices non possible");
                    return null;
                }
                
        }

        //TODO a completer
        
        public Matrice FaireProduitMatriciel(out int operations, params Matrice[] matrices)
        {
            operations = 0;
            Matrice temp = this;
            for (int i = 0; i < matrices.Length; i++)
            {
                temp = temp.FaireProduitMatriciel(matrices[i]);
                operations++;
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
                        if(i < j && (this[i, j] != 0))
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

        //trace
        public double Trace
        {  
            get
            {
                double trace = 0;
                for (int i = 0; i<_matrice.GetLength(0); i++)
                {
                    trace += _matrice[i, i];
                }
                return trace;
            }
        }

        //méthode de calcul du déterminant pour matrice d'ordre 2
        public double CalculDeterminant()
        {
            try
            {
                return (this[0, 0]*this[1, 1]) - (this[0, 1]*this[1, 0]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Un problème est survenu lors du calcul du déterminant");
                throw;
            }
          
        }

        //méthode du complément algébrique
        public double Complement()
        {
            
            return 0;
        }

        //determinant
        public double Determinant {
            get
            {
                if (EstCarree == true)
                {
                    //si n=1
                    if (this.GetLength(0) == 1) return _matrice[0, 0];

                    //si n=2
                    else if (this.GetLength(0) == 2) return ((_matrice[0, 0] * _matrice[1, 1]) - (_matrice[0, 1] * _matrice[1, 0])) ;
                    

                }
                    

                else Console.WriteLine("La matrice n'est pas carrée");
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
                if (_matrice.GetLength(0) == _matrice.GetLength(1))
                    return true;
                else return false;
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
