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

            if(geklickterButtton.Content!= null && geklickterButtton.Content.ToString() != "")
            {
                MessageBox.Show("Kästchen ist bereits belegt! Versuch ein anderes Kästchen anzuklicken");
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
    }
}
