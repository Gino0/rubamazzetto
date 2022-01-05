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

namespace ProgettoTecnologie
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
           


        }

        private void btnInvito_Click(object sender, RoutedEventArgs e)
        {
            FinestraMandaInvito windows = new FinestraMandaInvito();
            windows.Show();
            this.Close();
        }

        private void btnGuarda_Click(object sender, RoutedEventArgs e)
        {
            FinestraGuardaInviti windows = new FinestraGuardaInviti();
            windows.Show();
            this.Close();
        }
    }
}
