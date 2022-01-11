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
            string x = txtInserisciUser.Text;

            if (tmp != "Nessun invito ricevuto" && x!="")
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
            Aggiorna();
        }



        private void Aggiorna()
        {
            lblInvito.Refresh();



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

        private static Socket ConnectSocket(string server, int port)
        {
            Socket s = null;
            IPHostEntry hostEntry = null;

            // Get host related information.
            hostEntry = Dns.GetHostEntry(server);

            // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
            // an exception that occurs when the host IP Address is not compatible with the address family
            // (typical in the IPv6 case).
            foreach (IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                Socket tempSocket =
                    new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                tempSocket.Connect(ipe);

                if (tempSocket.Connected)
                {
                    s = tempSocket;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return s;
        }

        void server(object o)
        {
            Condivisa c = (Condivisa)o;

            String hostname = "localhost";

            IPAddress addr;


            IPAddress.TryParse(hostname, out addr);
            TcpListener listener = new TcpListener(addr, 2003);
            Socket socket = listener.AcceptSocket();
            listener.Start();
            TcpClient tcp  = listener.AcceptTcpClient();


            while (true)
            {
                StreamReader sr = new StreamReader(tcp.GetStream());
                String s = sr.ReadLine();

                string[] divisa = s.Split(';');


                if (divisa[0] == "con")
                {
                    string nomeAvversario = divisa[1];
                    lblInvito.Content = nomeAvversario + " ti ha invitato a giocare";


                    //string ipAvversario = IPAddress.Parse(((IPEndPoint)socket.RemoteEndPoint).Address.ToString());
                    // IPAddress.Parse(((IPEndPoint)tcp.Client.RemoteEndPoint).Address.ToString()) ; ((IPEndPoint)s.RemoteEndPoint).Address
                    IPAddress ipAvv = ((IPEndPoint)socket.RemoteEndPoint).Address;

                    string ipAvversario = ipAvv.ToString();

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
            string nomeMio = txtInserisciUser.Text;
            bool controlloLancio = false;
            FinestraLanciodadi windows = new FinestraLanciodadi(daPassare.getIp(),daPassare.getNick(), controlloLancio,nomeMio,""); //da creare
            this.Hide();
            windows.Show();

        }


    }
}
