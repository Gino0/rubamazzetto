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
using System.Windows.Threading;

namespace ProgettoTecnologie
{
    /// <summary>
    /// Logica di interazione per FinestraFinePartita.xaml
    /// </summary>
    public partial class FinestraFinePartita : Window
    {
        public FinestraFinePartita(string winner, string nickMio, string nickAvv, int nMazMio, int nMazAvv)
        {
            InitializeComponent();

            lblNomeMio.Content = nickMio;
            lblNomeAvversario.Content = nickAvv;

            if (winner != "")
            {
                lblPunteggioMio.Content = nMazMio;
                lblPunteggioAvversario.Content = nMazAvv;

                if (winner == nickMio)
                {
                    lblRisultato.Content = "HAI VINTO!";
                }
                else
                {
                    lblRisultato.Content = "HAI PERSO!";
                }
            }
            else
            {
                lblPunteggioMio.Content = "20";
                lblPunteggioAvversario.Content = "20";
                lblRisultato.Content = "PAREGGIO!";
            }

            Aggiornamento();
            
        }

        private void Aggiornamento()
        {
            lblPunteggioMio.Refresh();
            lblPunteggioAvversario.Refresh();
            lblRisultato.Refresh();
            lblNomeMio.Refresh();
            lblNomeAvversario.Refresh();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            this.Hide();
            home.Show();
        }
    }

   /* public static class ExtensionMethods
    {
        private static Action EmptyDelegate = delegate () { };

        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
   */
}

