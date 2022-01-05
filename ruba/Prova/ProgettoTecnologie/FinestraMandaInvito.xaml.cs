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
    /// Logica di interazione per FinestraMandaInvito.xaml
    /// </summary>
    public partial class FinestraMandaInvito : Window
    {
        
        public FinestraMandaInvito()
        {
            InitializeComponent();
         
            
            

               
                    
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtIP.Text!=""&&txtUser.Text!="")
            {
                btnInvia.IsEnabled = true;

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow windows = new MainWindow();
            this.Hide();
            windows.Show();
        }

        private void btnInvia_Click(object sender, RoutedEventArgs e)
        {
            string ip = txtIP.Text;
            string user = txtUser.Text;
            FinestraCaricamento windows = new FinestraCaricamento(ip,user);
            this.Hide();
            windows.Show();
        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtIP.Text != "" && txtUser.Text != "")
            {
                btnInvia.IsEnabled = true;

            }
        }
    }
}
