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

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       //Button Farbe wird durchs anklicken geaendert
        
        

        private void Button_0_0_Click(object sender, RoutedEventArgs e)
        {
            var bisherigerVordergrund = button_0_0.Foreground;
            button_0_0.Foreground = button_0_0.Background;
            button_0_0.Background = bisherigerVordergrund;
        }
    }
}
