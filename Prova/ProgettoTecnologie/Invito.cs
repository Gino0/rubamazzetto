using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoTecnologie
{
    class Invito
    {
    
        string nicknameAvv;

        public void getNick(string user)
        {
            nicknameAvv = user;
        }

   
        public string setNick()
        {
            return nicknameAvv;
        }
    }
}
