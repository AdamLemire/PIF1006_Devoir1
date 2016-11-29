//Devoir 1 PIF1006 - 27 novembre 2016
//Adam Lemire et Rémi Petiteau

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PIF1006Devoir1;

namespace PIF1006Devoir1_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox[,] matriceA, matriceB, matriceC;


        public MainWindow()
        {
            InitializeComponent();
            CacherCases();
            //compose_MatriceA();
        }

        /*private List<TextBox> compose_MatriceA()
        {
            List<TextBox> matriceA5x5 = new List<TextBox>((new TextBox[] { A1_1,A1_2,A1_3,A1_4,A1_5,A2_1,A2_2,A2_3,A2_4,A2_5,A3_1,A3_2,A3_3,A3_4,A3_5,A4_1,A4_2,A4_3,A4_4,A4_5,A5_1,A5_2,A5_3,A5_4,A5_5 }));
            return matriceA5x5;
        }
        */

        /// <summary>
        /// Création matrice A 5x5
        /// </summary>
        /// <returns></returns>
        private TextBox[,] composeMatrice_MatriceA()
        {
            TextBox[,] matrice5x5 = new TextBox[,]
            {
                {A1_1, A1_2, A1_3, A1_4, A1_5}, {A2_1, A2_2, A2_3, A2_4, A2_5}, {A3_1, A3_2, A3_3, A3_4, A3_5},
                {A4_1, A4_2, A4_3, A4_4, A4_5}, {A5_1, A5_2, A5_3, A5_4, A5_5}
            };
            return matrice5x5;
        }

        /// <summary>
        /// Création matrice B 5x5
        /// </summary>
        /// <returns></returns>
        private TextBox[,] composeMatrice_MatriceB()
        {
            TextBox[,] matrice5x5 = new TextBox[,]
            {
                {B1_1, B1_2, B1_3, B1_4, B1_5}, {B2_1, B2_2, B2_3, B2_4, B2_5}, {B3_1, B3_2, B3_3, B3_4, B3_5},
                {B4_1, B4_2, B4_3, B4_4, B4_5}, {B5_1, B5_2, B5_3, B5_4, B5_5}
            };
            return matrice5x5;
        }

        /// <summary>
        /// Création matrice C 5x5
        /// </summary>
        /// <returns></returns>
        private TextBox[,] composeMatrice_MatriceC()
        {
            TextBox[,] matrice5x5 = new TextBox[,]
            {
                {C1_1, C1_2, C1_3, C1_4, C1_5}, {C2_1, C2_2, C2_3, C2_4, C2_5}, {C3_1, C3_2, C3_3, C3_4, C3_5},
                {C4_1, C4_2, C4_3, C4_4, C4_5}, {C5_1, C5_2, C5_3, C5_4, C5_5}
            };
            return matrice5x5;
        }

        /// <summary>
        /// composer matrice A
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private TextBox[,] compose_MatriceAInput(int x, int y)
        {
            TextBox[,] matriceTmp = composeMatrice_MatriceA();
            TextBox[,] matriceA = new TextBox[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matriceA[i, j] = matriceTmp[i, j];
                }
            }
            this.matriceA = matriceA;
            return matriceA;
        }

        /// <summary>
        /// composer matrice B
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private TextBox[,] compose_MatriceBInput(int x, int y)
        {
            TextBox[,] matriceTmp = composeMatrice_MatriceB();
            TextBox[,] matriceB = new TextBox[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matriceB[i, j] = matriceTmp[i, j];
                }
            }
            this.matriceB = matriceB;
            return matriceB;
        }

        /// <summary>
        /// composer matrice C
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private TextBox[,] compose_MatriceCInput(int x, int y)
        {
            TextBox[,] matriceTmp = composeMatrice_MatriceC();
            TextBox[,] matriceC = new TextBox[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matriceC[i, j] = matriceTmp[i, j];
                }
            }
            this.matriceC = matriceC;
            return matriceC;
        }

        private void iniMatriceA_Click(object sender, RoutedEventArgs e)
        {
            string lignesT, colonnesT;
            lignesT = LignesA.Text;
            colonnesT = ColonnesA.Text;
            EffacerAAction();
            LignesA.Text = lignesT;
            ColonnesA.Text = colonnesT;
            if (LignesA.Text != "" && ColonnesA.Text != "")
            {
                int lignes, colonnes;
                lignes = Convert.ToInt32(LignesA.Text);
                colonnes = Convert.ToInt32(ColonnesA.Text);


                if (lignes > 0 || colonnes > 0)
                {
                    TextBox[,] matrice = compose_MatriceAInput(lignes, colonnes);
                    foreach (TextBox textBox in matrice)
                    {
                        textBox.Visibility = Visibility.Visible;
                    }
                    Nombres1.Visibility = Visibility.Visible;
                }
                else resultatsTxt.Text = "Nombre de ligne ou colonne trop petit";
            }
            else resultatsTxt.Text = "Erreur du nombre de lignes ou colonnes";
        }

        private void iniMatriceB_Click(object sender, RoutedEventArgs e)
        {
            string lignesT, colonnesT;
            lignesT = LignesB.Text;
            colonnesT = ColonnesB.Text;
            EffacerBAction();
            LignesB.Text = lignesT;
            ColonnesB.Text = colonnesT;
            if (LignesB.Text != "" && ColonnesB.Text != "")
            {
                int lignes, colonnes;
                lignes = Convert.ToInt32(LignesB.Text);
                colonnes = Convert.ToInt32(ColonnesB.Text);


                if (lignes > 0 || colonnes > 0)
                {
                    TextBox[,] matrice = compose_MatriceBInput(lignes, colonnes);
                    foreach (TextBox textBox in matrice)
                    {
                        textBox.Visibility = Visibility.Visible;
                    }
                    Nombres2.Visibility = Visibility.Visible;
                }
                else resultatsTxt.Text = "Nombre de ligne ou colonne trop petit";
            }
            else resultatsTxt.Text = "Erreur du nombre de lignes ou colonnes";
        }

        private void iniMatriceC_Click(object sender, RoutedEventArgs e)
        {
            string lignesT, colonnesT;
            lignesT = LignesC.Text;
            colonnesT = ColonnesC.Text;
            EffacerCAction();
            LignesC.Text = lignesT;
            ColonnesC.Text = colonnesT;
            if (LignesC.Text != "" && ColonnesC.Text != "")
            {
                int lignes, colonnes;
                lignes = Convert.ToInt32(LignesC.Text);
                colonnes = Convert.ToInt32(ColonnesC.Text);


                if (lignes > 0 || colonnes > 0)
                {
                    TextBox[,] matrice = compose_MatriceCInput(lignes, colonnes);
                    foreach (TextBox textBox in matrice)
                    {
                        textBox.Visibility = Visibility.Visible;
                    }
                    Nombres3.Visibility = Visibility.Visible;
                }
                else resultatsTxt.Text = "Nombre de ligne ou colonne trop petit";
            }
            else resultatsTxt.Text = "Erreur du nombre de lignes ou colonnes";
        }

        private void CacherCases()
        {
            TextBox[,] matriceA5x5 = composeMatrice_MatriceA();
            TextBox[,] matriceB5x5 = composeMatrice_MatriceB();
            TextBox[,] matriceC5x5 = composeMatrice_MatriceC();
            foreach (TextBox textbox in (matriceA5x5))
            {
                textbox.Text = "";
                textbox.Visibility = Visibility.Hidden;
            }
            foreach (TextBox textbox in (matriceB5x5))
            {
                textbox.Text = "";
                textbox.Visibility = Visibility.Hidden;
            }
            foreach (TextBox textbox in (matriceC5x5))
            {
                textbox.Text = "";
                textbox.Visibility = Visibility.Hidden;
            }
            Nombres1.Visibility = Visibility.Hidden;
            Nombres2.Visibility = Visibility.Hidden;
            Nombres3.Visibility = Visibility.Hidden;
        }

        private void EffacerAAction()
        {
            LignesA.Text = "";
            ColonnesA.Text = "";

            TextBox[,] matriceA5x5 = composeMatrice_MatriceA();
            foreach (TextBox textbox in matriceA5x5)
            {
                textbox.Text = "";
                textbox.Visibility = Visibility.Hidden;
            }
            Nombres1.Visibility = Visibility.Hidden;
        }

        private void EffacerA_Click(object sender, RoutedEventArgs e)
        {
            EffacerAAction();
        }

        private void EffacerBAction()
        {
            LignesB.Text = "";
            ColonnesB.Text = "";

            TextBox[,] matriceB5x5 = composeMatrice_MatriceB();
            foreach (TextBox textbox in matriceB5x5)
            {
                textbox.Visibility = Visibility.Hidden;
                textbox.Text = "";
            }
            Nombres2.Visibility = Visibility.Hidden;
        }
        private void EffacerB_Click(object sender, RoutedEventArgs e)
        {
            EffacerBAction();
        }

        private void EffacerCAction()
        {
            LignesC.Text = "";
            ColonnesC.Text = "";

            TextBox[,] matriceC5x5 = composeMatrice_MatriceC();
            foreach (TextBox textbox in matriceC5x5)
            {
                textbox.Visibility = Visibility.Hidden;
                textbox.Text = "";
            }
            Nombres3.Visibility = Visibility.Hidden;
        }

        private void EffacerC_Click(object sender, RoutedEventArgs e)
        {
            EffacerCAction();
        }

        /// <summary>
        /// Création de la matrice A à partir des inputs
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Matrice CreerMatriceA(int x, int y)
        {

            Matrice matriceAPleine = new Matrice(new double[x, y]);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (matriceA[i, j].GetLineText(0) != "")
                    {
                        matriceAPleine[i, j] = Convert.ToInt32(matriceA[i, j].GetLineText(0));
                        //resultatsTxt.Text = resultatsTxt.Text + " " + Convert.ToString(matriceAPleine[i, j]);
                    }
                    else
                    {
                        Exception e = new Exception("Au moins une case de la matrice A n'a pas été remplie");
                        throw e;
                    }
                }
            }
            return matriceAPleine;
        }

        /// <summary>
        /// Création de la matrice B à partir des inputs
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Matrice CreerMatriceB(int x, int y)
        {
            Matrice matriceBPleine = new Matrice(new double[x, y]);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (matriceB[i, j].GetLineText(0) != "")
                    {
                        matriceBPleine[i, j] = Convert.ToInt32(matriceB[i, j].GetLineText(0));
                        //resultatsTxt.Text = resultatsTxt.Text + " " + Convert.ToString(matriceBPleine[i, j]);
                    }
                    else
                    {
                        Exception e = new Exception("Au moins une case de la matrice B n'a pas été remplie");
                        throw e;
                    }
                }
            }
            return matriceBPleine;
        }


        /// <summary>
        /// Création de la matrice C à partir des inputs
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Matrice CreerMatriceC(int x, int y)
        {
            Matrice matriceCPleine = new Matrice(new double[x, y]);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (matriceC[i, j].GetLineText(0) != "")
                    {
                        matriceCPleine[i, j] = Convert.ToInt32(matriceC[i, j].GetLineText(0));
                    }
                    else
                    {
                        Exception e = new Exception("Au moins une case de la matrice C n'a pas été remplie");
                        throw e;
                    }
                }
            }
            return matriceCPleine;
        }

        private void BtnAddition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
                Matrice matriceB = CreerMatriceB(Convert.ToInt32(LignesB.Text), Convert.ToInt32(ColonnesB.Text));
                resultatsTxt.Text = (matriceA.Additionner(matriceB)).AfficheMatrice();
            }
            catch (Exception ex)
            {
                resultatsTxt.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnProduitScalaire_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Scalaire.Text != "")
                {
                    Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
                    resultatsTxt.Text = matriceA.FaireProduitScalaire(Convert.ToInt32(Scalaire.Text)).AfficheMatrice();
                }
                else
                {
                    resultatsTxt.Text = "";
                    MessageBox.Show("Veuillez entrer un scalaire");
                }
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    resultatsTxt.Text = "";
                    MessageBox.Show("Erreur de conversion, vérifier les dimensions");
                }
                else
                {
                    resultatsTxt.Text = "";
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void BtnProduitMatriciel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
                Matrice matriceB = CreerMatriceB(Convert.ToInt32(LignesB.Text), Convert.ToInt32(ColonnesB.Text));
                Matrice matriceC;
                int a = 0;
                if (LignesC.Text != "" && ColonnesC.Text != "")
                {
                    matriceC = CreerMatriceC(Convert.ToInt32(LignesC.Text), Convert.ToInt32(ColonnesC.Text));
                    resultatsTxt.Text = (matriceA.FaireProduitMatriciel(out a, matriceB, matriceC)).AfficheMatrice();
                }
                else resultatsTxt.Text = (matriceA.FaireProduitMatriciel(out a, matriceB)).AfficheMatrice();

                resultatsTxt.Text += "Nombre de produits effectues : " + a;
            }
            catch (Exception ex)
            {
                resultatsTxt.Text = "";
                MessageBox.Show(ex.Message);
            }
        }


        private void BtnTriangularite_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
                bool stricte = Stricte.IsChecked.Value;
                int choix;
                string reponse = "Non";
                if (radioButton1.IsChecked.Value) choix = 0;
                else if (radioButton2.IsChecked.Value) choix = 1;
                else choix = 2;
                bool m = matriceA.EstTriangulaire(choix, stricte);
                if (m == true) reponse = "Oui";
                resultatsTxt.Text = "Triangulaire tel que spécifié? : " + reponse;
            }
            catch (Exception ex)
            {
                resultatsTxt.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void Trace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
                double trace = matriceA.Trace;
                resultatsTxt.Text = "La trace de la matrice A est : " + trace;
            }
            catch (Exception ex)
            {
                resultatsTxt.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void Determinant_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
                double det = matriceA.Determinant;
                resultatsTxt.Text = "Le déterminant de la matrice A est : " + det;
            }
            catch (Exception ex)
            {
                resultatsTxt.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void Transposee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
                resultatsTxt.Text = "La transposée de la matrice A est : \r\n";
                resultatsTxt.Text += matriceA.Transposee.AfficheMatrice();
            }
            catch (Exception ex)
            {
                resultatsTxt.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void Comatrice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
                resultatsTxt.Text = "La comatrice de la matrice A est : \r\n";
                resultatsTxt.Text += matriceA.Comatrice.AfficheMatrice();
            }
            catch (Exception ex)
            {
                resultatsTxt.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void Inverse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
                resultatsTxt.Text = "La matrice inverse de la matrice A est : \r\n";
                resultatsTxt.Text += matriceA.MatriceInverse.AfficheMatrice();
            }
            catch (Exception ex)
            {
                resultatsTxt.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void Reguliere_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
                double det = matriceA.Determinant;
                string reg = "La matrice A n'est pas régulière";
                if (matriceA.EstReguliere) reg = "La matrice A est régulière";
                resultatsTxt.Text = "Le déterminant de la matrice A est : " + det + "\r\n";
                resultatsTxt.Text = reg;
            }
            catch (Exception ex)
            {
                resultatsTxt.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void Carree_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
                if (matriceA.EstCarree)  resultatsTxt.Text = "La matrice A est carrée";
            }
            catch (Exception ex)
            {
                resultatsTxt.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void Cramer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
                Matrice matriceB = CreerMatriceB(Convert.ToInt32(LignesB.Text), Convert.ToInt32(ColonnesB.Text));
                Systeme systemeA = new Systeme(matriceA, matriceB);
                Matrice systemeX = systemeA.TrouverXParCramer();
                AfficheSysteme(systemeX, "Méthode de Cramer : ");
            }
            catch (Exception ex)
            {
                resultatsTxt.Text = "";
                MessageBox.Show(ex.Message);
            }

        }

        private void AfficheSysteme(Matrice systemeX, string methode)
        {
            Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
            Matrice matriceB = CreerMatriceB(Convert.ToInt32(LignesB.Text), Convert.ToInt32(ColonnesB.Text));
            int m = Convert.ToInt32(LignesA.Text);
            int n = Convert.ToInt32(ColonnesA.Text);

            resultatsTxt.Text = methode +"\r\n" ;
            int l = systemeX.GetLength(0);

            resultatsTxt.Text += "Système recherché : \r\n";
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double valeur = matriceA[i, j];
                    double valB = matriceB[i, 0];
                    string signe = " + ";
                    if (valeur < 0) signe = " ";
                    if (j == 0) resultatsTxt.Text += valeur + "(x" + (j + 1) + ")";
                    else resultatsTxt.Text += signe + valeur + "(x" + (j + 1) + ")";
                    if (j == n - 1) resultatsTxt.Text += " = " + valB;
                }
                resultatsTxt.Text += "\r\n";
            }

            resultatsTxt.Text += "Valeurs de X trouvées";
            resultatsTxt.Text += "\r\n";
            for (int i = 0; i < l; i++)
            {
                double valeur = systemeX[i, 0];
                resultatsTxt.Text += "x" + (i + 1) + " = " + valeur + "\r\n";
            }
        }

        private void InversionMatricielle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
                Matrice matriceB = CreerMatriceB(Convert.ToInt32(LignesB.Text), Convert.ToInt32(ColonnesB.Text));
                Systeme systemeA = new Systeme(matriceA, matriceB);
                Matrice systemeX = systemeA.TrouverXParInversionMatricielle();
                AfficheSysteme(systemeX, "Méthode d'inversion matricielle : ");
            }
            catch (Exception)
            {
                resultatsTxt.Text = "";
                MessageBox.Show("Impossible d'utiliser cette méthode car la matrice A a un déterminant de 0");
            }
        }

        private void Jacobi_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
                Matrice matriceB = CreerMatriceB(Convert.ToInt32(LignesB.Text), Convert.ToInt32(ColonnesB.Text));
                Systeme systemeA = new Systeme(matriceA, matriceB);
                systemeA.DominanteDiag();
                Matrice systemeX = systemeA.TrouverXParJacobi(double.Parse(Epsilon.Text, System.Globalization.CultureInfo.InvariantCulture));
                AfficheSysteme(systemeX, "Méthode de Jacobi : ");

            }
            catch (Exception)
            {
                resultatsTxt.Text = "";
                MessageBox.Show("La matrice A n'est pas diagonalement dominante");

            }
        }

        private void Scalaire_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Scalaire_GotFocus;
        }


        private void EffacerTout_Click(object sender, RoutedEventArgs e)
        {
            EffacerAAction();
            EffacerBAction();
            EffacerCAction();
        }

        private void VerifierSiDimVideA()
        {
            if (LignesA.Text == "" || ColonnesA.Text == "")
            {
                Exception e = new Exception("Veuillez entrer les dimensions de la matrice");
                throw e;
            }
        }
    }
}
