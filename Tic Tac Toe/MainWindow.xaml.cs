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
using System.IO;
using System.Data;
using System.Windows.Media.TextFormatting;
using System.Threading;
using System.Timers;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _istErsterSpielerAmZug = true;

        public MainWindow()
        {
            InitializeComponent();


        }

        //Button Farbe wird durchs anklicken geaendert

        public int i = 0;
        private const bool V = true;
        
        private void Kaestchen_Click(object sender, RoutedEventArgs e)
        {
            Button geklickterButtton = (Button)sender;

            if (IstSpielfeldVoll())
            {
                SpielfeldLeeren();
                _istErsterSpielerAmZug = true;
            }

            if (geklickterButtton.Content != null && geklickterButtton.Content.ToString() != "")
            {
                //Letzte verännderung !!!!!!!!!!
                
                Label1.Content = string.Empty;
                string A = ("Kästchen ist belegt!");
                Label1.Visibility = Visibility.Visible;
                Label1.Content = A;
                               
                return;
            }

            if (_istErsterSpielerAmZug)
            {
                geklickterButtton.Content = "x";
                _istErsterSpielerAmZug = false;
            }

            else
            {
                geklickterButtton.Content = "o";
                var vordergrund = geklickterButtton.Foreground;
                geklickterButtton.Foreground = geklickterButtton.Background;
                geklickterButtton.Background = vordergrund;
                _istErsterSpielerAmZug = true;
            }

            if (IstSpielGewonnen())
            {

                if (_istErsterSpielerAmZug)
                {


                    MessageBox.Show("Spieler 1 (o) hat gewonnen!");
                }

                else
                {
                    MessageBox.Show("Spieler 2 (x) hat gewonnen");
                }

                StarteSpielNeu();
            }



        }

      

        private bool StarteSpielNeu()
        {
            if (IstSpielGewonnen())
            {
                SpielfeldLeeren();
                return true;
                
            }

            return false;
        }


        private bool IstSpielGewonnen()
        {
            //Gewinn Reihen Definition Horizontal
            if (IstGleicherSpielstein(button_0_0, button_0_1, button_0_2))
            {
                HebeKaestchenHervor(button_0_0, button_0_1, button_0_2);
                return true;
            }

            else if (IstGleicherSpielstein(button_1_0, button_1_1, button_1_2))
            {
                HebeKaestchenHervor(button_1_0, button_1_1, button_1_2);
                return true;
            }

            else if (IstGleicherSpielstein(button_2_0, button_2_1, button_2_2))
            {
                HebeKaestchenHervor(button_2_0, button_2_1, button_2_2);
                return true;
            }


            //Gewinn Reichen Definition Vertikal
            else if (IstGleicherSpielstein(button_0_0, button_1_0, button_2_0))
            {
                HebeKaestchenHervor(button_0_0, button_1_0, button_2_0);
                return true;
            }

            else  if (IstGleicherSpielstein(button_0_1, button_1_1, button_2_1))
            {
                HebeKaestchenHervor(button_0_1, button_1_1, button_2_1);
                return true;
            }

            else if (IstGleicherSpielstein(button_0_2, button_1_2, button_2_2))
            {
                HebeKaestchenHervor(button_0_2, button_1_2, button_2_2);
                return true;
            }


            //Gewinn Reihe Definition Diagonal
            else if (IstGleicherSpielstein(button_0_0, button_1_1, button_2_2))
            {
                HebeKaestchenHervor(button_0_0, button_1_1, button_2_2);
                return true;
            }

            else if (IstGleicherSpielstein(button_0_2, button_1_1, button_2_0))
            {
                HebeKaestchenHervor(button_0_2, button_1_1, button_2_0);
                return true;
            }

            return false;

            
            
        }

        private bool IstGleicherSpielstein(Button erstesKaestchen,Button zweitesKaestchen, Button drittesKaestchen)
        {
            if (erstesKaestchen.Content.ToString() != ""
                && erstesKaestchen.Content.ToString() == zweitesKaestchen.Content.ToString()
                && drittesKaestchen.Content.ToString() == zweitesKaestchen.Content.ToString())
            {
                return true;
            }

            return false;
        }

        private void HebeKaestchenHervor(Button erstesKaestchen,Button zweitesKaestchen,Button drittesKaestchen)
        {
            erstesKaestchen.Background = (Brush)new BrushConverter().ConvertFrom("#FFBDF000");
            zweitesKaestchen.Background = (Brush)new BrushConverter().ConvertFrom("#FFBDF000");
            drittesKaestchen.Background = (Brush)new BrushConverter().ConvertFrom("#FFBDF000");
        }

        private bool IstSpielfeldVoll()
        {
            foreach(var item in Spielfeld.Children)
            {
                Button kaestchen = item as Button;

                if (kaestchen == null || kaestchen.Content.ToString() == "")
                {
                    //Schaltet den Label auf verbergen
                    Label1.Visibility = Visibility.Hidden;
                    return false;
                }
            }

            return true;
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SpielfeldLeeren();
        }

        private void SpielfeldLeeren()
        {
            button_0_0.Content = string.Empty;
            button_0_1.Content = string.Empty;
            button_0_2.Content = string.Empty;

            button_1_0.Content = string.Empty;
            button_1_1.Content = string.Empty;
            button_1_2.Content = string.Empty;

            button_2_0.Content = string.Empty;
            button_2_1.Content = string.Empty;
            button_2_2.Content = string.Empty;


            button_0_0.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");
            button_0_1.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");
            button_0_2.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");

            button_1_0.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");
            button_1_1.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");
            button_1_2.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");

            button_2_0.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");
            button_2_1.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");
            button_2_2.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");



            button_0_0.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            button_0_1.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            button_0_2.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
                                                                           
            button_1_0.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            button_1_1.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            button_1_2.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
                                                                           
            button_2_0.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            button_2_1.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            button_2_2.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");

            Label1.Content = string.Empty;
            


        }




    }
}
