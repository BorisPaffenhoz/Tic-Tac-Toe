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

       public  int i = 0;

        private void Kaestchen_Click(object sender, RoutedEventArgs e)
        {
            Button geklickterButtton = (Button)sender;

            if (IstSpielfeldVoll())
            {
                SpielfeldLeeren();
                _istErsterSpielerAmZug = true;
            }

            
            if(geklickterButtton.Content!= null && geklickterButtton.Content.ToString() != "")
            {
                MessageBox.Show("Kästchen ist bereits belegt! Versuch ein anderes Kästchen anzuklicken","Hinweis", MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }

            if(_istErsterSpielerAmZug)
            { 
                geklickterButtton.Content = "x";
                _istErsterSpielerAmZug = false;
            }

            else
            {
                geklickterButtton.Content = "o";
                _istErsterSpielerAmZug = true;
            }

        }

        private bool IstSpielfeldVoll()
        {
            foreach(var item in Spielfeld.Children)
            {
                Button kaestchen = item as Button;

                if(kaestchen !=null && kaestchen.Content == string.Empty)
                {
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
        }
    }
}
