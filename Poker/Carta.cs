using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Carta
    {
        public string valor;
        public string naipe;

        public Carta(string carta)
        {
            this.valor = carta[0].ToString();
            this.naipe = carta[1].ToString();
        }


    }


}
