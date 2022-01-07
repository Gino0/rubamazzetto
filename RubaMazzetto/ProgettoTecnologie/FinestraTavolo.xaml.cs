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
    /// Logica di interazione per FinestraTavolo.xaml
    /// </summary>
    public partial class FinestraTavolo : Window
    {
        string ipAvversario;
        string nicknameAvversario;
        bool parto;
        string[] mazzo;
        char[] cartePresenti;
        int numeroPresenti = 0;
        string daPassare="";
        int nMaz=0;
        string maz = "";
        string[] inMano;
        string manoAvversaria;



        public FinestraTavolo(string ipAvv, string nickAvv, bool part)
        {
            InitializeComponent();
            ipAvversario = ipAvv;
            nicknameAvversario = nickAvv;
            parto = part;

            Condivisa c = new Condivisa();
            c.getIp(ipAvversario);
            c.getNick(nicknameAvversario);

            //Label1.Text = "'<img src='Images/globe1.JPG' />'"; 

            if(parto==false)
            {
                CaricaCarte();
                CarteSultavolo();
                

            }
        }




        //se parto=false, faccio i controlli

        private void CarteAvversario()
        {
            int da = 0;
            int a = 40;
            int cont = 0;
            while (cont < 3)
            {
                Random random = new Random();
                int posizioneVettore = random.Next(da, a);

                if (mazzo[posizioneVettore] != "zz")
                {
                    cont++;
                    if (cont == 1)
                    {
                        string carta = mazzo[posizioneVettore];            
                        mazzo[posizioneVettore] = "zz";
                        manoAvversaria = carta+";";
                    }
                    else if (cont == 2)
                    {
                        string carta = mazzo[posizioneVettore];
                        mazzo[posizioneVettore] = "zz";
                        manoAvversaria = manoAvversaria+ carta + ";";
                    }
                    else
                    {
                        string carta = mazzo[posizioneVettore];
                        mazzo[posizioneVettore] = "zz";
                        manoAvversaria = manoAvversaria + carta + ";";
                    }


                }
            }


        }

        private void CarteMie()
        {
            int da = 0;
            int a = 40;
            int cont = 0;
            while (cont < 3)
            {
                Random random = new Random();
                int posizioneVettore = random.Next(da, a);

                if (mazzo[posizioneVettore] != "zz")
                {
                    cont++;
                    if (cont == 1)
                    {
                        string carta = mazzo[posizioneVettore];
                        lblCarta1.Content = "'<img src='carte/" + carta + ".jpg' />'";
                        mazzo[posizioneVettore] = "zz";
                        inMano[0] = carta;
                    }
                    else if (cont == 2)
                    {
                        string carta = mazzo[posizioneVettore];
                        lblCarta2.Content = "'<img src='carte/" + carta + ".jpg' />'";
                        mazzo[posizioneVettore] = "zz";
                        inMano[1] = carta;
                    }
                    else
                    {
                        string carta = mazzo[posizioneVettore];
                        lblCarta3.Content = "'<img src='carte/" + carta + ".jpg' />'";
                        mazzo[posizioneVettore] = "zz";
                        inMano[2] = carta;
                    }


                }
            }


        }
        
        private void CaricaCarte()
        {
            StreamReader mazzoTesto = new StreamReader("\\carte.txt");
            string tmp = mazzoTesto.ToString();
            mazzo = tmp.Split(';');
            mazzoTesto.Close();

        }

        private void CarteSultavolo()
        {
            int da = 0;
            int a = 40;
            int cont = 0;
            

            //se la carta viene pescata avrà valore zz
            while(cont<4)
            {
                Random random = new Random();
                int posizioneVettore = random.Next(da, a);
                
               

                if (mazzo[posizioneVettore]!="zz")
                {
                    cont++;

                    if(cont==1)
                    {
                        string carta = mazzo[posizioneVettore];
                        lblTavolo1.Content = "'<img src='carte/"+ carta+ ".jpg' />'";

                        mazzo[posizioneVettore] = "zz";
                        char carattere = carta.ToCharArray()[0];
                        cartePresenti[numeroPresenti] = carattere;
                        numeroPresenti++;
                        daPassare = carta+ ";";

                    }
                    else if(cont==2)
                    {
                        string carta = mazzo[posizioneVettore];
                        char carattere = carta.ToCharArray()[0];
                        if (carattere != cartePresenti[0])
                        {
                            lblTavolo2.Content = "'<img src='carte/" + mazzo[posizioneVettore] + ".jpg' />'";
                            mazzo[posizioneVettore] = "zz";
                            cartePresenti[numeroPresenti] = carattere;
                            numeroPresenti++;
                            daPassare = daPassare + carta + ";";
                        }
                        else
                        {
                            cont--;
                        }
                    }
                    else if (cont == 3)
                    {
                        string carta = mazzo[posizioneVettore];
                        char carattere = carta.ToCharArray()[0];
                        if (carattere != cartePresenti[0]&& carattere != cartePresenti[1])
                        {
                            lblTavolo3.Content = "'<img src='carte/" + mazzo[posizioneVettore] + ".jpg' />'";
                            mazzo[posizioneVettore] = "zz";
                            cartePresenti[numeroPresenti] = carattere;
                            numeroPresenti++;
                            daPassare = daPassare + carta + ";";
                        }
                        else
                        {
                            cont--;
                        }
                    }
                    else if (cont == 4)
                    {
                        string carta = mazzo[posizioneVettore];
                        char carattere = carta.ToCharArray()[0];
                        if (carattere != cartePresenti[0] && carattere != cartePresenti[1] && carattere != cartePresenti[2])
                        {
                            lblTavolo4.Content = "'<img src='carte/" + mazzo[posizioneVettore] + ".jpg' />'";
                            mazzo[posizioneVettore] = "zz";
                            cartePresenti[numeroPresenti] = carattere;
                            numeroPresenti++;
                            daPassare = daPassare + carta + ";";
                        }
                        else
                        {
                            cont--;
                        }
                    }


                }
            }


        }

        private void Giocata()
        {

        }

        void client(object o)
        {
            Thread.Sleep(1000);

            Condivisa c = (Condivisa)o;
            String hostname = c.setIp();

            TcpClient tcp = new TcpClient(hostname, 2003);



            StreamWriter st = new StreamWriter(tcp.GetStream());
            st.WriteLine("tav;" + daPassare + maz+";"+nMaz+";");
            st.Close();

            StreamWriter sc = new StreamWriter(tcp.GetStream());
            sc.WriteLine("crd;" + manoAvversaria);
            sc.Close();


            while (true)
            {
                StreamReader sr = new StreamReader(tcp.GetStream());
                string s = sr.ReadLine();

                string[] divisa = s.Split(';');

                if (divisa[0] == "con")
                {
                    string nomeAvversario = divisa[1];
                    bool controlloLancio = false;
                    FinestraLanciodadi windows = new FinestraLanciodadi(nomeAvversario, hostname, controlloLancio); //da creare
                    this.Hide();
                    windows.Show();

                }
            }

        }
    } 
}





