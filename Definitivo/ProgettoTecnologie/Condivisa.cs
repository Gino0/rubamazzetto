using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoTecnologie
{
    public class Condivisa
    {
        string ipAdd;
        string nickname;
        string nomeMio;
                
        public void setIp(string ip)
        {
            ipAdd = ip;
        }
        public void setNick(string user)
        {
            nickname = user;
        }
        public void setNomeMio(string nome)
        {
            nomeMio = nome;
        }

        public string getIp()
        {
            return ipAdd;
        }
        public string getNick()
        {
            return nickname;
        }
        public string getNomeMio()
        {
            return nomeMio;
        }
    }
}
