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
using System.Windows.Shapes;

namespace ProgettoTecnologie
{
    /// <summary>
    /// Logica di interazione per FinestraCaricamento.xaml
    /// </summary>
    public partial class FinestraCaricamento : Window
    {
        public FinestraCaricamento(string ip, string user)
        {
            string ipAddress = ip;
            string username = user;
            InitializeComponent();
        }

        private void btnIndietro_Click(object sender, RoutedEventArgs e)
        {
            FinestraMandaInvito windows = new FinestraMandaInvito();
            this.Hide();
            windows.Show();
        }
    }
}
