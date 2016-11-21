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
            TextBox[,] matrice5x5 = new TextBox[,] { { A1_1, A1_2, A1_3, A1_4, A1_5 }, { A2_1, A2_2, A2_3, A2_4, A2_5 }, { A3_1, A3_2, A3_3, A3_4, A3_5 }, { A4_1, A4_2, A4_3, A4_4, A4_5 }, { A5_1, A5_2, A5_3, A5_4, A5_5 } } ;
            return matrice5x5;
        }

        /// <summary>
        /// Création matrice B 5x5
        /// </summary>
        /// <returns></returns>
        private TextBox[,] composeMatrice_MatriceB()
        {
            TextBox[,] matrice5x5 = new TextBox[,] { { B1_1, B1_2, B1_3, B1_4, B1_5 }, { B2_1, B2_2, B2_3, B2_4, B2_5 }, { B3_1, B3_2, B3_3, B3_4, B3_5 }, { B4_1, B4_2, B4_3, B4_4, B4_5 }, { B5_1, B5_2, B5_3, B5_4, B5_5 } };
            return matrice5x5;
        }

        /// <summary>
        /// Création matrice C 5x5
        /// </summary>
        /// <returns></returns>
        private TextBox[,] composeMatrice_MatriceC()
        {
            TextBox[,] matrice5x5 = new TextBox[,] { { C1_1, C1_2, C1_3, C1_4, C1_5 }, { C2_1, C2_2, C2_3, C2_4, C2_5 }, { C3_1, C3_2, C3_3, C3_4, C3_5 }, { C4_1, C4_2, C4_3, C4_4, C4_5 }, { C5_1, C5_2, C5_3, C5_4, C5_5 } };
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
            TextBox[,] matriceA = new TextBox[x,y];
            for (int i = 0; i< x; i++)
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

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
        private void iniMatriceA_Click(object sender, RoutedEventArgs e)
        {
            if (LignesA.Text != "" && ColonnesA.Text != "")
            {
                int lignes, colonnes;
                lignes = Convert.ToInt32(LignesA.Text);
                colonnes = Convert.ToInt32(ColonnesA.Text);
                

                if (lignes > 0 || colonnes > 0)
                {
                    TextBox[,] matrice = compose_MatriceAInput(lignes, colonnes);
                    foreach(TextBox textBox in matrice)
                    {
                        textBox.Visibility = Visibility.Visible;
                    }
                }
                else resultatsTxt.Text = "Nombre de ligne ou colonne trop petit";
            }
            else resultatsTxt.Text = "Erreur du nombre de lignes ou colonnes";
        }

        private void iniMatriceB_Click(object sender, RoutedEventArgs e)
        {
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
                }
                else resultatsTxt.Text = "Nombre de ligne ou colonne trop petit";
            }
            else resultatsTxt.Text = "Erreur du nombre de lignes ou colonnes";
        }

        private void iniMatriceC_Click(object sender, RoutedEventArgs e)
        {
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
                }
                else resultatsTxt.Text = "Nombre de ligne ou colonne trop petit";
            }
            else resultatsTxt.Text = "Erreur du nombre de lignes ou colonnes";
        }

        private void EffacerA_Click(object sender, RoutedEventArgs e)
        {
            LignesA.Text = "";
            ColonnesA.Text = "";

            TextBox[,] matriceA5x5 = composeMatrice_MatriceA();
            foreach (TextBox textbox in matriceA5x5)
            {
                textbox.Visibility = Visibility.Hidden;
            }
        }

        private void EffacerB_Click(object sender, RoutedEventArgs e)
        {
            LignesA.Text = "";
            ColonnesA.Text = "";

            TextBox[,] matriceB5x5 = composeMatrice_MatriceB();
            foreach (TextBox textbox in matriceB5x5)
            {
                textbox.Visibility = Visibility.Hidden;
            }
        }

        private void EffacerC_Click(object sender, RoutedEventArgs e)
        {
            LignesA.Text = "";
            ColonnesA.Text = "";

            TextBox[,] matriceC5x5 = composeMatrice_MatriceC();
            foreach (TextBox textbox in matriceC5x5)
            {
                textbox.Visibility = Visibility.Hidden;
            }
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
                    matriceAPleine[i, j] = Convert.ToInt32(matriceA[i, j].GetLineText(0));
                    resultatsTxt.Text = resultatsTxt.Text + " "+ Convert.ToString(matriceAPleine[i,j]);
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
                    matriceBPleine[i, j] = Convert.ToInt32(matriceB[i, j].GetLineText(0));
                    resultatsTxt.Text = resultatsTxt.Text + " " + Convert.ToString(matriceBPleine[i, j]);
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
                    matriceCPleine[i, j] = Convert.ToInt32(matriceC[i, j].GetLineText(0));
                    //resultatsTxt.Text = resultatsTxt.Text + " " + Convert.ToString(matriceCPleine[i, j]);
                }
            }
            return matriceCPleine;
        }

        private void BtnAddition_Click(object sender, RoutedEventArgs e)
        {          
            Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
            Matrice matriceB = CreerMatriceB(Convert.ToInt32(LignesB.Text), Convert.ToInt32(ColonnesB.Text));
            resultatsTxt.Text = (matriceA.Additionner(matriceB)).AfficheMatrice();
        }

        private void BtnProduitScalaire_Click(object sender, RoutedEventArgs e)
        {
            Matrice matriceA = CreerMatriceA(Convert.ToInt32(LignesA.Text), Convert.ToInt32(ColonnesA.Text));
            resultatsTxt.Text = matriceA.FaireProduitScalaire(Convert.ToInt32(Scalaire.Text)).AfficheMatrice();      
        }

        private void BtnProduitMatriciel_Click(object sender, RoutedEventArgs e)
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

        private void Scalaire_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Scalaire_GotFocus;
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            CreerMatriceB(Convert.ToInt32(LignesB.Text), Convert.ToInt32(ColonnesB.Text));
        }
    }
}
