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
using System.Windows.Threading;

namespace ProgettoTecnologie
{
    /// <summary>
    /// Logica di interazione per FinestraTavolo.xaml
    /// </summary>
    public partial class FinestraTavolo : Window
    {
        int carteRimanentiNelMazzo=40;
        string usernameMio;
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
        int labelScelta; //valori possibili 1, 2 e 3
        string vincitore="";


        bool ultimaPescata = true; //false->lui    true->io


        bool clickCarta1 = false;
        bool clickCarta2 = false;
        bool clickCarta3 = false;

        bool clickTavolo1 = false;
        bool clickTavolo2 = false;
        bool clickTavolo3 = false;
        bool clickTavolo4 = false;
        bool clickTavolo5 = false;
        bool clickTavolo6 = false;
        bool clickTavolo7 = false;
        bool clickTavolo8 = false;
        bool clickTavolo9 = false;
        bool clickTavolo10 = false;

        bool clickMazzo2 = false;

        bool presente = false;

        string mex = ""; //lo uso per inseire "rub" o "pre"


        string cartaSelezionata;


        public FinestraTavolo(string ipAvv, string nickAvv, bool part, string nomeMio)
        {

            //string url = Directory.GetCurrentDirectory() + "carte/RETRO.png";
            //lblRetro.Background = new ImageBrush(new BitmapImage(new Uri(url)));
            InitializeComponent();
            ipAvversario = ipAvv;
            nicknameAvversario = nickAvv;
            usernameMio = nomeMio;
            parto = part;

            lblNomeAvversario.Content = nicknameAvversario;
            lblNomeAvversario.Refresh();

            Condivisa c = new Condivisa();
            c.setIp(ipAvversario);
            c.setNick(nicknameAvversario);
            c.setNomeMio(usernameMio);

            //Label1.Text = "'<img src='Images/globe1.JPG' />'"; 

            if(parto==false)
            {
                //mazziere io e giocatore lui



            }
            else
            {
                //mazziere lui e giocatore io



            }
        }


        //quando una carta è presente nella casella, scrivo p, altrimentio è v

        //se parto=false, faccio i controlli


        


        //metodi per mazziere
        private void Aggiornamento()
        {
            lblTavolo1.Refresh();
            lblTavolo2.Refresh();
            lblTavolo3.Refresh();
            lblTavolo4.Refresh();
            lblTavolo5.Refresh();
            lblTavolo6.Refresh();
            lblTavolo7.Refresh();
            lblTavolo8.Refresh();
            lblTavolo9.Refresh();
            lblTavolo10.Refresh();

            lblCarta1.Refresh();
            lblCarta2.Refresh();
            lblCarta3.Refresh();

            lblCartaMazzo1.Refresh();
            lblCartaMazzo2.Refresh();

            lblRetroAvversario1.Refresh();
            lblRetroAvversario2.Refresh();
            lblRetroAvversario3.Refresh();


            txtTavolo1.Refresh();
            txtTavolo2.Refresh();
            txtTavolo3.Refresh();
            txtTavolo4.Refresh();
            txtTavolo5.Refresh();
            txtTavolo6.Refresh();
            txtTavolo7.Refresh();
            txtTavolo8.Refresh();
            txtTavolo9.Refresh();
            txtTavolo10.Refresh();

            txtCarta1.Refresh();
            txtCarta2.Refresh();
            txtCarta3.Refresh();

            txtCartaMazzo1.Refresh();
            txtCartaMazzo2.Refresh();

            txtRetroAvversario1.Refresh();
            txtRetroAvversario2.Refresh();
            txtRetroAvversario3.Refresh();


        }

