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
    /// Logica di interazione per FinestraLanciodadi.xaml
    /// </summary>
    public partial class FinestraLanciodadi : Window
    {
        bool controlloDadi;
        string ipA;
        string nickA;
        string azione;
        Condivisa c = new Condivisa();
        int tiroDado;
        bool partoIo;
        bool retry;
        public FinestraLanciodadi(string ipAvv, string userAvv, bool controllo)
        {
            InitializeComponent();
            controlloDadi = controllo;
            ipA = ipAvv;
            nickA = userAvv;
            c.getIp(ipAvv);
            c.getNick(userAvv);
        }

        private void btnLancia_Click(object sender, RoutedEventArgs e)
        {
            int da = 1;
            int a = 7;

            Random random = new Random();
            int numeroDado = random.Next(da, a);
            lblDado.Content = numeroDado;
            tiroDado = numeroDado;
            FinestraLanciodadi windows = new FinestraLanciodadi(ipA, nickA, controlloDadi); //da creare
            this.Hide();
            windows.Show();

            if (controlloDadi==true)
            {
                //thread con controllo
                Thread t1 = new Thread(server);
                t1.Start();

                
            }
            else
            {
                //thread con invio
                Thread t1 = new Thread(client);
                t1.Start();

            }


            

        }

        void server()
        {


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
                //dad;5;
                if (divisa[0] == "dad")
                {
                    int dadoAvversario = Int32.Parse(divisa[1]);
                    int dadoUtente = (int)lblDado.Content;
                    if (dadoAvversario == dadoUtente)
                    {
                        azione = "retry";
                        retry = true;
                        lblPareggio.Content = "Pareggio, ritira il dado";
                        
                    }
                    else if (dadoAvversario > dadoUtente)
                    {
                        azione = "client";
                        partoIo = false;
                        retry = false;
                        lblPareggio.Content = nickA +" ha fatto "+dadoAvversario;
                    }
                    else
                    {
                        azione = "host";
                        retry = false;
                        partoIo = true;
                        lblPareggio.Content = nickA + " ha fatto " + dadoAvversario;
                    }
                    FinestraLanciodadi windows = new FinestraLanciodadi(ipA, nickA, controlloDadi); 
                    this.Hide();
                    windows.Show();

                    StreamWriter sw = new StreamWriter(tcp.GetStream());
                    sw.WriteLine("dad;" +azione + ";");


                    sw.Close();


                }
            }



            


        }


        void client(object o)
        {
            Thread.Sleep(1000);

            Condivisa c = (Condivisa)o;
            String hostname = c.setIp();

            TcpClient tcp = new TcpClient(hostname, 2003);



            StreamWriter sw = new StreamWriter(tcp.GetStream());
            sw.WriteLine("dad;" + tiroDado + ";");


            sw.Close();
            while (true)
            {
                StreamReader sr = new StreamReader(tcp.GetStream());
                string s = sr.ReadLine();

                string[] divisa = s.Split(';');

                if (divisa[0] == "dad")
                {
                    azione = divisa[1];
                    
                    if(azione=="retry")
                    {
                        retry = true;
                        lblPareggio.Content = "Pareggio, ritira il dado";
                        FinestraLanciodadi windows = new FinestraLanciodadi(ipA, nickA, controlloDadi); //da creare
                        this.Hide();
                        windows.Show();
                    }
                    else if(azione=="client")
                    {
                        partoIo = true;
                        retry = false;
                        lblPareggio.Content = "Hai vinto";
                    }
                    else
                    {
                        partoIo = false;
                        retry = false;
                        lblPareggio.Content = nickA + " ha vinto";
                    }

                }
            }

        }
    }
}
