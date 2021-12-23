﻿using System;
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
        }

        private void btnIndietro_Click(object sender, RoutedEventArgs e)
        {
            FinestraMandaInvito windows = new FinestraMandaInvito();
            this.Hide();
            windows.Show();
        }

        void server(Condivisa o)
        {

            String hostname = o.setIp();

            IPAddress addr;
            IPAddress.TryParse(hostname, out addr);
            TcpListener listener = new TcpListener(addr, 666);
            listener.Start();
            TcpClient c = listener.AcceptTcpClient();

            StreamWriter sw = new StreamWriter(c.GetStream());
            sw.WriteLine("con;"+o.setNick()+";");

            Thread.Sleep(1000);
            sw.Close();
            c.Close();
        }
    }
}