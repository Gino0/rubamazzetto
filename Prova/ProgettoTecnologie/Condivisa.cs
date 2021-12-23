using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoTecnologie
{
    class Condivisa
    {
        string ipAdd;
        string nickname;
                
        public void getIp(string ip)
        {
            ipAdd = ip;
        }
        public void getNick(string user)
        {
            nickname = user;
        }

        public string setIp()
        {
            return ipAdd;
        }
        public string setNick()
        {
            return nickname;
        }
    }
}
