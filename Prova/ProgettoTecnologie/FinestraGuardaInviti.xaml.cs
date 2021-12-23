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
    /// Logica di interazione per FinestraGuardaInviti.xaml
    /// </summary>
    public partial class FinestraGuardaInviti : Window
    {
        bool host = false;
        public FinestraGuardaInviti()
        {
            InitializeComponent();

            string tmp = (string)lblInvito.Content;

            if(tmp!= "Nessun invito ricevuto")
            {
                btnAccetta.IsEnabled = true;
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Hide();
            mw.Show();
        }
    }
}
