using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
        //bool host = false;
        public FinestraGuardaInviti()
        {

            InitializeComponent();

            Invito i = new Invito();
            Thread t1 = new Thread(client);
            t1.Start(i);

            



            string tmp = (string)lblInvito.Content;

            if (tmp != "Nessun invito ricevuto")
            {
                btnAccetta.IsEnabled = true;
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Hide();
            window.Show();
        }

        private void btnRicarica_Click(object sender, RoutedEventArgs e)
        {
            FinestraGuardaInviti window = new FinestraGuardaInviti();
            this.Hide();
            window.Show();
        }

        void client(object o)
        {
            Invito i = (Invito)o;
            Thread.Sleep(1000);
            TcpClient tcp = new TcpClient("localhost", 2003);

            StreamReader sr = new StreamReader(tcp.GetStream());
            string s = sr.ReadLine();
           

            string[] divisa = s.Split(';');
            if (divisa[0]=="con")
            {      
                //metto il comando per trovare l'ip e lo implemento nella classe invito
                i.getNick(divisa[1]);
                lblInvito.Content = i.setNick()+" ti ha invitato a giocare";

            }
        }

        private void btnAccetta_Click(object sender, RoutedEventArgs e)
        {

            Thread t = new Thread(server);
            t.Start();
        }


    }
}
