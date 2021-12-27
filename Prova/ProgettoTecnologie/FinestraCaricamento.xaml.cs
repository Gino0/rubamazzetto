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
    /// Logica di interazione per FinestraCaricamento.xaml
    /// </summary>
    public partial class FinestraCaricamento : Window
    {
        public FinestraCaricamento(string ip, string user)
        {     
            InitializeComponent();
            Condivisa c = new Condivisa();
            c.getIp(ip);
            c.getNick(user);
            Thread t = new Thread(server);
            t.Start(c);
            Thread t1 = new Thread(client);
            t1.Start(c);
        }

        private void btnIndietro_Click(object sender, RoutedEventArgs e)
        {
            FinestraMandaInvito windows = new FinestraMandaInvito();
            this.Hide();
            windows.Show();
        }

        void server(object o)
        {
            Condivisa c = (Condivisa)o;

            String hostname = c.setIp();

            IPAddress addr;
            IPAddress.TryParse(hostname, out addr);
            TcpListener listener = new TcpListener(addr, 2003);
            listener.Start();
            TcpClient tcp = listener.AcceptTcpClient();

            StreamWriter sw = new StreamWriter(tcp.GetStream());
            sw.WriteLine("con;"+c.setNick()+";");

            Thread.Sleep(1000);
            sw.Close();
            tcp.Close();

        }

        void client(object o)
        {
            Thread.Sleep(1000);
            TcpClient c = new TcpClient("localhost", 2003);

            StreamReader sr = new StreamReader(c.GetStream());
            string s= sr.ReadLine();
            

            string[] divisa = s.Split(';');
            if(divisa[0]=="con")
            {
                string nomeAvversario = divisa[1];

                FinestraLancioDadi windows = new FinestraLancioDadi(nomeAvversario); //da creare
                this.Hide();
                windows.Show();

            }

        }
    }
}
