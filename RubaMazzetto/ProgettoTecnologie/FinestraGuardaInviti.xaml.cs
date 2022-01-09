using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        Condivisa daPassare = new Condivisa();
        public FinestraGuardaInviti()
        {

            InitializeComponent();

            

            Condivisa c = new Condivisa();
            Thread t1 = new Thread(server);
            t1.Start(c);

            



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

        /*void client(object o)
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
        }*/


        void server(object o)
        {
            Condivisa c = (Condivisa)o;

            String hostname = "localhost";

            IPAddress addr;

            IPAddress.TryParse(hostname, out addr);
            TcpListener listener = new TcpListener(addr, 2003);
            listener.Start();
            TcpClient tcp = listener.AcceptTcpClient();
            while (true)
            {
                StreamReader sr = new StreamReader(tcp.GetStream());
                String s = sr.ReadLine();

                string[] divisa = s.Split(';');

                if (divisa[0] == "con")
                {
                    string nomeAvversario = divisa[1];
                    lblInvito.Content = nomeAvversario + " ti ha invitato a giocare";


                    string ipAvversario = tcp.Parse(((IPEndPoint)s.RemoteEndPoint).Address.ToString()); //comando da fare 
                    //((IPEndPoint)s.RemoteEndPoint).Addres



                    daPassare.setIp(ipAvversario);
                    daPassare.setNick(nomeAvversario);
                }
            }



            //StreamWriter sw = new StreamWriter(tcp.GetStream());
            //sw.WriteLine("con;" + c.setNick() + ";");

            
            //sw.Close();
            

        }

        private void btnAccetta_Click(object sender, RoutedEventArgs e)
        {

            bool controlloLancio = false;
            FinestraLanciodadi windows = new FinestraLanciodadi(daPassare.getIp(),daPassare.getNick(), controlloLancio); //da creare
            this.Hide();
            windows.Show();

        }


    }
}