        private void CarteAvversario()
        {
            int da = 0;
            int a = 40;
            int cont = 0;

            carteRimanentiNelMazzo = carteRimanentiNelMazzo - 3;


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
                        manoAvversaria = carta+",";
                    }
                    else if (cont == 2)
                    {
                        string carta = mazzo[posizioneVettore];
                        mazzo[posizioneVettore] = "zz";
                        manoAvversaria = manoAvversaria+ carta + ",";
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
            carteRimanentiNelMazzo = carteRimanentiNelMazzo - 3;
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
                        lblCarta1.Opacity = 100;
                    }
                    else if (cont == 2)
                    {
                        string carta = mazzo[posizioneVettore];
                        string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                        lblCarta2.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtCarta2.Text = "p";
                        mazzo[posizioneVettore] = "zz";
                        inMano[1] = carta;
                        lblCarta2.Opacity = 100;
                    }
                    else
                    {
                        string carta = mazzo[posizioneVettore];
                        string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                        lblCarta3.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        txtCarta3.Text = "p";
                        mazzo[posizioneVettore] = "zz";
                        inMano[2] = carta;
                        lblCarta1.Opacity = 100;
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

            carteRimanentiNelMazzo = carteRimanentiNelMazzo - 4;
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
                        lblTavolo1.Opacity = 100;
                        txtTavolo1.Text = carta;

                        mazzo[posizioneVettore] = "zz";
                        char carattere = carta.ToCharArray()[0];
                        cartePresenti[numeroPresenti] = carattere;
                        numeroPresenti++;
                        daPassare = carta+ ",";

                    }
                    else if(cont==2)
                    {
                        string carta = mazzo[posizioneVettore];
                        char carattere = carta.ToCharArray()[0];
                        if (carattere != cartePresenti[0])
                        {
                            string url = Directory.GetCurrentDirectory() + "carte/" + carta + ".jpg";
                            lblTavolo2.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                            lblTavolo2.Opacity = 100;
                            txtTavolo2.Text = carta;

                            mazzo[posizioneVettore] = "zz";
                            cartePresenti[numeroPresenti] = carattere;
                            numeroPresenti++;
                            daPassare = daPassare + carta + ",";
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
                            lblTavolo3.Opacity = 100;
                            txtTavolo3.Text = carta;

                            mazzo[posizioneVettore] = "zz";
                            cartePresenti[numeroPresenti] = carattere;
                            numeroPresenti++;
                            daPassare = daPassare + carta + ",";
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
                            lblTavolo4.Opacity = 100;
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
            string[] carteTavolo =carteTav.Split(',');
            /*int x = carteTavolo.Length;
            int y = carteSulTavolo;

            if (x<=y)
            {
                ultimaPescata = false;
            }*/

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

        } //per entrabmbi

        private void RiattivoBottoniMano()
        {
            if(txtCarta1.Text!="v")
            {
                btnCarta1.IsEnabled = true;
            }
            if (txtCarta2.Text != "v")
            {
                btnCarta2.IsEnabled = true;
            }
            if (txtCarta3.Text != "v")
            {
                btnCarta3.IsEnabled = true;
            }
        }

        private void DisattivoBottoniMano()
        {
            
                btnCarta1.IsEnabled = false;
            
                btnCarta2.IsEnabled = false;
            
                btnCarta3.IsEnabled = false;
           
        }

        private string ControlloScelta()
        {
            bool selezione = false;
            string cartaScelta = "";
            while (selezione == false)
            {
                if (clickCarta1 == true)
                {
                    cartaScelta = txtCarta1.Text;
                    selezione = true;
                    clickCarta1 = false;
                    labelScelta = 1;
                }
                else if (clickCarta2 == true)
                {
                    cartaScelta = txtCarta2.Text;
                    selezione = true;
                    clickCarta2 = false;
                    labelScelta = 2;
                }
                else if (clickCarta3 == true)
                {
                    cartaScelta = txtCarta3.Text;
                    selezione = true;
                    clickCarta3 = false;
                    labelScelta = 3;

                }
            }

            return cartaScelta;
        }

        private void AttivoBtnGiocata(string carSel)
        {
            
            cartaSelezionata = carSel;
            char carattere = cartaSelezionata.ToCharArray()[0];

            string cartaTavolo1 = txtTavolo1.Text;
            char carattereTavolo1 = cartaTavolo1.ToCharArray()[0];

            string cartaTavolo2 = txtTavolo2.Text;
            char carattereTavolo2 = cartaTavolo2.ToCharArray()[0];

            string cartaTavolo3 = txtTavolo3.Text;
            char carattereTavolo3 = cartaTavolo3.ToCharArray()[0];

            string cartaTavolo4 = txtTavolo4.Text;
            char carattereTavolo4 = cartaTavolo4.ToCharArray()[0];

            string cartaTavolo5 = txtTavolo5.Text;
            char carattereTavolo5 = cartaTavolo5.ToCharArray()[0];

            string cartaTavolo6 = txtTavolo6.Text;
            char carattereTavolo6 = cartaTavolo6.ToCharArray()[0];

            string cartaTavolo7 = txtTavolo7.Text;
            char carattereTavolo7 = cartaTavolo7.ToCharArray()[0];

            string cartaTavolo8 = txtTavolo8.Text;
            char carattereTavolo8 = cartaTavolo8.ToCharArray()[0];

            string cartaTavolo9 = txtTavolo9.Text;
            char carattereTavolo9 = cartaTavolo9.ToCharArray()[0];

            string cartaTavolo10 = txtTavolo10.Text;
            char carattereTavolo10 = cartaTavolo10.ToCharArray()[0];


            if (carattereTavolo1 == carattere)
            {
                btnTavolo1.IsEnabled = true;
                presente = true;
            }
            else if (carattereTavolo2 == carattere)
            {
                btnTavolo2.IsEnabled = true;
                presente = true;
            }
            else if(carattereTavolo3== carattere)
            {
                btnTavolo3.IsEnabled = true;
                presente = true;
            }
            else if (carattereTavolo4 == carattere)
            {
                btnTavolo4.IsEnabled = true;
                presente = true;
            }
            else if (carattereTavolo5 == carattere)
            {
                btnTavolo5.IsEnabled = true;
                presente = true;
            }
            else if (carattereTavolo6 == carattere)
            {
                btnTavolo6.IsEnabled = true;
                presente = true;
            }
            else if (carattereTavolo7 == carattere)
            {
                btnTavolo7.IsEnabled = true;
                presente = true;
            }
            else if (carattereTavolo8 == carattere)
            {
                btnTavolo8.IsEnabled = true;
                presente = true;
            }
            else if (carattereTavolo9 == carattere)
            {
                btnTavolo9.IsEnabled = true;
                presente = true;
            }
            else if (carattereTavolo10 == carattere)
            {
                btnTavolo10.IsEnabled = true;
                presente = true;
            }

            if(presente==false)
            {
                string cartaMazzo2 = txtCartaMazzo2.Text;
                char carattereMazzo2 = cartaMazzo2.ToCharArray()[0];

                if (carattereMazzo2 == carattere)
                {
                    btnCartaMazzo2.IsEnabled = true;
                    presente = true;
                }
                else
                {
                    if (txtTavolo1.Text == "v")
                    {
                        btnTavolo1.IsEnabled = true;
                    }
                    else if (txtTavolo2.Text == "v")
                    {
                        btnTavolo2.IsEnabled = true;
                    }
                    else if (txtTavolo3.Text == "v")
                    {
                        btnTavolo3.IsEnabled = true;
                    }
                    else if (txtTavolo4.Text == "v")
                    {
                        btnTavolo4.IsEnabled = true;
                    }
                    else if (txtTavolo5.Text == "v")
                    {
                        btnTavolo5.IsEnabled = true;
                    }
                    else if (txtTavolo6.Text == "v")
                    {
                        btnTavolo6.IsEnabled = true;
                    }
                    else if (txtTavolo7.Text == "v")
                    {
                        btnTavolo7.IsEnabled = true;
                    }
                    else if (txtTavolo8.Text == "v")
                    {
                        btnTavolo8.IsEnabled = true;
                    }
                    else if (txtTavolo9.Text == "v")
                    {
                        btnTavolo9.IsEnabled = true;
                    }
                    else if (txtTavolo10.Text == "v")
                    {
                        btnTavolo10.IsEnabled = true;
                    }
                }
            }

           
        }

        private void DisattivoBottoniTavolo()
        {
            btnTavolo1.IsEnabled = false;
            btnTavolo2.IsEnabled = false;
            btnTavolo3.IsEnabled = false;
            btnTavolo4.IsEnabled = false;
            btnTavolo5.IsEnabled = false;
            btnTavolo6.IsEnabled = false;
            btnTavolo7.IsEnabled = false;
            btnTavolo8.IsEnabled = false;
            btnTavolo9.IsEnabled = false;
            btnTavolo10.IsEnabled = false;
            btnCartaMazzo2.IsEnabled = false;

            clickTavolo1 = false;
            clickTavolo2 = false;
            clickTavolo3 = false;
            clickTavolo4 = false;
            clickTavolo5 = false;
            clickTavolo6 = false;
            clickTavolo7 = false;
            clickTavolo8 = false;
            clickTavolo9 = false;
            clickTavolo10 = false;

            clickMazzo2 = false;
        }

        private void Giocata()
        {
            bool haClickato = false;
            while (haClickato == false)
            {
                if (clickTavolo1 == true)
                {
                    haClickato = true;
                    if (presente == true)
                    {
                        mex = "pre";
                        maz = txtTavolo1.Text;
                        txtTavolo1.Text = "v";
                        nMaz = nMaz + 2;
                        lblTavolo1.Opacity = 0;

                        txtCartaMazzo1.Text = maz;
                        string url = Directory.GetCurrentDirectory() + "carte/" + maz + ".jpg";
                        lblTavolo1.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo1.Opacity = 100;
                    }
                    else
                    {
                        txtTavolo1.Text = cartaSelezionata;
                        string url = Directory.GetCurrentDirectory() + "carte/" + cartaSelezionata + ".jpg";
                        lblTavolo1.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo1.Opacity = 100;
                    }
                }
                else if (clickTavolo2 == true)
                {
                    haClickato = true;
                    if (presente == true)
                    {
                        mex = "pre";
                        maz = txtTavolo2.Text;
                        txtTavolo2.Text = "v";
                        nMaz = nMaz + 2;
                        lblTavolo2.Opacity = 0;

                        txtCartaMazzo1.Text = maz;
                        string url = Directory.GetCurrentDirectory() + "carte/" + maz + ".jpg";
                        lblTavolo1.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo1.Opacity = 100;
                    }
                    else
                    {
                        txtTavolo2.Text = cartaSelezionata;
                        string url = Directory.GetCurrentDirectory() + "carte/" + cartaSelezionata + ".jpg";
                        lblTavolo2.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo2.Opacity = 100;
                    }
                }
                else if (clickTavolo3 == true)
                {
                    haClickato = true;
                    if (presente == true)
                    {
                        mex = "pre";
                        maz = txtTavolo3.Text;
                        txtTavolo3.Text = "v";
                        nMaz = nMaz + 2;
                        lblTavolo3.Opacity = 0;

                        txtCartaMazzo1.Text = maz;
                        string url = Directory.GetCurrentDirectory() + "carte/" + maz + ".jpg";
                        lblTavolo1.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo1.Opacity = 100;
                    }
                    else
                    {
                        txtTavolo3.Text = cartaSelezionata;
                        string url = Directory.GetCurrentDirectory() + "carte/" + cartaSelezionata + ".jpg";
                        lblTavolo3.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo3.Opacity = 100;
                    }
                }
                else if (clickTavolo4 == true)
                {
                    haClickato = true;
                    if (presente == true)
                    {
                        mex = "pre";
                        maz = txtTavolo4.Text;
                        txtTavolo4.Text = "v";
                        nMaz = nMaz + 2;
                        lblTavolo3.Opacity = 0;

                        txtCartaMazzo1.Text = maz;
                        string url = Directory.GetCurrentDirectory() + "carte/" + maz + ".jpg";
                        lblTavolo1.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo1.Opacity = 100;
                    }
                    else
                    {
                        txtTavolo4.Text = cartaSelezionata;
                        string url = Directory.GetCurrentDirectory() + "carte/" + cartaSelezionata + ".jpg";
                        lblTavolo4.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo4.Opacity = 100;
                    }
                }
                else if (clickTavolo5 == true)
                {
                    haClickato = true;
                    if (presente == true)
                    {
                        mex = "pre";
                        maz = txtTavolo5.Text;
                        txtTavolo5.Text = "v";
                        nMaz = nMaz + 2;
                        lblTavolo5.Opacity = 0;

                        txtCartaMazzo1.Text = maz;
                        string url = Directory.GetCurrentDirectory() + "carte/" + maz + ".jpg";
                        lblTavolo1.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo1.Opacity = 100;
                    }
                    else
                    {
                        txtTavolo5.Text = cartaSelezionata;
                        string url = Directory.GetCurrentDirectory() + "carte/" + cartaSelezionata + ".jpg";
                        lblTavolo5.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo5.Opacity = 100;
                    }
                }
                else if (clickTavolo6 == true)
                {
                    haClickato = true;
                    if (presente == true)
                    {
                        mex = "pre";
                        maz = txtTavolo6.Text;
                        txtTavolo5.Text = "v";
                        nMaz = nMaz + 2;
                        lblTavolo6.Opacity = 0;

                        txtCartaMazzo1.Text = maz;
                        string url = Directory.GetCurrentDirectory() + "carte/" + maz + ".jpg";
                        lblTavolo1.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo1.Opacity = 100;
                    }
                    else
                    {
                        txtTavolo6.Text = cartaSelezionata;
                        string url = Directory.GetCurrentDirectory() + "carte/" + cartaSelezionata + ".jpg";
                        lblTavolo6.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo6.Opacity = 100;
                    }
                }
                else if (clickTavolo7 == true)
                {
                    haClickato = true;
                    if (presente == true)
                    {
                        mex = "pre";
                        maz = txtTavolo7.Text;
                        txtTavolo7.Text = "v";
                        nMaz = nMaz + 2;
                        lblTavolo7.Opacity = 0;

                        txtCartaMazzo1.Text = maz;
                        string url = Directory.GetCurrentDirectory() + "carte/" + maz + ".jpg";
                        lblTavolo1.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo1.Opacity = 100;
                    }
                    else
                    {
                        txtTavolo7.Text = cartaSelezionata;
                        string url = Directory.GetCurrentDirectory() + "carte/" + cartaSelezionata + ".jpg";
                        lblTavolo7.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo7.Opacity = 100;
                    }
                }
                else if (clickTavolo8 == true)
                {
                    haClickato = true;
                    if (presente == true)
                    {
                        mex = "pre";
                        maz = txtTavolo8.Text;
                        txtTavolo8.Text = "v";
                        nMaz = nMaz + 2;
                        lblTavolo8.Opacity = 0;

                        txtCartaMazzo1.Text = maz;
                        string url = Directory.GetCurrentDirectory() + "carte/" + maz + ".jpg";
                        lblTavolo1.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo1.Opacity = 100;
                    }
                    else
                    {
                        txtTavolo8.Text = cartaSelezionata;
                        string url = Directory.GetCurrentDirectory() + "carte/" + cartaSelezionata + ".jpg";
                        lblTavolo8.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo8.Opacity = 100;
                    }
                }
                else if (clickTavolo9 == true)
                {
                    haClickato = true;
                    if (presente == true)
                    {
                        mex = "pre";
                        maz = txtTavolo9.Text;
                        txtTavolo9.Text = "v";
                        nMaz = nMaz + 2;
                        lblTavolo9.Opacity = 0;

                        txtCartaMazzo1.Text = maz;
                        string url = Directory.GetCurrentDirectory() + "carte/" + maz + ".jpg";
                        lblTavolo1.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo1.Opacity = 100;
                    }
                    else
                    {
                        txtTavolo9.Text = cartaSelezionata;
                        string url = Directory.GetCurrentDirectory() + "carte/" + cartaSelezionata + ".jpg";
                        lblTavolo9.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo9.Opacity = 100;
                    }
                }
                else if (clickTavolo10 == true)
                {
                    haClickato = true;
                    if (presente == true)
                    {
                        mex = "pre";
                        maz = txtTavolo10.Text;
                        txtTavolo10.Text = "v";
                        nMaz = nMaz + 2;
                        lblTavolo10.Opacity = 0;

                        txtCartaMazzo1.Text = maz;
                        string url = Directory.GetCurrentDirectory() + "carte/" + maz + ".jpg";
                        lblTavolo1.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo1.Opacity = 100;
                    }
                    else
                    {
                        txtTavolo10.Text = cartaSelezionata;
                        string url = Directory.GetCurrentDirectory() + "carte/" + cartaSelezionata + ".jpg";
                        lblTavolo10.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                        lblTavolo10.Opacity = 100;
                    }
                }
                else if(clickMazzo2==true)
                {
                    mex = "rub";
                    maz = txtCartaMazzo2.Text;
                    txtCartaMazzo2.Text = "v";
                    nMaz = nMaz + nMazAvversario;
                    nMazAvversario = 0;
                    lblCartaMazzo2.Opacity = 0;
                }
            }

            if(labelScelta==1)
            {
                lblCarta1.Opacity = 0;
                txtCarta1.Text = "v";
            }
            else if (labelScelta == 2)
            {
                lblCarta2.Opacity = 0;
                txtCarta2.Text = "v";
            }
            else if (labelScelta == 3)
            {
                lblCarta3.Opacity = 0;
                txtCarta3.Text = "v";
            }
        }

        private string StringaDaMandare()
        {
            string daMandare = "tav;";
            bool serveVirgola = false;

            if(txtTavolo1.Text!="v")
            {
                daMandare = daMandare + txtTavolo1.Text;
                serveVirgola = true;
            }
            if (txtTavolo2.Text != "v")
            { 
                if (serveVirgola == true)
                {
                    daMandare = daMandare + ",";
                }
                daMandare = daMandare + txtTavolo2.Text;
                serveVirgola = true;
            }
            if (txtTavolo3.Text != "v")
            {
                if (serveVirgola == true)
                {
                    daMandare = daMandare + ",";
                }
                daMandare = daMandare + txtTavolo3.Text;
                serveVirgola = true;
            }
            if (txtTavolo4.Text != "v")
            {
                if (serveVirgola == true)
                {
                    daMandare = daMandare + ",";
                }
                daMandare = daMandare + txtTavolo4.Text;
                serveVirgola = true;
            }
            if (txtTavolo5.Text != "v")
            {
                if (serveVirgola == true)
                {
                    daMandare = daMandare + ",";
                }
                daMandare = daMandare + txtTavolo5.Text;
                serveVirgola = true;
            }
            if (txtTavolo6.Text != "v")
            {
                if (serveVirgola == true)
                {
                    daMandare = daMandare + ",";
                }
                daMandare = daMandare + txtTavolo6.Text;
                serveVirgola = true;
            }
            if (txtTavolo7.Text != "v")
            {
                if (serveVirgola == true)
                {
                    daMandare = daMandare + ",";
                }
                daMandare = daMandare + txtTavolo7.Text;
                serveVirgola = true;
            }
            if (txtTavolo8.Text != "v")
            {
                if (serveVirgola == true)
                {
                    daMandare = daMandare + ",";
                }
                daMandare = daMandare + txtTavolo8.Text;
                serveVirgola = true;
            }
            if (txtTavolo9.Text != "v")
            {
                if (serveVirgola == true)
                {
                    daMandare = daMandare + ",";
                }
                daMandare = daMandare + txtTavolo9.Text;
                serveVirgola = true;
            }
            if (txtTavolo9.Text != "v")
            {
                if (serveVirgola == true)
                {
                    daMandare = daMandare + ",";
                }
                daMandare = daMandare + txtTavolo9.Text;
                serveVirgola = true;
            }
            if (txtTavolo10.Text != "v")
            {
                if (serveVirgola == true)
                {
                    daMandare = daMandare + ",";
                }
                daMandare = daMandare + txtTavolo10.Text;
                serveVirgola = true;
            }

            daMandare = daMandare + ";" + maz + ";" + nMaz.ToString() + ";";



            return daMandare;
        }

        private int contoCarteRimaste()
        {
            int rimaste = 0;

            if(txtTavolo1.Text!="v")
            {
                rimaste++;
            }
            if (txtTavolo2.Text != "v")
            {
                rimaste++;
            }
            if (txtTavolo3.Text != "v")
            {
                rimaste++;
            }
            if (txtTavolo4.Text != "v")
            {
                rimaste++;
            }
            if (txtTavolo5.Text != "v")
            {
                rimaste++;
            }
            if (txtTavolo6.Text != "v")
            {
                rimaste++;
            }
            if (txtTavolo7.Text != "v")
            {
                rimaste++;
            }
            if (txtTavolo8.Text != "v")
            {
                rimaste++;
            }
            if(txtTavolo9.Text != "v")
            {
                rimaste++;
            }
            if (txtTavolo10.Text != "v")
            {
                rimaste++;
            }

            return rimaste;
        }

        private void SvuotaTavolo()
        {
            lblTavolo1.Opacity = 0;
            lblTavolo2.Opacity = 0;
            lblTavolo3.Opacity = 0;
            lblTavolo4.Opacity = 0;
            lblTavolo5.Opacity = 0;
            lblTavolo6.Opacity = 0;
            lblTavolo7.Opacity = 0;
            lblTavolo8.Opacity = 0;
            lblTavolo9.Opacity = 0;
            lblTavolo10.Opacity = 0;

            txtTavolo1.Text = "v";
            txtTavolo2.Text = "v";
            txtTavolo3.Text = "v";
            txtTavolo4.Text = "v";
            txtTavolo5.Text = "v";
            txtTavolo6.Text = "v";
            txtTavolo7.Text = "v";
            txtTavolo8.Text = "v";
            txtTavolo9.Text = "v";
            txtTavolo10.Text = "v";
        }

        private void LeggoRisultati(string daSplittare)
        {
            string[] risultati = daSplittare.Split(';');

            if (risultati[0] == "win")
            {
                vincitore = risultati[1];

                if (risultati[1] == usernameMio)
                {
                    nMaz = Int32.Parse(risultati[2]);
                    nMazAvversario = Int32.Parse(risultati[3]);
                }
                else
                {
                    nMaz = Int32.Parse(risultati[3]);
                    nMazAvversario = Int32.Parse(risultati[2]);
                }
            }
            else if (risultati[0] == "par")
            {
                vincitore = "";
            }


        }


        //aggiungere che l'ultimo che ha preso la carta, prende tutte quelle giu
        //creando una variabile contenente il numero d carte precedentemente aggiunte al tavolo
        //confrontando con quelle passate nuovamente, per vedere chi è stato l'ultimo a prendere una carta dal tavolo
        void ThreadMazziere(object o)
        {
            


            //Thread.Sleep(1000);
            bool rubata = false;
            Condivisa c = (Condivisa)o;
            String hostname = c.getIp();
            bool ok = false;
            int turni=0;

            TcpClient tcp = new TcpClient(hostname, 2003);

            CaricaCarte();
            CarteSultavolo();
            Aggiornamento();

            StreamWriter st = new StreamWriter(tcp.GetStream());
            st.WriteLine("tav;" + daPassare + maz+";"+nMaz+";");
            st.Close();




            while (carteRimanentiNelMazzo!=0)
            {
                if(carteRimanentiNelMazzo==0)
                {
                    txtRetro.Text = "v";
                    lblRetro.Opacity = 0;
                }



                CarteMie();
                Aggiornamento();
                CarteAvversario();
                Aggiornamento();
                StreamWriter sc = new StreamWriter(tcp.GetStream());
                sc.WriteLine("crd;" + manoAvversaria);
                sc.Close();





                while (turni!=3)
                {

                    StreamReader sr = new StreamReader(tcp.GetStream());
                    string s = sr.ReadLine();

                    string[] divisa = s.Split(';');

                    if (divisa[0] == "rub" || divisa[0] == "pre")
                    {
                        ultimaPescata = false;
                        if (divisa[0] == "rub")
                        {
                            rubata = true;
                        }
                        StreamReader stav = new StreamReader(tcp.GetStream());
                        string t = stav.ReadLine();

                        divisa = t.Split(';');

                        if (divisa[0] == "tav")
                        {
                            ok = true;
                        }

                    }
                    else if (divisa[0] == "tav")
                    {
                        ok = true;
                    }

                    if (ok == true)
                    {

                        int numeroDiCarteAvversario = Int32.Parse(divisa[3]);
                        AggiornoTavoloAvversario(divisa[1], divisa[2], numeroDiCarteAvversario, rubata);
                        Aggiornamento();

                        ok = false;
                        rubata = false;

                        RiattivoBottoniMano();
                        string cartaSele = ControlloScelta();
                        DisattivoBottoniMano();

                        AttivoBtnGiocata(cartaSele);
                        Giocata();
                        Aggiornamento();
                        DisattivoBottoniTavolo();

                        if (mex != "")
                        {
                            ultimaPescata = true;
                            StreamWriter smex = new StreamWriter(tcp.GetStream());
                            smex.WriteLine(mex + ";");
                            smex.Close();
                            mex = "";
                        }

                        string passo = StringaDaMandare();
                        StreamWriter spass = new StreamWriter(tcp.GetStream());
                        spass.WriteLine(passo);
                        spass.Close();
                        turni++;


                    }
                }
                turni = 0;

                
            }

            int carteSulTavolo = contoCarteRimaste();

            if (ultimaPescata == true)
            {
                nMaz = nMaz + carteSulTavolo;
            }
            else
            {
                nMazAvversario = nMazAvversario + carteSulTavolo;
            }

            Thread.Sleep(1000);
            SvuotaTavolo();
            Thread.Sleep(2000);

            if (nMaz == nMazAvversario)
            {
                StreamWriter sfine = new StreamWriter(tcp.GetStream());
                sfine.WriteLine("par;");
                sfine.Close();
            }
            else 
            {
                string winner;

                if (nMaz < nMazAvversario)
                {
                    winner = "win;" + nicknameAvversario + ";" + nMazAvversario + ";" + nMaz + ";";
                    vincitore = nicknameAvversario;
                }
                else
                {
                    winner = "win;" + usernameMio + ";" + nMaz + ";" + nMazAvversario + ";";
                    vincitore = usernameMio;
                }

                StreamWriter sfine = new StreamWriter(tcp.GetStream());
                sfine.WriteLine(winner);
                sfine.Close();
            }

            FinestraFinePartita endGame = new FinestraFinePartita(vincitore, usernameMio, nicknameAvversario, nMaz, nMazAvversario);
            this.Hide();
            endGame.Show();



        }



        void ThreadGiogatore(object o)
        {
            bool rubata = false;
            bool ok = false;
            String hostname = "localhost";
            IPAddress addr;

            IPAddress.TryParse(hostname, out addr);
            TcpListener listener = new TcpListener(addr, 2003);
            listener.Start();
            TcpClient tcp = listener.AcceptTcpClient();





            while (true)
            {
                StreamReader sr = new StreamReader(tcp.GetStream());
                string s = sr.ReadLine();

                string[] divisa = s.Split(';');

                if(divisa[0] == "win" || divisa[0] == "par")
                {
                    SvuotaTavolo();

                    lblRetro.Opacity = 0;
                    txtRetro.Text = "v";

                    LeggoRisultati(s);
                    Thread.Sleep(2000);


                    FinestraFinePartita endGame = new FinestraFinePartita(vincitore, usernameMio, nicknameAvversario, nMaz, nMazAvversario);
                    this.Hide();
                    endGame.Show();

                }
                else if (divisa[0] == "rub" || divisa[0] == "pre")
                {
                    //ultimaPescata = false;
                    if (divisa[0] == "rub")
                    {
                        rubata = true;
                    }
                    StreamReader stav = new StreamReader(tcp.GetStream());
                    string t = stav.ReadLine();

                    divisa = t.Split(';');

                    if (divisa[0] == "win" || divisa[0] == "par")
                    {
                        SvuotaTavolo();

                        lblRetro.Opacity = 0;
                        txtRetro.Text = "v";

                        LeggoRisultati(s);
                        Thread.Sleep(2000);


                        FinestraFinePartita endGame = new FinestraFinePartita(vincitore, usernameMio, nicknameAvversario, nMaz, nMazAvversario);
                        this.Hide();
                        endGame.Show();

                    }
                    else if (divisa[0] == "tav")
                    {
                        ok = true;
                    }

                }
                else if (divisa[0] == "tav")
                {
                    ok = true;
                }

                if (ok == true)
                {

                    int numeroDiCarteAvversario = Int32.Parse(divisa[3]);
                    AggiornoTavoloAvversario(divisa[1], divisa[2], numeroDiCarteAvversario, rubata);
                    Aggiornamento();

                    ok = false;
                    rubata = false;

                    RiattivoBottoniMano();
                    string cartaSele = ControlloScelta();
                    DisattivoBottoniMano();

                    AttivoBtnGiocata(cartaSele);
                    Giocata();
                    Aggiornamento();
                    DisattivoBottoniTavolo();

                    if (mex != "")
                    {
                        StreamWriter smex = new StreamWriter(tcp.GetStream());
                        smex.WriteLine(mex + ";");
                        smex.Close();
                        mex = "";
                    }

                    string passo = StringaDaMandare();
                    StreamWriter spass = new StreamWriter(tcp.GetStream());
                    spass.WriteLine(passo);
                    spass.Close();

                }

            }

        } //devo ricevere il vincitore



        private void btnCarta1_Click(object sender, RoutedEventArgs e)
        {
            clickCarta1 = true;
        }

        private void btnCarta2_Click(object sender, RoutedEventArgs e)
        {
            clickCarta2 = true;
        }

        private void btnCarta3_Click(object sender, RoutedEventArgs e)
        {
            clickCarta3 = true;
        }

        private void btnTavolo1_Click(object sender, RoutedEventArgs e)
        {
            clickTavolo1 = true;
        }

        private void btnTavolo2_Click(object sender, RoutedEventArgs e)
        {
            clickTavolo2 = true;
        }

        private void btnTavolo3_Click(object sender, RoutedEventArgs e)
        {
            clickTavolo3 = true;
        }

        private void btnTavolo4_Click(object sender, RoutedEventArgs e)
        {
            clickTavolo4 = true;
        }

        private void btnTavolo5_Click(object sender, RoutedEventArgs e)
        {
            clickTavolo5 = true;
        }

        private void btnTavolo6_Click(object sender, RoutedEventArgs e)
        {
            clickTavolo6 = true;
        }

        private void btnTavolo7_Click(object sender, RoutedEventArgs e)
        {
            clickTavolo7 = true;
        }

        private void btnTavolo8_Click(object sender, RoutedEventArgs e)
        {
            clickTavolo8 = true;
        }

        private void btnTavolo9_Click(object sender, RoutedEventArgs e)
        {
            clickTavolo9 = true;
        }

        private void btnTavolo10_Click(object sender, RoutedEventArgs e)
        {
            clickTavolo10 = true;
        }

        private void btnCartaMazzo2_Click(object sender, RoutedEventArgs e)
        {
            clickMazzo2 = true;
        }
 
    }
}

public static class ExtensionMethods
{
    private static Action EmptyDelegate = delegate () { };

    public static void Refresh(this UIElement uiElement)
    {
        uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
    }   
}






