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

namespace PIF1006Devoir1_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            compose_MatriceA();
        }

        private List<TextBox> compose_MatriceA()
        {
            List<TextBox> matriceA5x5 = new List<TextBox>((new TextBox[] { A1_1,A1_2,A1_3,A1_4,A1_5,A2_1,A2_2,A2_3,A2_4,A2_5,A3_1,A3_2,A3_3,A3_4,A3_5,A4_1,A4_2,A4_3,A4_4,A4_5,A5_1,A5_2,A5_3,A5_4,A5_5 }));
            return matriceA5x5;
        }

        private TextBox[,] composeMatrice_MatriceA()
        {
            TextBox[,] matrice5x5 = new TextBox[,] { { A1_1, A1_2, A1_3, A1_4, A1_5 }, { A2_1, A2_2, A2_3, A2_4, A2_5 }, { A3_1, A3_2, A3_3, A3_4, A3_5 }, { A4_1, A4_2, A4_3, A4_4, A4_5 }, { A5_1, A5_2, A5_3, A5_4, A5_5 } } ;
            return matrice5x5;
        }


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
                    
            return matriceA;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
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


    }
}
