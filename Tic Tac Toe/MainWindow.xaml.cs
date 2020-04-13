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

            lblHinweis.Content = "Spieler 1";
        }

        //Button Farbe wird durchs anklicken geaendert

       public  int i = 0;

        private void Button_0_0_Click(object sender, RoutedEventArgs e)
        {
            Button geklickterButtton = (Button)sender;

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
    }
}
