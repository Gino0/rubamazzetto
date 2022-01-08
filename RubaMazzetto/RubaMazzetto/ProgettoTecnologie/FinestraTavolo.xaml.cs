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
        int nMazAvversario = 0;
        string maz = "";
        string mazAvversario = "";
        string[] inMano;
        string manoAvversaria;




        public FinestraTavolo(string ipAvv, string nickAvv, bool part)
        {

            //string url = Directory.GetCurrentDirectory() + "carte/RETRO.png";
            //lblRetro.Background = new ImageBrush(new BitmapImage(new Uri(url)));
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

        
        //quando una carta è presente nella casella, scrivo p, altrimentio è v

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

                        string url = Directory.GetCurrentDirectory() + "carte/"+carta+".jpg";
                        lblCarta1.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtCarta1.Text = "p";
                        mazzo[posizioneVettore] = "zz";
                        inMano[0] = carta;
                    }
                    else if (cont == 2)
                    {
                        string carta = mazzo[posizioneVettore];
                        string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                        lblCarta2.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtCarta2.Text = "p";
                        mazzo[posizioneVettore] = "zz";
                        inMano[1] = carta;
                    }
                    else
                    {
                        string carta = mazzo[posizioneVettore];
                        string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                        lblCarta3.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtCarta3.Text = "p";
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
                        string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                        lblTavolo1.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtTavolo1.Text = carta;

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
                            string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                            lblTavolo2.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                            txtTavolo2.Text = carta;

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
                            string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                            lblTavolo3.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                            txtTavolo3.Text = carta;

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
                            string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                            lblTavolo4.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                            txtTavolo4.Text = carta;
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

        private void AggiornoTavoloAvversario(string carteTav,string sopraMazzo, int quanteCarteAvversario, bool mazzoRubato)
        {
            string[] carteTavolo =carteTav.Split(';');
            nMazAvversario = quanteCarteAvversario;

            mazAvversario = sopraMazzo;

            if(mazzoRubato==true)
            {
                nMaz = 0;
                maz = "";
                lblCartaMazzo1.Opacity = 0;
                txtCartaMazzo1.Text = "v";

            }
                

            if(mazAvversario=="")
            {
                lblCartaMazzo2.Opacity = 0;
                txtCartaMazzo2.Text = "v";
            }
            else
            {
                string url = Directory.GetCurrentDirectory() + "carte/" + mazAvversario + ".jpg";
                lblCartaMazzo2.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                txtCartaMazzo2.Text = mazAvversario;
                lblCartaMazzo2.Opacity = 100;
            }


            int tmp = carteTavolo.Length;
            int c = 0;

           while(c<10)
           { 
                if (c == 0)
                {
                    if (c < tmp - 1)
                    {
                        string carta = carteTavolo[c];
                        string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                        lblTavolo1.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtTavolo1.Text = carta;
                        lblTavolo1.Opacity = 100;
                    }
                    else
                    {
                        lblTavolo1.Opacity = 0;
                        txtTavolo1.Text = "v";
                    }
                }
                else if (c == 1)
                {
                    if(c < tmp - 1)
                    {
                        string carta = carteTavolo[c];
                        string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                        lblTavolo2.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtTavolo2.Text = carta;
                        lblTavolo2.Opacity = 100;
                    }
                    else
                    {
                        lblTavolo2.Opacity = 0;
                        txtTavolo2.Text = "v";
                    }

                }
                else if (c == 2)
                {
                    if (c < tmp - 1)
                    {
                        string carta = carteTavolo[c];
                        string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                        lblTavolo3.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtTavolo3.Text = carta;
                        lblTavolo3.Opacity = 100;
                    }
                    else
                    {
                        lblTavolo3.Opacity = 0;
                        txtTavolo3.Text = "v";
                    }

                }
                else if (c == 3)
                {
                    if (c < tmp - 1)
                    {
                        string carta = carteTavolo[c];
                        string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                        lblTavolo4.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtTavolo4.Text = carta;
                        lblTavolo4.Opacity = 100;
                    }
                    else
                    {
                        lblTavolo4.Opacity = 0;
                        txtTavolo4.Text = "v";
                    }

                }
                else if (c == 4)
                {
                    if (c < tmp - 1)
                    {
                        string carta = carteTavolo[c];
                        string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                        lblTavolo5.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtTavolo5.Text = carta;
                        lblTavolo5.Opacity = 100;
                    }
                    else
                    {
                        lblTavolo5.Opacity = 0;
                        txtTavolo5.Text = "v";
                    }

                }
                else if (c == 5)
                {
                    if (c < tmp - 1)
                    {
                        string carta = carteTavolo[c];
                        string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                        lblTavolo6.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtTavolo6.Text = carta;
                        lblTavolo6.Opacity = 100;
                    }
                    else
                    {
                        lblTavolo6.Opacity = 0;
                        txtTavolo6.Text = "v";
                    }

                }
                else if (c == 6)
                {
                    if (c < tmp - 1)
                    {
                        string carta = carteTavolo[c];
                        string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                        lblTavolo7.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtTavolo7.Text = carta;
                        lblTavolo7.Opacity = 100;
                    }
                    else
                    {
                        lblTavolo7.Opacity = 0;
                        txtTavolo7.Text = "v";
                    }

                }
                else if (c == 7)
                {
                    if (c < tmp - 1)
                    {
                        string carta = carteTavolo[c];
                        string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                        lblTavolo8.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtTavolo8.Text = carta;
                        lblTavolo8.Opacity = 100;
                    }
                    else
                    {
                        lblTavolo8.Opacity = 0;
                        txtTavolo8.Text = "v";
                    }

                }
                else if (c == 8)
                {
                    if (c < tmp - 1)
                    {
                        string carta = carteTavolo[c];
                        string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                        lblTavolo9.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtTavolo9.Text = carta;
                        lblTavolo9.Opacity = 100;
                    }
                    else
                    {
                        lblTavolo9.Opacity = 0;
                        txtTavolo9.Text = "v";
                    }

                }
                else if (c == 9)
                {
                    if (c < tmp - 1)
                    {
                        string carta = carteTavolo[c];
                        string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                        lblTavolo10.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtTavolo10.Text = carta;
                        lblTavolo10.Opacity = 100;
                    }
                    else
                    {
                        lblTavolo10.Opacity = 0;
                        txtTavolo10.Text = "v";
                    }

                }
                c++;
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





